using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1;

namespace TrustWell_Hospital
{
    public partial class PatientMiniPage : Form
    {
        private int patientID;

        public PatientMiniPage(int id)
        {
            InitializeComponent();
            patientID = id;
            LoadPatientDetails();
        }

        private void PatientMiniPage_Load(object sender, EventArgs e)
        {
            // You can leave this empty or use it for future enhancements
        }

        private void LoadPatientDetails()
        {
            MySqlParameter[] parameters = {
                new MySqlParameter("@id", patientID)
            };

            // Load Patient Information
            string query = "SELECT * FROM Patients WHERE PatientID = @id";

            try
            {
                DataTable dt = Database.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    lblName.Text = "Name           : " + row["PatientName"].ToString();
                    lblNIC.Text = "NIC        : " + row["patientNIC"].ToString();
                    lblGender.Text = "Gender  : " + row["Gender"].ToString();
                    lblDOB.Text = "DOB        : " + Convert.ToDateTime(row["DateOfBirth"]).ToString("yyyy-MM-dd");
                    lblContact.Text = "Phone     : " + row["ContactNumber"].ToString();
                    lblEmail.Text = "Email       : " + row["Email"].ToString();
                    lblAddress.Text = "Address   : " + row["Address"].ToString();
                }

            }catch (Exception ex)
            {
                MessageBox.Show("Error! is from :::" + ex.Message);
            }

            // Load Guardian (Emergency Contact) Information
            
            try
            {
                string query1 = "SELECT * FROM EmergeencyContacts WHERE PatientID = @id";
                MySqlParameter[] parameter1 = {
                new MySqlParameter("@id", patientID)
            };
                DataTable guardianDt = Database.ExecuteQuery(query1, parameter1);


                if (guardianDt.Rows.Count > 0)
                {
                    DataRow row = guardianDt.Rows[0];

                    label2.Text = "Guardian Name : " + row["ContactName"].ToString();
                    label3.Text = "Gender           : " + row["Gender"].ToString();
                    label4.Text = "NIC                 : " + row["NIC"].ToString();
                    label5.Text = "Relationship  : " + row["Relationship"].ToString();
                    label6.Text = "Contact No    : " + row["ContactNumber"].ToString();
                    label7.Text = "Email                : " + row["Email"].ToString();

                }
                else
                {
                    MessageBox.Show("Guardian not found for patient ID = " + patientID);
                }

            }
            catch (Exception eg)
            {
                MessageBox.Show("Error form : " + eg.Message);
            }
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            // Open the UpdateInformation form and pass the patient ID
            UpdateInformation updateForm = new UpdateInformation(patientID);

           
            this.Close();
            updateForm.Show();
            
        }

        // You can remove or use these if you need custom label click events
        private void label1_Click(object sender, EventArgs e) { }
        private void labelName_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }

        private void lblGgender_Click(object sender, EventArgs e)
        {

        }

        private void lblGnic_Click(object sender, EventArgs e)
        {

        }
    }
}
