namespace Group1_GUI_DB_OOP_Final_Project.Forms.Shared.Confirmation
{
    partial class ConfirmationForm
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
            YesButton = new Button();
            NoButton = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            Message = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // YesButton
            // 
            YesButton.BackColor = Color.PaleGreen;
            YesButton.FlatAppearance.BorderSize = 0;
            YesButton.FlatAppearance.MouseOverBackColor = Color.Lime;
            YesButton.FlatStyle = FlatStyle.Flat;
            YesButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            YesButton.Location = new Point(24, 155);
            YesButton.Name = "YesButton";
            YesButton.Size = new Size(203, 62);
            YesButton.TabIndex = 1;
            YesButton.Text = "YES";
            YesButton.UseVisualStyleBackColor = false;
            YesButton.Click += YesButton_Click;
            // 
            // NoButton
            // 
            NoButton.BackColor = Color.LightCoral;
            NoButton.FlatAppearance.BorderSize = 0;
            NoButton.FlatAppearance.MouseOverBackColor = Color.Red;
            NoButton.FlatStyle = FlatStyle.Flat;
            NoButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            NoButton.Location = new Point(251, 155);
            NoButton.Name = "NoButton";
            NoButton.Size = new Size(201, 62);
            NoButton.TabIndex = 2;
            NoButton.Text = "NO";
            NoButton.UseVisualStyleBackColor = false;
            NoButton.Click += NoButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(YesButton);
            panel1.Controls.Add(NoButton);
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(474, 228);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(Message);
            panel2.Location = new Point(24, 17);
            panel2.Name = "panel2";
            panel2.Size = new Size(428, 116);
            panel2.TabIndex = 3;
            // 
            // Message
            // 
            Message.BackColor = Color.WhiteSmoke;
            Message.BorderStyle = BorderStyle.None;
            Message.Font = new Font("Cambria", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Message.Location = new Point(50, 46);
            Message.Name = "Message";
            Message.Size = new Size(321, 27);
            Message.TabIndex = 0;
            // 
            // ConfirmationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(478, 233);
            Controls.Add(panel1);
            Name = "ConfirmationForm";
            Text = "ConfirmationForm";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button YesButton;
        private Button NoButton;
        private Panel panel1;
        private Panel panel2;
        private TextBox Message;
    }
}