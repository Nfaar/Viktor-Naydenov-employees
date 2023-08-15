namespace CommonProjects
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            pathLabel = new Label();
            dataGridPanel = new Panel();
            dataGridView = new DataGridView();
            firstEmpColumn = new DataGridViewTextBoxColumn();
            secondEmpColumn = new DataGridViewTextBoxColumn();
            projectIdColumn = new DataGridViewTextBoxColumn();
            daysWorked = new DataGridViewTextBoxColumn();
            pathDisplayLabel = new Label();
            headerPanel = new Panel();
            headerControlPanel = new Panel();
            btnClose = new Button();
            btnMinimize = new Button();
            btnAddFile = new Button();
            includeHeadersCheckBox = new CheckBox();
            toolTip1 = new ToolTip(components);
            dataGridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            headerPanel.SuspendLayout();
            headerControlPanel.SuspendLayout();
            SuspendLayout();
            // 
            // pathLabel
            // 
            pathLabel.AutoSize = true;
            pathLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            pathLabel.ForeColor = Color.FromArgb(251, 234, 235);
            pathLabel.Location = new Point(14, 45);
            pathLabel.Name = "pathLabel";
            pathLabel.Size = new Size(72, 21);
            pathLabel.TabIndex = 0;
            pathLabel.Text = "File path:";
            // 
            // dataGridPanel
            // 
            dataGridPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridPanel.BackColor = Color.FromArgb(251, 234, 235);
            dataGridPanel.Controls.Add(dataGridView);
            dataGridPanel.Location = new Point(18, 129);
            dataGridPanel.Name = "dataGridPanel";
            dataGridPanel.Size = new Size(629, 434);
            dataGridPanel.TabIndex = 2;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.BackgroundColor = Color.FromArgb(251, 234, 235);
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.AliceBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(255, 192, 192);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.MenuText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { firstEmpColumn, secondEmpColumn, projectIdColumn, daysWorked });
            dataGridView.GridColor = Color.FromArgb(47, 60, 126);
            dataGridView.Location = new Point(38, 22);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(562, 153);
            dataGridView.TabIndex = 0;
            // 
            // firstEmpColumn
            // 
            firstEmpColumn.HeaderText = "Employee ID #1";
            firstEmpColumn.MinimumWidth = 50;
            firstEmpColumn.Name = "firstEmpColumn";
            firstEmpColumn.ReadOnly = true;
            firstEmpColumn.Resizable = DataGridViewTriState.False;
            firstEmpColumn.Width = 130;
            // 
            // secondEmpColumn
            // 
            secondEmpColumn.HeaderText = "Employee ID #2";
            secondEmpColumn.MinimumWidth = 50;
            secondEmpColumn.Name = "secondEmpColumn";
            secondEmpColumn.ReadOnly = true;
            secondEmpColumn.Width = 130;
            // 
            // projectIdColumn
            // 
            projectIdColumn.HeaderText = "Project ID";
            projectIdColumn.MinimumWidth = 50;
            projectIdColumn.Name = "projectIdColumn";
            projectIdColumn.ReadOnly = true;
            projectIdColumn.Width = 130;
            // 
            // daysWorked
            // 
            daysWorked.HeaderText = "Days Worked";
            daysWorked.MinimumWidth = 50;
            daysWorked.Name = "daysWorked";
            daysWorked.ReadOnly = true;
            daysWorked.Width = 130;
            // 
            // pathDisplayLabel
            // 
            pathDisplayLabel.AutoSize = true;
            pathDisplayLabel.BackColor = Color.FromArgb(251, 234, 235);
            pathDisplayLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            pathDisplayLabel.Location = new Point(18, 67);
            pathDisplayLabel.MaximumSize = new Size(400, 20);
            pathDisplayLabel.MinimumSize = new Size(200, 20);
            pathDisplayLabel.Name = "pathDisplayLabel";
            pathDisplayLabel.Size = new Size(200, 20);
            pathDisplayLabel.TabIndex = 3;
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(headerControlPanel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(659, 33);
            headerPanel.TabIndex = 4;
            headerPanel.MouseDown += headerPanel_MouseDown;
            // 
            // headerControlPanel
            // 
            headerControlPanel.Controls.Add(btnClose);
            headerControlPanel.Controls.Add(btnMinimize);
            headerControlPanel.Dock = DockStyle.Right;
            headerControlPanel.Location = new Point(581, 0);
            headerControlPanel.Name = "headerControlPanel";
            headerControlPanel.Size = new Size(78, 33);
            headerControlPanel.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(47, 60, 126);
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(251, 234, 235);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Image = (Image)resources.GetObject("btnClose.Image");
            btnClose.Location = new Point(41, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(32, 27);
            btnClose.TabIndex = 2;
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.BackColor = Color.FromArgb(47, 60, 126);
            btnMinimize.FlatAppearance.BorderColor = Color.FromArgb(251, 234, 235);
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Image = (Image)resources.GetObject("btnMinimize.Image");
            btnMinimize.Location = new Point(3, 3);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(32, 27);
            btnMinimize.TabIndex = 0;
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnAddFile
            // 
            btnAddFile.BackColor = Color.FromArgb(251, 234, 235);
            btnAddFile.FlatAppearance.BorderSize = 0;
            btnAddFile.Location = new Point(18, 90);
            btnAddFile.Name = "btnAddFile";
            btnAddFile.Size = new Size(75, 23);
            btnAddFile.TabIndex = 5;
            btnAddFile.Text = "AddFile";
            btnAddFile.UseVisualStyleBackColor = false;
            btnAddFile.Click += btnAddFile_Click;
            // 
            // includeHeadersCheckBox
            // 
            includeHeadersCheckBox.AutoSize = true;
            includeHeadersCheckBox.BackColor = Color.FromArgb(47, 60, 126);
            includeHeadersCheckBox.ForeColor = Color.FromArgb(251, 234, 235);
            includeHeadersCheckBox.Location = new Point(104, 93);
            includeHeadersCheckBox.Name = "includeHeadersCheckBox";
            includeHeadersCheckBox.Size = new Size(97, 19);
            includeHeadersCheckBox.TabIndex = 6;
            includeHeadersCheckBox.Text = "With Headers";
            toolTip1.SetToolTip(includeHeadersCheckBox, "Indicates whether the .csv file contains headers or not.");
            includeHeadersCheckBox.UseVisualStyleBackColor = false;
            // 
            // toolTip1
            // 
            toolTip1.BackColor = Color.Lavender;
            toolTip1.ForeColor = Color.Lavender;
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Title of tooltip";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(47, 60, 126);
            ClientSize = new Size(659, 575);
            Controls.Add(includeHeadersCheckBox);
            Controls.Add(btnAddFile);
            Controls.Add(headerPanel);
            Controls.Add(pathDisplayLabel);
            Controls.Add(dataGridPanel);
            Controls.Add(pathLabel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Common Projects";
            dataGridPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            headerPanel.ResumeLayout(false);
            headerControlPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label pathLabel;
        private Panel dataGridPanel;
        private DataGridView dataGridView;
        private DataGridViewTextBoxColumn firstEmpColumn;
        private DataGridViewTextBoxColumn secondEmpColumn;
        private DataGridViewTextBoxColumn projectIdColumn;
        private DataGridViewTextBoxColumn daysWorked;
        private Label pathDisplayLabel;
        private Panel headerPanel;
        private Panel headerControlPanel;
        private Button btnMinimize;
        private Button btnClose;
        private Button btnAddFile;
        private CheckBox includeHeadersCheckBox;
        private ToolTip toolTip1;
    }
}