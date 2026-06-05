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
            Application.Run(new LoginForm());
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
    static class MockDB
    {
        public static string Email = "";
        public static string Password = "";
        public static string FirstName = "";
        public static string LastName = "";
        public static string Phone = "";
        public static string Address = "";
        public static bool IsLoggedIn = false;

        public static bool Login(string email, string password)
            => email == Email && password == Password && Email != "";

        public static bool Register(string email, string password,
                                    string firstName, string lastName)
        {
            if (Email != "") return false;
            Email = email; Password = password;
            FirstName = firstName; LastName = lastName;
            return true;
        }

        public static void SaveProfile(string first, string last,
                                       string phone, string address)
        {
            FirstName = first; LastName = last;
            Phone = phone; Address = address;
        }
    }
    class LoginForm : Form
    {
        TextBox txtEmail = null!;
        TextBox txtPassword = null!;
        Label lblError = null!;

        public LoginForm()
        {
            UI.StyleForm(this, "Applicant Portal – Login");
            BuildUI();
        }

        void BuildUI()
        {
            var header = new Panel { Dock = DockStyle.Top, Height = 80, BackColor = UI.Primary };
            var lblTitle = new Label
            {
                Text = "Applicant Portal",
                Font = UI.TitleFont,
                ForeColor = UI.White,
                AutoSize = true,
                Location = new Point(24, 22)
            };
            header.Controls.Add(lblTitle);
            Controls.Add(header);

            var card = UI.MakeCard(400, 360);
            card.Location = new Point(40, 108);
            Controls.Add(card);

            int y = 10;
            card.Controls.Add(UI.MakeLabel("APPLICANT LOGIN", UI.TitleFont, UI.Primary)
                .Positioned(0, y));
            y += 46;

            card.Controls.Add(UI.MakeLabel("Email Address").Positioned(0, y));
            y += 20;
            txtEmail = UI.MakeInput();
            txtEmail.Width = 352; txtEmail.Location = new Point(0, y);
            card.Controls.Add(txtEmail);
            y += 42;

            card.Controls.Add(UI.MakeLabel("Password").Positioned(0, y));
            y += 20;
            var pwWrapper = UI.MakePasswordField(352, out txtPassword);
            pwWrapper.Location = new Point(0, y);
            card.Controls.Add(pwWrapper);
            y += 46;

            var btnLogin = UI.MakeButton("LOGIN", UI.Primary, UI.White);
            btnLogin.Width = 352; btnLogin.Location = new Point(0, y);
            btnLogin.Click += BtnLogin_Click;
            card.Controls.Add(btnLogin);
            y += 48;

            lblError = UI.MakeLabel("", UI.SmallFont, UI.Danger);
            lblError.Location = new Point(0, y);
            card.Controls.Add(lblError);

            var linkLbl = new LinkLabel
            {
                Text = "Don't have an account? Register here",
                Font = UI.SmallFont,
                Location = new Point(40, 468),
                AutoSize = true
            };
            linkLbl.LinkClicked += (s, e) => new RegistrationForm().Show();
            Controls.Add(linkLbl);
        }
        void BtnLogin_Click(object? s, EventArgs e)
        {
            lblError.Text = "";
            string email = txtEmail.Text.Trim();
            string pwd = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pwd))
            { lblError.Text = "Please enter your email and password."; return; }

            if (MockDB.Login(email, pwd))
            {
                MockDB.IsLoggedIn = true;
                new DashboardForm().Show();
                Hide();
            }
            else
            {
                lblError.Text = "Invalid email or password.";
            }
        }
    }
    class RegistrationForm : Form
    {
        TextBox txtFirst = null!;
        TextBox txtLast = null!;
        TextBox txtEmail = null!;
        TextBox txtPwd = null!;
        TextBox txtConfirm = null!;
        Label lblMsg = null!;

        public RegistrationForm()
        {
            UI.StyleForm(this, "Applicant Portal – Register", 480, 610);
            BuildUI();
        }

        void BuildUI()
        {
            var header = new Panel { Dock = DockStyle.Top, Height = 80, BackColor = UI.Accent };
            var lbl = new Label
            {
                Text = "Create Account",
                Font = UI.TitleFont,
                ForeColor = UI.White,
                AutoSize = true,
                Location = new Point(24, 22)
            };
            header.Controls.Add(lbl);
            Controls.Add(header);

            var card = UI.MakeCard(400, 440);
            card.Location = new Point(40, 98);
            Controls.Add(card);

            int y = 10;

            void TextField(string label, ref TextBox box, string initial = "")
            {
                card.Controls.Add(UI.MakeLabel(label).Positioned(0, y));
                y += 20;
                box = UI.MakeInput();
                box.Width = 352; box.Location = new Point(0, y); box.Text = initial;
                card.Controls.Add(box);
                y += 42;
            }

            void PwdField(string label, ref TextBox box)
            {
                card.Controls.Add(UI.MakeLabel(label).Positioned(0, y));
                y += 20;
                var wrap = UI.MakePasswordField(352, out box);
                wrap.Location = new Point(0, y);
                card.Controls.Add(wrap);
                y += 42;
            }

            TextField("First Name", ref txtFirst!);
            TextField("Last Name", ref txtLast!);
            TextField("Email Address", ref txtEmail!);
            PwdField("Password", ref txtPwd!);
            PwdField("Confirm Password", ref txtConfirm!);

            var btnReg = UI.MakeButton("CREATE ACCOUNT", UI.Accent, UI.White);
            btnReg.Width = 352; btnReg.Location = new Point(0, y);
            btnReg.Click += BtnRegister_Click;
            card.Controls.Add(btnReg);
            y += 48;

            lblMsg = UI.MakeLabel("", UI.SmallFont, UI.Danger);
            lblMsg.Location = new Point(0, y);
            card.Controls.Add(lblMsg);
        }

        void BtnRegister_Click(object? s, EventArgs e)
        {
            lblMsg.ForeColor = UI.Danger;
            string first = txtFirst.Text.Trim();
            string last = txtLast.Text.Trim();
            string email = txtEmail.Text.Trim();
            string pwd = txtPwd.Text;
            string confirm = txtConfirm.Text;

            if (string.IsNullOrEmpty(first) || string.IsNullOrEmpty(last) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pwd))
            { lblMsg.Text = "All fields are required."; return; }

            if (pwd != confirm)
            { lblMsg.Text = "Passwords do not match."; return; }

            bool ok = MockDB.Register(email, pwd, first, last);
            if (ok)
            {
                lblMsg.ForeColor = UI.Accent;
                lblMsg.Text = "✔ Account created! You may now log in.";
            }
            else
            {
                lblMsg.Text = "Registration failed. Email may already exist.";
            }
        }
    }
}