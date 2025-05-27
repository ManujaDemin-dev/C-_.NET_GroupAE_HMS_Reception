using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BCrypt.Net;
using WindowsFormsApp1;

namespace TrustWell_Hospital
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(Login_Click);
        }
        private bool IsValidEmailSimple(string email)
        {
            //Check if there any empty or have empty spaces
            if (string.IsNullOrWhiteSpace(email) || email.Contains(" "))
                return false;

            //Find where the "@" and last "."
            int atIndex = email.IndexOf("@");
            int dotIndex = email.LastIndexOf(".");

            if (atIndex < 1 || dotIndex < atIndex + 2 || dotIndex == email.Length - 1)
                return false;

            //only one from this @
            if (email.LastIndexOf("@") != atIndex)
                return false;

            //check the valid sysmbols,letters,characters
            foreach (char c in email)
            {
                if (!char.IsLetterOrDigit(c) && c != '@' && c != '.' && c != '-' && c != '_' && c != '+')
                    return false;
            }

            return true;
        }

        private bool IsValidPassword(string password)
        {
            return!string.IsNullOrWhiteSpace(password) && password.Length >= 3;
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{

        //}
        private void Login_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string password = textBox2.Text;
            
            //paste inside the button click
            if (!IsValidEmailSimple(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidPassword(password))
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        

            try
            {
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@Email", email)
                };

                string query = "SELECT * FROM Users WHERE Role = 'Receptionist' AND Email = @Email";
                DataTable result = Database.ExecuteQuery(query, parameters);

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow row = result.Rows[0];
                string storedPassword = row["Password"].ToString();
                int userId = Convert.ToInt32(row["Userid"]);
                string username = row["Username"].ToString();
                string role = row["Role"].ToString();
                string staffId = row["StaffID"].ToString();

                if (BCrypt.Net.BCrypt.Verify(password, storedPassword))
                {
                
                    UserSession.UserId = userId;
                    UserSession.Username = username;
                    UserSession.Role = role;
                    UserSession.StaffId = staffId;

                    
                    LogUserActivity(staffId);

                    
                   this.Hide();
                   DashboardForm dashboard = new DashboardForm();
                   dashboard.FormClosed += (s, args) => this.Close(); 
                   dashboard.Show();

                }
                else
                {
                    MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogUserActivity(string staffId)
        {
            string activityQuery = "INSERT INTO login_activity (application, login_time, StaffID) VALUES ('Receptionist', NOW(), @StaffID)";
            MySqlParameter[] parameters =
            {
                //new MySqlParameter("@UserId", userId),
                new MySqlParameter("@StaffID", staffId)
            };

            Database.ExecuteNonQuery(activityQuery, parameters);
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cuiLabel1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cuiPictureBox1_Load(object sender, EventArgs e)
        {

        }
    }
}
