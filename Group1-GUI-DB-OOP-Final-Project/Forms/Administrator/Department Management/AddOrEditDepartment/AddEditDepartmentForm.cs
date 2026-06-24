using Group1_GUI_DB_OOP_Final_Project.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group1_GUI_DB_OOP_Final_Project.Forms.Administrator.Department_Management.AddOrEditDepartment
{
    /// <summary>
    /// Add/Edit dialog for a single Department record.
    ///
    /// Pass no arguments (or departmentId = null) to add a new department.
    /// Pass an existing DepartmentID plus its current name/status to edit it.
    ///
    /// This form performs the INSERT/UPDATE itself and returns
    /// DialogResult.OK on success, so the caller just needs to refresh its
    /// list afterward:
    ///
    ///   using (var dlg = new AddEditDepartmentForm())
    ///   {
    ///       if (dlg.ShowDialog(this) == DialogResult.OK)
    ///           LoadDepartments();
    ///   }
    ///
    /// All controls are built in code (no Designer.cs needed) — this class
    /// can simply be added to the project as a plain .cs file.
    /// </summary>
    public partial class AddEditDepartmentForm : Form
    {
        private readonly DatabaseConnector _db = new DatabaseConnector();

        // null => Add mode. Otherwise holds the DepartmentID being edited.
        private readonly int? _departmentId;

        private Label lblName;
        private TextBox txtName;
        private CheckBox chkActive;
        private Label lblError;
        private Button btnSave;
        private Button btnCancel;

        public AddEditDepartmentForm(int? departmentId = null, string existingName = null, bool existingIsActive = true)
        {
            _departmentId = departmentId;

            BuildUi();

            Text = _departmentId.HasValue ? "Edit Department" : "Add Department";
            txtName.Text = existingName ?? string.Empty;
            chkActive.Checked = existingIsActive;
        }

        // ══════════════════════════════════════════════════════════
        //  UI SETUP
        // ══════════════════════════════════════════════════════════

        private void BuildUi()
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(360, 175);

            lblName = new Label
            {
                Text = "Department Name:",
                Location = new Point(20, 18),
                AutoSize = true
            };

            txtName = new TextBox
            {
                Location = new Point(20, 42),
                Width = 320,
                MaxLength = 100
            };

            chkActive = new CheckBox
            {
                Text = "Active",
                Location = new Point(20, 75),
                AutoSize = true,
                Checked = true
            };

            lblError = new Label
            {
                ForeColor = Color.Firebrick,
                Location = new Point(20, 102),
                Size = new Size(320, 32),
                Text = string.Empty
            };

            btnSave = new Button
            {
                Text = "Save",
                Location = new Point(170, 138),
                Width = 80
            };
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(260, 138),
                Width = 80,
                DialogResult = DialogResult.Cancel
            };

            Controls.AddRange(new Control[]
            {
                lblName, txtName, chkActive, lblError, btnSave, btnCancel
            });

            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }

        // ══════════════════════════════════════════════════════════
        //  SAVE
        // ══════════════════════════════════════════════════════════

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                lblError.Text = "Department name is required.";
                txtName.Focus();
                return;
            }

            if (name.Length > 100)
            {
                lblError.Text = "Department name is too long (max 100 characters).";
                return;
            }

            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();

                    // Duplicate name check (case-insensitive, excludes self when editing).
                    // departments.DepartmentName also has a UNIQUE key, so this is a
                    // friendly pre-check rather than the only safeguard.
                    string dupSql = @"SELECT COUNT(*) FROM departments
                                      WHERE LOWER(DepartmentName) = LOWER(@name)
                                      AND DepartmentID <> @id";
                    using (var dupCmd = new MySqlCommand(dupSql, conn))
                    {
                        dupCmd.Parameters.AddWithValue("@name", name);
                        dupCmd.Parameters.AddWithValue("@id", _departmentId ?? 0);
                        long dupCount = Convert.ToInt64(dupCmd.ExecuteScalar());
                        if (dupCount > 0)
                        {
                            lblError.Text = "A department with this name already exists.";
                            txtName.Focus();
                            return;
                        }
                    }

                    if (_departmentId.HasValue)
                    {
                        string updateSql = @"UPDATE departments
                                              SET DepartmentName = @name, IsActive = @active
                                              WHERE DepartmentID = @id";
                        using (var cmd = new MySqlCommand(updateSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@active", chkActive.Checked);
                            cmd.Parameters.AddWithValue("@id", _departmentId.Value);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string insertSql = @"INSERT INTO departments (DepartmentName, IsActive)
                                              VALUES (@name, @active)";
                        using (var cmd = new MySqlCommand(insertSql, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", name);
                            cmd.Parameters.AddWithValue("@active", chkActive.Checked);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to save department.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
