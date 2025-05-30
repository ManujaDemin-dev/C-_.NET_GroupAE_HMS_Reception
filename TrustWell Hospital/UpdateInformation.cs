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
            try
            {
                // --- Update Patient Table ---
                string updatePatientQuery = @"
            UPDATE Patients 
            SET PatientName = @name, 
                patientNIC = @nic, 
                Gender = @gender, 
                ContactNumber = @phone, 
                Email = @email, 
                Address = @address 
            WHERE PatientID = @id";

                MySqlParameter[] patientParams = {
            new MySqlParameter("@name", pName.Text.Trim()),
            new MySqlParameter("@nic", NIC.Text.Trim()),
            new MySqlParameter("@gender", pGender.Text.Trim()),
            new MySqlParameter("@phone", phone.Text.Trim()),
            new MySqlParameter("@email", email.Text.Trim()),
            new MySqlParameter("@address", address.Text.Trim()),
            new MySqlParameter("@id", patientID)
        };

                Database.ExecuteNonQuery(updatePatientQuery, patientParams);

                // --- Update Guardian Table ---
                string updateGuardianQuery = @"
            UPDATE EmergeencyContacts 
            SET ContactName = @gname, 
                Gender = @ggender, 
                NIC = @gnic, 
                Relationship = @relation, 
                ContactNumber = @gcontact, 
                Email = @gemail 
            WHERE PatientID = @id";

                MySqlParameter[] guardianParams = {
            new MySqlParameter("@gname", gName.Text.Trim()),
            new MySqlParameter("@ggender", gender.Text.Trim()),
            new MySqlParameter("@gnic", gNIC.Text.Trim()),
            new MySqlParameter("@relation", relation.Text.Trim()),
            new MySqlParameter("@gcontact", contact.Text.Trim()),
            new MySqlParameter("@gemail", gEmail.Text.Trim()),
            new MySqlParameter("@id", patientID)
        };

                Database.ExecuteNonQuery(updateGuardianQuery, guardianParams);

                // Success Message
                MessageBox.Show("Information successfully updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pName_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
