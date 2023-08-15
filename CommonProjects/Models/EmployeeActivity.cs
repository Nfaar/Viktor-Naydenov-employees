namespace CommonProjects.Models
{
    /// <summary>
    /// An employee activity model.
    /// </summary>
    public class EmployeeActivity
    {
        /// <summary>
        /// The employee ID.
        /// </summary>
        public int EmployeeId { get; set; }

        /// <summary>
        /// The project ID on which the employee has worked.
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// The date from which the employee has worked on the project.
        /// </summary>
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// The date to which the employee has worked on the project.
        /// </summary>
        public DateTime? DateTo { get; set; }
    }
}
