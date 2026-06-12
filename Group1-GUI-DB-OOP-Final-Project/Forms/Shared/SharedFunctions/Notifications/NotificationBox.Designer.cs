namespace Group1_GUI_DB_OOP_Final_Project.Forms.Shared.SharedFunctions.Notifications
{
    partial class NotificationBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationBox));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            OkayButton = new Button();
            MessageBox = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(MessageBox);
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(12, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(424, 86);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(16, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(119, 45);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(158, 23);
            label1.Name = "label1";
            label1.Size = new Size(115, 22);
            label1.TabIndex = 1;
            label1.Text = "Notification:";
            // 
            // OkayButton
            // 
            OkayButton.BackColor = Color.PowderBlue;
            OkayButton.FlatAppearance.BorderColor = Color.CadetBlue;
            OkayButton.FlatAppearance.BorderSize = 3;
            OkayButton.FlatStyle = FlatStyle.Flat;
            OkayButton.Font = new Font("Century", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OkayButton.Location = new Point(168, 164);
            OkayButton.Name = "OkayButton";
            OkayButton.Size = new Size(105, 42);
            OkayButton.TabIndex = 2;
            OkayButton.Text = "OK";
            OkayButton.UseVisualStyleBackColor = false;
            OkayButton.Click += OkayButton_Click;
            // 
            // MessageBox
            // 
            MessageBox.AutoSize = true;
            MessageBox.Font = new Font("Century", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MessageBox.Location = new Point(57, 30);
            MessageBox.Name = "MessageBox";
            MessageBox.Size = new Size(0, 22);
            MessageBox.TabIndex = 0;
            // 
            // NotificationBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(448, 223);
            Controls.Add(OkayButton);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Name = "NotificationBox";
            Text = "NotificationBox";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Button OkayButton;
        private Label MessageBox;
    }
}