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

namespace TrustWell_Hospital
{
    public partial class UpdateInformation : Form
    {
        private int patientID;
        public UpdateInformation(int id)
        {
            InitializeComponent();
            patientID = id;
        }

        private void UpdateInformation_Load(object sender, EventArgs e)
        {
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

                        pName.Text = row["PatientName"].ToString();
                        NIC.Text = row["patientNIC"].ToString();
                        pGender.Text = row["Gender"].ToString();

                        phone.Text = row["ContactNumber"].ToString();
                        email.Text = row["Email"].ToString();
                        address.Text = row["Address"].ToString();
                    }

                }
                catch (Exception ex)
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

                        gName.Text = row["ContactName"].ToString();
                        gender.Text = row["Gender"].ToString();
                        gNIC.Text = row["NIC"].ToString();
                        relation.Text = row["Relationship"].ToString();
                        contact.Text = row["ContactNumber"].ToString();
                        gEmail.Text = row["Email"].ToString();

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

        }

        private void submit_Click(object sender, EventArgs e)
        {
        }
    }
}