namespace Group1_GUI_DB_OOP_Final_Project
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
        }
    }

    static class UI
    {
        public static Color Primary = Color.FromArgb(26, 86, 219);
        public static Color Accent = Color.FromArgb(16, 185, 129);
        public static Color Danger = Color.FromArgb(220, 38, 38);
        public static Color BgLight = Color.FromArgb(245, 247, 250);
        public static Color TextDark = Color.FromArgb(30, 30, 50);
        public static Color TextGray = Color.FromArgb(107, 114, 128);
        public static Color White = Color.White;

        public static Font TitleFont = new Font("Segoe UI", 18, FontStyle.Bold);
        public static Font LabelFont = new Font("Segoe UI", 9, FontStyle.Bold);
        public static Font InputFont = new Font("Segoe UI", 10);
        public static Font BtnFont = new Font("Segoe UI", 10, FontStyle.Bold);
        public static Font SmallFont = new Font("Segoe UI", 8);

        public static TextBox MakeInput(bool isPassword = false)
        {
            var tb = new TextBox
            {
                Font = InputFont,
                BorderStyle = BorderStyle.FixedSingle,
                Height = 32,
                BackColor = White,
                ForeColor = TextDark
            };
            if (isPassword) tb.PasswordChar = '●';
            return tb;
        }

        public static Panel MakePasswordField(int width, out TextBox passwordBox)
        {
            var tb = new TextBox
            {
                Font = InputFont,
                BorderStyle = BorderStyle.None,
                BackColor = White,
                ForeColor = TextDark,
                PasswordChar = '●',
                Location = new Point(4, 4),
                Width = width - 44,
                Height = 22
            };

            var btnEye = new Button
            {
                Text = "👁",
                Font = new Font("Segoe UI", 9),
                FlatStyle = FlatStyle.Flat,
                BackColor = White,
                ForeColor = TextGray,
                Width = 32,
                Height = 30,
                Location = new Point(width - 34, 0),
                Cursor = Cursors.Hand,
                TabStop = false
            };
            btnEye.FlatAppearance.BorderSize = 0;
            btnEye.FlatAppearance.MouseOverBackColor = Color.FromArgb(229, 231, 235);

            bool shown = false;
            btnEye.Click += (s, e) =>
            {
                shown = !shown;
                tb.PasswordChar = shown ? '\0' : '●';
                btnEye.Text = shown ? "🙈" : "👁";
                tb.Focus();
                tb.SelectionStart = tb.Text.Length;
            };

            var wrapper = new Panel
            {
                Width = width,
                Height = 30,
                BackColor = White,
                BorderStyle = BorderStyle.FixedSingle
            };
            wrapper.Controls.Add(tb);
            wrapper.Controls.Add(btnEye);

            passwordBox = tb;
            return wrapper;
        }

        public static Button MakeButton(string text, Color bg, Color fg)
        {
            var btn = new Button
            {
                Text = text,
                Font = BtnFont,
                BackColor = bg,
                ForeColor = fg,
                FlatStyle = FlatStyle.Flat,
                Height = 38,
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        public static Label MakeLabel(string text, Font? font = null, Color? color = null)
        {
            return new Label
            {
                Text = text,
                Font = font ?? LabelFont,
                ForeColor = color ?? TextDark,
                AutoSize = true
            };
        }

        public static Panel MakeCard(int w, int h)
        {
            return new Panel
            {
                Width = w,
                Height = h,
                BackColor = White,
                Padding = new Padding(24)
            };
        }

        public static void StyleForm(Form f, string title, int w = 480, int h = 560)
        {
            f.Text = title;
            f.ClientSize = new Size(w, h);
            f.BackColor = BgLight;
            f.FormBorderStyle = FormBorderStyle.FixedSingle;
            f.MaximizeBox = false;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Font = new Font("Segoe UI", 9);
        }
    }
}