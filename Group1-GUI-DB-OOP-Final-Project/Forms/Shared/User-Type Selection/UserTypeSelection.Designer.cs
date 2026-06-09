namespace Group1_GUI_DB_OOP_Final_Project.Forms.Shared.UserTypeSelection
{
    partial class UserTypeSelection
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
            ExitButton = new Button();
            panel1 = new Panel();
            HRButton = new Button();
            ApplicantButton = new Button();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            panel3 = new Panel();
            pictureBox2 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // ExitButton
            // 
            ExitButton.BackColor = Color.LightSteelBlue;
            ExitButton.FlatAppearance.BorderSize = 0;
            ExitButton.FlatAppearance.MouseOverBackColor = Color.LightSteelBlue;
            ExitButton.FlatStyle = FlatStyle.Flat;
            ExitButton.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ExitButton.ForeColor = Color.Black;
            ExitButton.Location = new Point(11, 10);
            ExitButton.Margin = new Padding(3, 2, 3, 2);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(108, 58);
            ExitButton.TabIndex = 0;
            ExitButton.Text = "EXIT";
            ExitButton.TextAlign = ContentAlignment.MiddleRight;
            ExitButton.UseVisualStyleBackColor = false;
            ExitButton.Click += ExitButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(HRButton);
            panel1.Controls.Add(ApplicantButton);
            panel1.Location = new Point(52, 230);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1578, 515);
            panel1.TabIndex = 1;
            // 
            // HRButton
            // 
            HRButton.BackColor = Color.LightBlue;
            HRButton.FlatAppearance.BorderSize = 0;
            HRButton.FlatAppearance.MouseOverBackColor = Color.CadetBlue;
            HRButton.FlatStyle = FlatStyle.Flat;
            HRButton.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HRButton.Location = new Point(866, 52);
            HRButton.Margin = new Padding(3, 2, 3, 2);
            HRButton.Name = "HRButton";
            HRButton.Size = new Size(620, 434);
            HRButton.TabIndex = 1;
            HRButton.Text = "HR PROFESSIONAL";
            HRButton.UseVisualStyleBackColor = false;
            HRButton.Click += HRButton_Click;
            // 
            // ApplicantButton
            // 
            ApplicantButton.BackColor = Color.White;
            ApplicantButton.FlatAppearance.BorderSize = 0;
            ApplicantButton.FlatAppearance.MouseOverBackColor = Color.Gray;
            ApplicantButton.FlatStyle = FlatStyle.Flat;
            ApplicantButton.Font = new Font("Cambria", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ApplicantButton.Location = new Point(101, 52);
            ApplicantButton.Margin = new Padding(3, 2, 3, 2);
            ApplicantButton.Name = "ApplicantButton";
            ApplicantButton.Size = new Size(620, 434);
            ApplicantButton.TabIndex = 0;
            ApplicantButton.Text = "APPLICANT";
            ApplicantButton.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.Screenshot_2026_06_03_083713_removebg_preview;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(499, 12);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(726, 214);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(ExitButton);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1664, 226);
            panel2.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightSlateGray;
            panel3.Location = new Point(54, 10);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(9, 58);
            panel3.TabIndex = 4;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.LightSteelBlue;
            pictureBox2.BackgroundImage = Properties.Resources._2367416_200;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(12, 10);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(43, 58);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // UserTypeSelection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1664, 775);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "UserTypeSelection";
            Text = "UserTypeSelection";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button ExitButton;
        private Panel panel1;
        private Button HRButton;
        private Button ApplicantButton;
        private PictureBox pictureBox1;
        private Panel panel2;
        private PictureBox pictureBox2;
        private Panel panel3;
    }
}