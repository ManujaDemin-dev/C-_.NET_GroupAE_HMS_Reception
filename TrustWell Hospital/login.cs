using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace TrustWell_Hospital_Doctor
{
    public partial class login: Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {


            string email = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@Email", email)
                };

                string query = "SELECT * FROM Doctors WHERE Email = @Email";
                DataTable result = Database.ExecuteQuery(query, parameters);

                if (result.Rows.Count == 0)
                {
                    MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow row = result.Rows[0];
                string storedPassword = row["Password"].ToString();
                int DocId = Convert.ToInt32(row["DoctorID"]);
                string username = row["DoctorName"].ToString();
                //string role = row["Role"].ToString();
                //string staffId = row["StaffID"].ToString();

                if (BCrypt.Net.BCrypt.Verify(password, storedPassword))
                {

                    UserSession.DocId = DocId;
                    UserSession.Username = username;
                


                    LogUserActivity(DocId);


                    this.Hide();
                    Dashbord dashboard = new Dashbord();
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

        private void LogUserActivity(int DocId)
        {
            string activityQuery = "INSERT INTO login_activity (application, login_time, DoctorID) VALUES ('Doctor', NOW(), @DoctorID)";
            MySqlParameter[] parameters =
            {
                //new MySqlParameter("@UserId", userId),
                new MySqlParameter("@DoctorID", DocId)
            };

            Database.ExecuteNonQuery(activityQuery, parameters);

        }
    }
}
