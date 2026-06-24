using Group1_GUI_DB_OOP_Final_Project.Forms.HR;
using Group1_GUI_DB_OOP_Final_Project.Forms.Administrator.Department_Management.AddOrEditDepartment;
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
using Group1_GUI_DB_OOP_Final_Project.Database;

namespace Group1_GUI_DB_OOP_Final_Project.Forms.Administrator
{
    public partial class DepartmentManagement : Form
    {
        private readonly DatabaseConnector _db = new DatabaseConnector();

        // In-memory cache so search/filter don't re-query the DB every keystroke
        private DataTable _departments = new DataTable();

        public DepartmentManagement()
        {
            InitializeComponent();
        }

        // ══════════════════════════════════════════════════════════
        //  FORM LOAD
        // ══════════════════════════════════════════════════════════

        private void DepartmentManagement_Load(object sender, EventArgs e)
        {
            SetupListView();
            SetupStatusComboBox();
            SetupContextMenu();
            LoadDepartments();
        }

        private void SetupListView()
        {
            DepartmentListView.View = View.Details;
            DepartmentListView.FullRowSelect = true;
            DepartmentListView.GridLines = true;
            DepartmentListView.Columns.Clear();

            DepartmentListView.Columns.Add("#", 45, HorizontalAlignment.Center);
            DepartmentListView.Columns.Add("Department Name", 320, HorizontalAlignment.Left);
            DepartmentListView.Columns.Add("Status", 110, HorizontalAlignment.Center);
        }

        private void SetupStatusComboBox()
        {
            StatusComboBox.Items.Clear();
            StatusComboBox.Items.AddRange(new object[] { "All Statuses", "Active", "Inactive" });
            StatusComboBox.SelectedIndex = 0;
        }

        // Right-click menu + double-click-to-edit, wired entirely in code so
        // it doesn't depend on anything from the Designer file.
        private void SetupContextMenu()
        {
            var menu = new ContextMenuStrip();

            var editItem = new ToolStripMenuItem("Edit Department");
            editItem.Click += (s, e) => EditSelectedDepartment();

            var toggleItem = new ToolStripMenuItem("Activate / Deactivate");
            toggleItem.Click += (s, e) => ToggleSelectedDepartmentStatus();

            var deleteItem = new ToolStripMenuItem("Delete Department");
            deleteItem.Click += (s, e) => DeleteSelectedDepartment();

            menu.Items.Add(editItem);
            menu.Items.Add(toggleItem);
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add(deleteItem);

            DepartmentListView.ContextMenuStrip = menu;
            DepartmentListView.MouseDown += DepartmentListView_MouseDown;
            DepartmentListView.DoubleClick += (s, e) => EditSelectedDepartment();
        }

