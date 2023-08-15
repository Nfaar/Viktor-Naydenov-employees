using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProjects.Models
{
    /// <summary>
    /// A model class that represents the common projects for a pair of employees.
    /// </summary>
    public class CommonProject
    {
        /// <summary>
        /// The ID of the common project.
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// The number of days worked on the common project for both employees.
        /// </summary>
        public int DaysWorked { get; set; }
    }
}
