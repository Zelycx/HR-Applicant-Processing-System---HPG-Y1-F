using Group1_GUI_DB_OOP_Final_Project.DTOs;
using Group1_GUI_DB_OOP_Final_Project.Forms.HR;
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

namespace Group1_GUI_DB_OOP_Final_Project.Forms.HR_Staff.Screening
{
    public partial class ScreeningForm : Form
    {
        private readonly int _applicationID;
        private readonly HRScreeningService _screeningService;

        public ScreeningForm(int applicationID)
        {
            InitializeComponent();

            _applicationID = applicationID;
            _screeningService = new HRScreeningService();
        }

        private void SaveScreening_Click(object sender, EventArgs e)
        {
            try
            {
                string screeningStatus;
                string remarks = RemarksTextBox.Text.Trim();

                // Validate radio buttons
                if (QualifiedRadioButton.Checked)
                {
                    screeningStatus = "Qualified";
                }
                else if (NotQualifiedRadioButton.Checked)
                {
                    screeningStatus = "Not Qualified";
                }
                else
                {
                    MessageBox.Show(
                        "Please select a screening decision.",
                        "Validation",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // TODO: replace with logged-in HR user ID
                int screenedByUserID = 1;

                _screeningService.SaveScreeningDecision(
                    _applicationID,
                    screenedByUserID,
                    screeningStatus,
                    remarks
                );

                MessageBox.Show(
                    "Screening result saved successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                new ApplicantList().Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            new ApplicantList().Show();
            Close();
        }
    }
}
