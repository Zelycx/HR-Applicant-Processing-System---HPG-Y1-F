namespace Group1_GUI_DB_OOP_Final_Project.Forms.Administrator
{
    partial class DepartmentManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            BackButton = new Button();
            label1 = new Label();
            SearchBox = new TextBox();
            label2 = new Label();
            DepartmentListView = new ListView();
            StatusComboBox = new ComboBox();
            AddDepartmentButton = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Controls.Add(BackButton);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-9, -5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1929, 152);
            panel1.TabIndex = 1;
            // 
            // BackButton
            // 
            BackButton.FlatAppearance.BorderColor = Color.White;
            BackButton.FlatAppearance.BorderSize = 2;
            BackButton.FlatStyle = FlatStyle.Flat;
            BackButton.Font = new Font("Century", 10.2F);
            BackButton.ForeColor = Color.White;
            BackButton.Location = new Point(1710, 17);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(189, 119);
            BackButton.TabIndex = 15;
            BackButton.Text = "BACK TO LIST";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(64, 45);
            label1.Name = "label1";
            label1.Size = new Size(709, 54);
            label1.TabIndex = 0;
            label1.Text = "DEPARTMENT MANAGEMENT";
            // 
            // SearchBox
            // 
            SearchBox.Font = new Font("Century", 12F);
            SearchBox.Location = new Point(163, 267);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(489, 32);
            SearchBox.TabIndex = 2;
            SearchBox.TextChanged += SearchBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century", 12F);
            label2.Location = new Point(71, 270);
            label2.Name = "label2";
            label2.Size = new Size(86, 23);
            label2.TabIndex = 3;
            label2.Text = "Search: ";
            // 
            // DepartmentListView
            // 
            DepartmentListView.Location = new Point(71, 330);
            DepartmentListView.Name = "DepartmentListView";
            DepartmentListView.Size = new Size(1646, 637);
            DepartmentListView.TabIndex = 4;
            DepartmentListView.UseCompatibleStateImageBehavior = false;
            // 
            // StatusComboBox
            // 
            StatusComboBox.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StatusComboBox.FormattingEnabled = true;
            StatusComboBox.Location = new Point(687, 268);
            StatusComboBox.Name = "StatusComboBox";
            StatusComboBox.Size = new Size(238, 31);
            StatusComboBox.TabIndex = 5;
            StatusComboBox.SelectedIndexChanged += StatusComboBox_SelectedIndexChanged;
            // 
            // AddDepartmentButton
            // 
            AddDepartmentButton.BackColor = Color.White;
            AddDepartmentButton.FlatStyle = FlatStyle.Flat;
            AddDepartmentButton.Location = new Point(1546, 251);
            AddDepartmentButton.Name = "AddDepartmentButton";
            AddDepartmentButton.Size = new Size(171, 65);
            AddDepartmentButton.TabIndex = 6;
            AddDepartmentButton.Text = "Add Department";
            AddDepartmentButton.UseVisualStyleBackColor = false;
            AddDepartmentButton.Click += AddDepartmentButton_Click;
            // 
            // DepartmentManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(AddDepartmentButton);
            Controls.Add(StatusComboBox);
            Controls.Add(DepartmentListView);
            Controls.Add(label2);
            Controls.Add(SearchBox);
            Controls.Add(panel1);
            Name = "DepartmentManagement";
            Text = "DepartmentManagement";
            Load += DepartmentManagement_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox SearchBox;
        private Label label2;
        private ListView DepartmentListView;
        private ComboBox StatusComboBox;
        private Button AddDepartmentButton;
        private Button BackButton;
    }
}