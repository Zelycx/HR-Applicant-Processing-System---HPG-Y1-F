using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Models;
using Group1_GUI_DB_OOP_Final_Project.Services.HRServices;
using Group1_GUI_DB_OOP_Final_Project.Services.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Group1_GUI_DB_OOP_Final_Project.Forms.HR_Manager.Job_Vacancies_Management_Form.AddOrEdit
{
    public partial class AddOrEditForm : Form
    {
        private readonly int _jobVacancyId;
        private readonly JobVacancyService _service = new JobVacancyService();

        // 0 = Add mode, any other value = Edit mode
        public AddOrEditForm(int jobVacancyId)
        {
            InitializeComponent();
            _jobVacancyId = jobVacancyId;
        }

        // ════════════════════════════════════════════════════════════
        //  FORM LOAD
        // ════════════════════════════════════════════════════════════

        private void AddOrEditForm_Load(object sender, EventArgs e)
        {
            LoadDropdowns();

            if (_jobVacancyId != 0)
            {
                this.Text = "Edit Job Vacancy";
                LoadVacancyForEdit();
            }
            else
            {
                this.Text = "Add Job Vacancy";
            }
        }

        // ════════════════════════════════════════════════════════════
        //  LOAD DROPDOWNS
        // ════════════════════════════════════════════════════════════

        private void LoadDropdowns()
        {
            // --- Departments ---
            var departments = _service.GetDepartments();
            cmbDepartment.DataSource = departments;
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";

            // --- Employment Types ---
            var empTypes = _service.GetEmploymentTypes();
            cmbEmploymentType.DataSource = empTypes;
            cmbEmploymentType.DisplayMember = "Name";
            cmbEmploymentType.ValueMember = "ID";

            // --- Required Documents (CheckedListBox) ---
            // ToString() on LookupDTO returns Name, so items display correctly
            var reqTypes = _service.GetRequirementTypes();
            clbRequirements.Items.Clear();
            foreach (var r in reqTypes)
                clbRequirements.Items.Add(r, false);
        }

        // ════════════════════════════════════════════════════════════
        //  EDIT MODE — pre-fill fields
        // ════════════════════════════════════════════════════════════

        private void LoadVacancyForEdit()
        {
            JobVacancyEditDTO vacancy = _service.GetVacancyForEdit(_jobVacancyId);

            if (vacancy == null)
            {
                MessageBox.Show("Vacancy not found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Text fields
            txtJobTitle.Text = vacancy.JobTitle;
            txtJobDescription.Text = vacancy.JobDescription;
            txtQualifications.Text = vacancy.Qualifications;

            // Pre-select Department
            for (int i = 0; i < cmbDepartment.Items.Count; i++)
            {
                if (((LookupDTO)cmbDepartment.Items[i]).ID == vacancy.DepartmentID)
                {
                    cmbDepartment.SelectedIndex = i;
                    break;
                }
            }

            // Pre-select Employment Type
            for (int i = 0; i < cmbEmploymentType.Items.Count; i++)
            {
                if (((LookupDTO)cmbEmploymentType.Items[i]).ID == vacancy.EmploymentTypeID)
                {
                    cmbEmploymentType.SelectedIndex = i;
                    break;
                }
            }

            // Tick already-required documents
            for (int i = 0; i < clbRequirements.Items.Count; i++)
            {
                LookupDTO item = (LookupDTO)clbRequirements.Items[i];
                clbRequirements.SetItemChecked(i, vacancy.RequirementTypeIDs.Contains(item.ID));
            }
        }

        // ════════════════════════════════════════════════════════════
        //  HELPERS
        // ════════════════════════════════════════════════════════════

        private List<int> GetCheckedRequirementIds()
        {
            var ids = new List<int>();
            foreach (LookupDTO item in clbRequirements.CheckedItems)
                ids.Add(item.ID);
            return ids;
        }

        // ════════════════════════════════════════════════════════════
        //  BUTTON EVENTS
        // ════════════════════════════════════════════════════════════

        private void btnSave_Click(object sender, EventArgs e)
        {
            // --- Validation ---
            if (string.IsNullOrWhiteSpace(txtJobTitle.Text))
            {
                MessageBox.Show("Job Title is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtJobTitle.Focus();
                return;
            }

            if (cmbDepartment.SelectedItem == null)
            {
                MessageBox.Show("Please select a Department.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDepartment.Focus();
                return;
            }

            if (cmbEmploymentType.SelectedItem == null)
            {
                MessageBox.Show("Please select an Employment Type.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEmploymentType.Focus();
                return;
            }

            // --- Collect values ---
            int departmentId = ((LookupDTO)cmbDepartment.SelectedItem).ID;
            int employmentTypeId = ((LookupDTO)cmbEmploymentType.SelectedItem).ID;
            List<int> reqIds = GetCheckedRequirementIds();

            try
            {
                if (_jobVacancyId == 0)
                {
                    // ADD MODE — requires logged-in HR user ID
                    int createdByUserId = SessionManager.CurrentHRUser.UserID;

                    _service.AddVacancy(
                        txtJobTitle.Text.Trim(),
                        txtJobDescription.Text.Trim(),
                        txtQualifications.Text.Trim(),
                        departmentId,
                        employmentTypeId,
                        createdByUserId,
                        reqIds
                    );

                    MessageBox.Show("Job vacancy added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // EDIT MODE
                    _service.UpdateVacancy(
                        _jobVacancyId,
                        txtJobTitle.Text.Trim(),
                        txtJobDescription.Text.Trim(),
                        txtQualifications.Text.Trim(),
                        departmentId,
                        employmentTypeId,
                        reqIds
                    );

                    MessageBox.Show("Job vacancy updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving vacancy:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