        // Right-clicking a row should select it first, otherwise the context
        // menu would act on whatever was previously selected (or nothing).
        private void DepartmentListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = DepartmentListView.HitTest(e.Location);
                if (hit.Item != null)
                {
                    DepartmentListView.SelectedItems.Clear();
                    hit.Item.Selected = true;
                }
            }
        }

        // ══════════════════════════════════════════════════════════
        //  DATABASE
        // ══════════════════════════════════════════════════════════

        private void LoadDepartments()
        {
            try
            {
                using (MySqlConnection conn = _db.GetConnection())
                {
                    conn.Open();
                    string sql = @"SELECT DepartmentID, DepartmentName, IsActive
                                   FROM   departments
                                   ORDER  BY DepartmentName";

                    using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                    {
                        _departments.Clear();
                        da.Fill(_departments);
                    }
                }

                ApplyFilters(); // Render after loading
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load departments.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════
        //  FILTERING & RENDERING
        // ══════════════════════════════════════════════════════════

        private void ApplyFilters()
        {
            string search = SearchBox.Text.Trim().ToLowerInvariant();
            string statusFilter = StatusComboBox.SelectedItem?.ToString() ?? "All Statuses";

            DepartmentListView.BeginUpdate(); // Prevents flickering while rebuilding rows
            DepartmentListView.Items.Clear();

            int rowNum = 1;

            foreach (DataRow row in _departments.Rows)
            {
                string name = row["DepartmentName"].ToString();
                bool isActive = Convert.ToBoolean(row["IsActive"]);

                // ── Status filter ──
                if (statusFilter == "Active" && !isActive) continue;
                if (statusFilter == "Inactive" && isActive) continue;

                // ── Search filter (matches department name) ──
                if (!string.IsNullOrEmpty(search) &&
                    !name.ToLowerInvariant().Contains(search))
                    continue;

                // ── Build the row ──
                var item = new ListViewItem(rowNum.ToString());
                item.SubItems.Add(name);
                item.SubItems.Add(isActive ? "Active" : "Inactive");

                // Gray out inactive rows so they're visually distinct
                item.ForeColor = isActive ? DepartmentListView.ForeColor : Color.Gray;

                // Store the ID on the item so edit/delete can use it later
                item.Tag = Convert.ToInt32(row["DepartmentID"]);

                DepartmentListView.Items.Add(item);
                rowNum++;
            }

            DepartmentListView.EndUpdate();
        }

        // ══════════════════════════════════════════════════════════
        //  SELECTION HELPER
        // ══════════════════════════════════════════════════════════

        private bool TryGetSelectedDepartment(out int departmentId, out string name, out bool isActive)
        {
            departmentId = 0;
            name = null;
            isActive = false;

            if (DepartmentListView.SelectedItems.Count == 0)
            {
                MessageBox.Show(
                    "Please select a department first.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }

            var item = DepartmentListView.SelectedItems[0];
            departmentId = (int)item.Tag;
            name = item.SubItems[1].Text;
            isActive = item.SubItems[2].Text == "Active";
            return true;
        }

        // ══════════════════════════════════════════════════════════
        //  ADD / EDIT / DELETE / TOGGLE
        // ══════════════════════════════════════════════════════════



        private void EditSelectedDepartment()
        {
            if (!TryGetSelectedDepartment(out int id, out string name, out bool isActive))
                return;

            using (var dlg = new AddEditDepartmentForm(id, name, isActive))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    LoadDepartments();
            }
        }

        private void ToggleSelectedDepartmentStatus()
        {
            if (!TryGetSelectedDepartment(out int id, out string name, out bool isActive))
                return;

            bool newStatus = !isActive;
            string verb = newStatus ? "activate" : "deactivate";

            var confirm = MessageBox.Show(
                $"Are you sure you want to {verb} \"{name}\"?",
                "Confirm Status Change",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    string sql = "UPDATE departments SET IsActive = @active WHERE DepartmentID = @id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@active", newStatus);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to update department status.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DeleteSelectedDepartment()
        {
            if (!TryGetSelectedDepartment(out int id, out string name, out bool isActive))
                return;

            try
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();

                    // A department referenced by job vacancies can't be deleted
                    // (the FK constraint would reject it anyway) — check first
                    // so we can give a clear, friendly message instead of a
                    // raw SQL error.
                    string checkSql = "SELECT COUNT(*) FROM jobvacancies WHERE DepartmentID = @id";
                    using (var checkCmd = new MySqlCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@id", id);
                        long usageCount = Convert.ToInt64(checkCmd.ExecuteScalar());
                        if (usageCount > 0)
                        {
                            MessageBox.Show(
                                $"\"{name}\" cannot be deleted because it is used by {usageCount} job vacancy/vacancies.\n\n" +
                                "Deactivate the department instead if it should no longer be used for new postings.",
                                "Cannot Delete",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    var confirm = MessageBox.Show(
                        $"Are you sure you want to permanently delete \"{name}\"?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirm != DialogResult.Yes) return;

                    string deleteSql = "DELETE FROM departments WHERE DepartmentID = @id";
                    using (var cmd = new MySqlCommand(deleteSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to delete department.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ══════════════════════════════════════════════════════════
        //  EVENTS
        // ══════════════════════════════════════════════════════════

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters(); // Re-filter in-memory data — no extra DB call needed
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            HRDashboard hRDashboard = new HRDashboard();
            hRDashboard.Show();
            this.Close();
        }

        private void AddDepartmentButton_Click(object sender, EventArgs e)
        {
            using (var dlg = new AddEditDepartmentForm())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    LoadDepartments();
            }
        }
    }
}
