using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1;
using System.Text.RegularExpressions;

namespace TrustWell_Hospital
{
    public partial class Addpatients2 : UserControl
    {
        private string _name;
        private string _nic;
        public Addpatients2()
        {
            InitializeComponent();
        }
        public Addpatients2(string name, string nic)
        {
            InitializeComponent();
            _name = name;
            _nic = nic;

            // Display received data (for example in labels or textboxes)
            pName.Text = _name;
            NIC.Text = _nic;
        }
        private void Addpatients2_Load(object sender, EventArgs e)
        {
            dob.Format = DateTimePickerFormat.Custom;
            dob.CustomFormat = " "; // blank
        }

        private void dob_ValueChanged(object sender, EventArgs e)
        {
            this.dob.Format = DateTimePickerFormat.Custom;
            this.dob.CustomFormat = "yyyy - MMM - dd";
        }
        private void submit_Click_1(object sender, EventArgs e)
        {
            //validation
            if (string.IsNullOrWhiteSpace(pName.Text))
            {
                MessageBox.Show("Please enter the patient's name.");
                pName.Focus();
                return;
            }

            if (this.gender.SelectedIndex == -1)
            {
                MessageBox.Show("Please select gender.");
                this.gender.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(this.address.Text))
            {
                MessageBox.Show("Please enter the patient's address.");
                this.address.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(this.phone.Text))
            {
                MessageBox.Show("Please enter the patient's phone number.");
                this.phone.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(this.email.Text))
            {
                MessageBox.Show("Please enter the patient's email.");
                this.email.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(this.NIC.Text))
            {
                MessageBox.Show("Please enter the patient's email.");
                this.NIC.Focus();
                return;
            }

            if (!this.dob.Checked)
            {
                MessageBox.Show("Please select date of birth.");
                this.dob.Focus();
                return;
            }


            if (!this.phone.Text.All(char.IsDigit) || this.phone.Text.Length != 10)
            {
                MessageBox.Show("Please enter a valid phone number.");
                this.phone.Focus();
                return;
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            bool isValidEmail = Regex.IsMatch(this.email.Text, emailPattern);

            if (!isValidEmail)
            {
                MessageBox.Show("Please enter a valid email address.");
                this.email.Focus();
                return;
            }




            string name = this.pName.Text.Trim();
            string dob = this.dob.Value.ToString("yyyy-MM-dd");
            string gender = this.gender.SelectedItem.ToString();
            string address = this.address.Text.Trim();
            string phone = this.phone.Text.Trim();
            string email = this.email.Text.Trim();
            string NIC = this.NIC.Text.Trim();

            string gName = this.gName.Text.Trim();
            string gPhone = this.contact.Text.Trim();
            string gGender = this.gGender.SelectedItem != null ? this.gGender.SelectedItem.ToString() : null;
            string relation = this.relation.Text.Trim();
            string Gemail = this.gEmail.Text.Trim();
            string gNIC = this.gNIC.Text.Trim();


            bool anyGuardianInfoFilled =
                !string.IsNullOrWhiteSpace(gName) ||
                !string.IsNullOrWhiteSpace(relation) ||
                !string.IsNullOrWhiteSpace(gPhone) ||
                !string.IsNullOrWhiteSpace(gNIC) ||
                !string.IsNullOrWhiteSpace(Gemail) ||
                !string.IsNullOrWhiteSpace(gGender);

            bool allGuardianInfoFilled =
                !string.IsNullOrWhiteSpace(gName) &&
                !string.IsNullOrWhiteSpace(relation) &&
                !string.IsNullOrWhiteSpace(gPhone) &&
                !string.IsNullOrWhiteSpace(gNIC) &&
                !string.IsNullOrWhiteSpace(Gemail) &&
                !string.IsNullOrWhiteSpace(gGender);

            if (anyGuardianInfoFilled && !allGuardianInfoFilled)
            {
                MessageBox.Show("Please fill in all guardian fields or leave them all empty.");
                return;
            }

            if (allGuardianInfoFilled)
            {

                if (!this.contact.Text.All(char.IsDigit) || this.contact.Text.Length != 10)
                {
                    MessageBox.Show("Please enter a valid guardian phone number.");
                    this.contact.Focus();
                    return;
                }

                bool isGuardianEmailValid = Regex.IsMatch(this.gEmail.Text, emailPattern);
                if (!isGuardianEmailValid)
                {
                    MessageBox.Show("Please enter a valid guardian email address.");
                    this.gEmail.Focus();
                    return;
                }


            }




            try
            {
                string query = @"INSERT INTO Patients (PatientName, patientNIC, Gender, DateOfBirth, ContactNumber, Email, Address)
                     VALUES (@name, @nic, @gender, @dob, @contact, @email, @address)";

                MySqlParameter[] parameters = {
                    new MySqlParameter("@name", name),
                    new MySqlParameter("@nic", NIC),
                    new MySqlParameter("@gender", gender),
                    new MySqlParameter("@dob", dob),
                    new MySqlParameter("@contact", phone),
                    new MySqlParameter("@email", email),
                    new MySqlParameter("@address",address)
                };

                Database.ExecuteNonQuery(query, parameters);
                MessageBox.Show("Patient added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //retreiving patient id

                string getIdQuery = "SELECT PatientID FROM Patients WHERE patientNIC = @nic";
                MySqlParameter[] getIdParams = {
                    new MySqlParameter("@nic", NIC)
                };

                DataTable result = Database.ExecuteQuery(getIdQuery, getIdParams);

                int patientId = 0;
                if (result.Rows.Count > 0)
                {
                    patientId = int.Parse(result.Rows[0]["PatientID"].ToString());
                    //MessageBox.Show("id fetched");

                }


                //check if emergency contact details are available

                if (allGuardianInfoFilled)
                {

                    // Insert the emergency contact data into the database

                    string ecQuery = @"INSERT INTO EmergeencyContacts (PatientID, ContactName, Gender, Relationship, NIC, ContactNumber, Email)
                           VALUES (@pid, @ecName, @ecGender, @relation, @ecNIC, @ecContact, @ecEmail)";

                    MySqlParameter[] ecParams = {
                        new MySqlParameter("@pid", patientId),
                        new MySqlParameter("@ecName", gName),
                        new MySqlParameter("@ecGender", gGender),
                        new MySqlParameter("@relation", relation),
                        new MySqlParameter("@ecNIC", gNIC),
                        new MySqlParameter("@ecContact", gPhone),
                        new MySqlParameter("@ecEmail",  Gemail)
                    };

                    Database.ExecuteNonQuery(ecQuery, ecParams);
                    MessageBox.Show("Guardian details added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }




            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for age or contact fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

