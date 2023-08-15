using CommonProjects.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CommonProjects
{
    /// <summary>
    /// A class responsible for reading the CSV file.
    /// </summary>
    public static class CsvReader
    {
        /// <summary>
        /// A static method that reads the CSV file and returns the data.
        /// </summary>
        /// <param name="filePath">The file path of the CSV file.</param>
        /// <param name="withHeader">A boolean indicating wether the CSV file contains headers or no.
        /// Related to ignoring the first row of the file.</param>
        /// <returns>The extracted data if successfull.</returns>
        public static List<EmployeeActivity> ReadCSV(string filePath, bool withHeader)
        {
            List<EmployeeActivity> data = new List<EmployeeActivity>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    // In case the CSV file contains headers, ignore the first row.
                    if (withHeader)
                    {
                        reader.ReadLine();
                    }

                    // Read the file line by line.
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var values = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        if (values.Length < 4)
                        {
                            continue;
                        }

                        // Try to parse the data from the CSV file.
                        if (!int.TryParse(values[0], out int employeeId) ||
                            !int.TryParse(values[1], out int projectId) ||
                            !TryParseDateTime(values[2].Trim(), out DateTime dateFrom))
                        {
                            UiManager.ShowErrorMessage("Error reading the file. Please check the data.", true);
                            continue;
                        }

                        // If the date "to" is equal to NULL, set it to the current date.
                        DateTime? dateTo = null;
                        if (string.Equals(values[3]?.Trim(), "NULL", StringComparison.OrdinalIgnoreCase))
                        {
                            dateTo = DateTime.Now;
                        }
                        else if (!TryParseDateTime(values[3].Trim(), out DateTime parsedDateTo))
                        {
                            UiManager.ShowErrorMessage("Error reading the file. Please check the data.", true);
                            continue;
                        }
                        else
                        {
                            dateTo = parsedDateTo;
                        }

                        data.Add(new EmployeeActivity
                        {
                            EmployeeId = employeeId,
                            ProjectId = projectId,
                            DateFrom = dateFrom,
                            DateTo = dateTo
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                // In case the parsing fails, show an error message and restart the application.
                UiManager.ShowErrorMessage("Error reading the file. Exception message: " + ex.Message, true);
            }

            return data;
        }

        /// <summary>
        /// A method that tries to parse the date from the CSV file to any date format.
        /// </summary>
        /// <param name="value">The value to be parsed.</param>
        /// <param name="dateTime">The parsed datetime.</param>
        /// <returns>A boolean indicating whether the parsing was executed successfully.</returns>
        private static bool TryParseDateTime(string value, out DateTime dateTime)
        {
            string[] formats = {
                "d/M/yy",
                "dd/MM/yy",
                "dd-MM-yyyy",
                "ddd, dd MMM yyyy",
                "dddd, dd MMMM yy",
                "M/d/yy",
                "M/d/yyyy",
                "M-d-yy",
                "M-d-yyyy",
                "MM/dd/yy",
                "MM-dd-yy",
                "MM/dd/yyyy",
                "MM-dd-yyyy",
                "yyyy-MM-dd",
                "yyyy-MMMM-dd",
                "yyyy-M-d",
            };

            return DateTime.TryParseExact(value, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);
        }
    }
}
