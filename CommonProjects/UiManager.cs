using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProjects
{
    /// <summary>
    /// A class containing the logic for the UI.
    /// </summary>
    public static class UiManager
    {
        /// <summary>
        /// Shows an error message and restarts the application if set.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        /// <param name="restart">An optional parameter indicating whether the application should be restarted.</param>
        public static void ShowErrorMessage(string message, bool restart = false)
        {
            MessageBox.Show(message);
            if (restart)
            {
                Application.Restart();
                Environment.Exit(400);
            }
        }
    }
}
