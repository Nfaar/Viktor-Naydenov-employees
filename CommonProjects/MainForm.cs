using CommonProjects.Business;
using CommonProjects.Models;
using System.Data;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace CommonProjects
{
    public partial class MainForm : Form
    {
        // Window message constants.
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void headerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        // An event handler for the button that adds a file.
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            OpenAndProcessCsV();
        }

        /// <summary>
        /// A method that opens a CSV file and processes it.
        /// </summary>
        private void OpenAndProcessCsV()
        {
            // Clear the data grid view.
            dataGridView.Rows.Clear();

            // Open a file dialog and select a CSV file.
            var v1 = new OpenFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv"
            };

            // If the user doesn't select a CSV file, show an error message.
            if (v1.ShowDialog() != DialogResult.OK)
            {
                UiManager.ShowErrorMessage("Please select a CSV file.");
                return;
            }

            // Get the path of the CSV file.
            var path = v1.FileName;
            pathDisplayLabel.Text = path;

            var boolWithHeaders = includeHeadersCheckBox.Checked;

            // Read the CSV file.
            var data = CsvReader.ReadCSV(path, boolWithHeaders);

            // Continue with processing the data.
            ProcessAndPopulateData(data);
        }

        /// <summary>
        /// A method that processes the data and populates the data grid view.
        /// </summary>
        /// <param name="data">The retrieved data from the CSV file.</param>
        private void ProcessAndPopulateData(List<EmployeeActivity> data)
        {
            var result = BusinessClass.ProcessData(data);

            if (result.Item1 == null || result.Item2 == null)
            {
                UiManager.ShowErrorMessage("There were no common projects found.");
                return;
            }

            var pair = result.Item1;
            var commonProjects = result.Item2.OrderByDescending(cp => cp.DaysWorked);

            // Display the common projects in the data grid view.
            foreach (var commonProject in commonProjects)
            {
                dataGridView.Rows.Add(pair.Item1, pair.Item2, commonProject.ProjectId, commonProject.DaysWorked);
            }
        }
    }
}