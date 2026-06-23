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
            lblTitle = new Label();
            cmbModule = new ComboBox();
            lblModule = new Label();
            txtName = new TextBox();
            lblName = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            dgvMaintenance = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMaintenance).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(292, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(222, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Maintenance Module";
            // 
            // cmbModule
            // 
            cmbModule.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbModule.FormattingEnabled = true;
            cmbModule.Location = new Point(229, 139);
            cmbModule.Name = "cmbModule";
            cmbModule.Size = new Size(121, 23);
            cmbModule.TabIndex = 1;
            cmbModule.SelectedIndexChanged += cmbModule_SelectedIndexChanged;
            // 
            // lblModule
            // 
            lblModule.AutoSize = true;
            lblModule.Location = new Point(169, 142);
            lblModule.Name = "lblModule";
            lblModule.Size = new Size(54, 15);
            lblModule.TabIndex = 2;
            lblModule.Text = "Module: ";
            // 
            // txtName
            // 
            txtName.Location = new Point(229, 168);
            txtName.Name = "txtName";
            txtName.Size = new Size(250, 23);
            txtName.TabIndex = 3;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(169, 176);
            lblName.Name = "lblName";
            lblName.Size = new Size(45, 15);
            lblName.TabIndex = 4;
            lblName.Text = "Name: ";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(200, 225);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(300, 225);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(400, 225);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(500, 225);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 5;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // dgvMaintenance
            // 
            dgvMaintenance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaintenance.Dock = DockStyle.Bottom;
            dgvMaintenance.Location = new Point(0, 261);
            dgvMaintenance.MultiSelect = false;
            dgvMaintenance.Name = "dgvMaintenance";
            dgvMaintenance.ReadOnly = true;
            dgvMaintenance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaintenance.Size = new Size(884, 300);
            dgvMaintenance.TabIndex = 6;
            dgvMaintenance.CellContentClick += dgvMaintenance_CellContentClick;
            // 
            // DepartmentManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(dgvMaintenance);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblModule);
            Controls.Add(cmbModule);
            Controls.Add(lblTitle);
            Name = "DepartmentManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Maintenance Module";
            ((System.ComponentModel.ISupportInitialize)dgvMaintenance).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private ComboBox cmbModule;
        private Label lblModule;
        private TextBox txtName;
        private Label lblName;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvMaintenance;
    }
}