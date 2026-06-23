using Group1_GUI_DB_OOP_Final_Project.Services.HRServices;
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
        public bool isEdit = false;
        public int vacancyId = 0;

        private int _jobVacancyId;
        private JobVacancyService _service = new JobVacancyService();

        public AddOrEditForm(int jobVacancyId)
        {
            InitializeComponent();
            _jobVacancyId = jobVacancyId;
        }
        public AddOrEditForm()
        {
            InitializeComponent();
        }

        private void AddOrEditForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJobTitle.Text))
            {
                MessageBox.Show("Job Title is required.");
                return;
            }

            if (_jobVacancyId == 0)
            {
                _service.AddVacancy(
                    txtJobTitle.Text,
                    txtJobDescription.Text,
                    txtQualifications.Text,
                    (int)cmbDepartment.SelectedValue,
                    (int)cmbEmploymentType.SelectedValue
                );

                MessageBox.Show("Job added successfully!");
            }
            else
            {
                _service.UpdateVacancy(
                    _jobVacancyId,
                    txtJobTitle.Text,
                    txtJobDescription.Text,
                    txtQualifications.Text,
                    (int)cmbDepartment.SelectedValue,
                    (int)cmbEmploymentType.SelectedValue
                );

                MessageBox.Show("Job updated successfully!");
            }

            this.Close();
        }
    }
}
