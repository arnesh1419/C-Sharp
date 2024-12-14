using System;
using System.Windows.Forms;

namespace SimpleLoginForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Hardcoded username and password for validation
            string correctUsername = "admin";
            string correctPassword = "password";

            // Get the input values
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Validate empty fields
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in both fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check credentials
            if (username == correctUsername && password == correctPassword)
            {
                MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // "Remember Me" functionality (basic example)
                if (chkRememberMe.Checked)
                {
                    MessageBox.Show("Remember Me selected!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Invalid credentials", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
