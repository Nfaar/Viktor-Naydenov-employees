using CommonProjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CommonProjects.Business
{
    /// <summary>
    /// A business class containing the logic for the application.
    /// </summary>
    public class BusinessClass
    {
        /// <summary>
        /// The method that processes the data and returns the result.
        /// </summary>
        /// <param name="employeeActivities">The data retrieved from the csv file.</param>
        /// <returns>Returns a tuple containing the pair with their common projects and working days.</returns>
        public static (Tuple<int, int>?, List<CommonProject>?) ProcessData(List<EmployeeActivity> employeeActivities)
        {
            // Initializing the dictionary that will contain the common projects for the pair of employees.
            var commonProjectsDict = new Dictionary<Tuple<int, int>, List<CommonProject>>();

            // Iterating through the data retrieved from the CSV file.
            for (int i = 0; i < employeeActivities.Count; i++)
            {
                for (int j = i + 1; j < employeeActivities.Count; j++)
                {
                    int emp1Id = employeeActivities[i].EmployeeId;
                    int emp2ID = employeeActivities[j].EmployeeId;

                    // Retrieve the common projects for the current pair of employees.
                    List<int> commonProjects = FindCommonProjects(employeeActivities, emp1Id, emp2ID);

                    // Iterate through the common projects and calculate the common days.
                    foreach (var projectID in commonProjects)
                    {
                        // Retrieve the activities for the current project and pair of employees.
                        var targetedActivities = employeeActivities
                            .Where(x => x.ProjectId == projectID && (x.EmployeeId == emp1Id || x.EmployeeId == emp2ID))
                            .ToList();

                        // Calculate the common days.
                        int commonDays = CalculateCommonDays(targetedActivities, emp1Id, emp2ID);

                        // Add the pair of employees to the dictionary if it doesn't exist.
                        var pair = Tuple.Create(emp1Id, emp2ID);
                        commonProjectsDict.TryAdd(pair, new List<CommonProject>());

                        // Add the common project to the dictionary if it doesn't exist and if the work days are more than 0.
                        if (commonDays != 0 && !commonProjectsDict[pair].Any(x => x.ProjectId == projectID))
                        {
                            commonProjectsDict[pair].Add(new CommonProject
                            {
                                ProjectId = projectID,
                                DaysWorked = commonDays
                            });
                        }
                    }
                }
            }

            // Find the pair which has the most common days.
            Tuple<int, int>? longestPair = FindLongestPair(commonProjectsDict);

            // Return the longest pair and their common projects or display error if not found.
            if (longestPair != null)
            {
                return (longestPair, commonProjectsDict[longestPair]);
            }
            else
            {
                UiManager.ShowErrorMessage("No common projects found.", true);
                return (null, null);
            }
        }

        /// <summary>
        /// Method which finds the pair with the most common days.
        /// </summary>
        /// <param name="commonProjectsDict">The already processed dictionary containing all pairs and common projects.</param>
        /// <returns>Returns the pair.</returns>
        private static Tuple<int, int>? FindLongestPair(Dictionary<Tuple<int, int>, List<CommonProject>> commonProjectsDict)
        {
            return commonProjectsDict
                .OrderByDescending(pair => pair.Value.Sum(project => project.DaysWorked))
                .Select(pair => pair.Key)
                .FirstOrDefault();
        }

        /// <summary>
        /// Method that finds the common projects for a given pair of employees.
        /// </summary>
        /// <param name="employeeActivities">The complete employee activities to look through.</param>
        /// <param name="emp1Id">The id of the first employee.</param>
        /// <param name="emp2Id">The id of the second employee.</param>
        /// <returns></returns>
        private static List<int> FindCommonProjects(List<EmployeeActivity> employeeActivities, int emp1Id, int emp2Id)
        {
            // Initializing the list that will contain the id's of the common projects for the pair of employees.
            List<int> commonProjects = new List<int>();

            // Iterating through the employee activities.
            foreach (var employeeActivity in employeeActivities)
            {
                // Checking if the current activity is for one of the two employees and if the project is not already added to the list.
                if ((employeeActivity.EmployeeId == emp1Id || employeeActivity.EmployeeId == emp2Id) &&
                    !commonProjects.Contains(employeeActivity.ProjectId))
                {
                    commonProjects.Add(employeeActivity.ProjectId);
                }
            }

            return commonProjects;
        }

        /// <summary>
        /// Method that calculates the common days for a given pair of employees.
        /// </summary>
        /// <param name="targetedActivities">The the already filtered activities for this pair.</param>
        /// <param name="emp1Id">The id of the first employee.</param>
        /// <param name="emp2Id">The id of the second employee.</param>
        /// <returns>Returns the calculated common days for this pair.</returns>

        private static int CalculateCommonDays(List<EmployeeActivity> targetedActivities, int emp1Id, int emp2Id)
        {
            int commonDays = 0;

            // Iterating through the activities for the first employee.
            foreach (var activity1 in targetedActivities)
            {
                if (activity1.EmployeeId == emp1Id)
                {
                    // Iterating through the activities for the second employee.
                    foreach (var activity2 in targetedActivities)
                    {
                        // Checking if the current activities are for the both employees and if the project is the same.
                        if ((activity2.EmployeeId == emp2Id && activity1.EmployeeId != activity2.EmployeeId ) && (activity1.ProjectId == activity2.ProjectId))
                        {
                            // Calculate the actual overlap days.
                            int overlap = CalculateOverlapDays(activity1.DateFrom, activity1.DateTo, activity2.DateFrom, activity2.DateTo);
                            commonDays += overlap;
                        }
                    }
                }
            }

            return commonDays;
        }

        /// <summary>
        /// Method to calculate the actual overlap days between two date ranges.
        /// </summary>
        /// <param name="dateFrom1">The "from" date range of the first employee.</param>
        /// <param name="dateTo1">The "to" date range of the first employee.</param>
        /// <param name="dateFrom2">The "from" date range of the second employee.</param>
        /// <param name="dateTo2">The "to" date range of the second employee.</param>
        /// <returns>Returns the actual overlap days.</returns>

        private static int CalculateOverlapDays(DateTime dateFrom1, DateTime? dateTo1, DateTime dateFrom2, DateTime? dateTo2)
        {
            // Getting the latest "from" date and the earliest "to" date.
            DateTime maxDateFrom = dateFrom1 > dateFrom2 ? dateFrom1 : dateFrom2;
            DateTime? minDateTo = dateTo1 < dateTo2 ? dateTo1 : dateTo2;

            if (minDateTo >= maxDateFrom)
            {
                return (int)((minDateTo.Value - maxDateFrom).TotalDays) + 1;
            }

            return 0;
        }
    }
}
