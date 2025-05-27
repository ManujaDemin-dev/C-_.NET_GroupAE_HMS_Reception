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

namespace TrustWell_Hospital
{
    public partial class Appoinmentscs : UserControl
    {
        public Appoinmentscs()
        {
            InitializeComponent();
            LoadAppointments(); // Load data from database when the control is initialized

            // Handle combo box data error to prevent crash when invalid value is selected
            gunaDataGridView1.DataError += gunaDataGridView1_DataError;
        }

        private void Appoinmentscs_Load(object sender, EventArgs e)
        {
            // Nothing is loaded here, handled in constructor
        }

        // This method loads all appointments from the database
        public void LoadAppointments()
        {
            string query = @"
                SELECT 
                    Appointments.AppointmentID, 
                    Patients.PatientID, 
                    Doctors.DoctorName, 
                    Appointments.AppointmentDate, 
                    Appointments.Appoinmentnumber, 
                    Appointments.Status
                FROM Appointments
                JOIN Patients ON Appointments.PatientID = Patients.PatientID
                JOIN Doctors ON Appointments.DoctorID = Doctors.DoctorID";

            try
            {
                // Execute the query to get appointments
                DataTable dt = Database.ExecuteQuery(query, null);

                // Replace  with "Cancelled" in the table before showing
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Status"]?.ToString() == "Completed")
                    {
                        row["Status"] = "Cancelled";
                    }
                }

                // Clear any existing columns before re-adding them
                gunaDataGridView1.Columns.Clear();
                gunaDataGridView1.AutoGenerateColumns = false;

                // Add Appointment ID column
                gunaDataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Appointment ID",
                    DataPropertyName = "AppointmentID",
                    Name = "AppointmentID"
                });

                // Add Patient ID column but keep it hidden
                DataGridViewTextBoxColumn patientIdCol = new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Patient ID",
                    DataPropertyName = "PatientID",
                    Name = "PatientID",
                    Visible = false // Hide from view
                };
                gunaDataGridView1.Columns.Add(patientIdCol);

                // Add Doctor Name column
                gunaDataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Doctor Name",
                    DataPropertyName = "DoctorName"
                });

                // Add Appointment Date column
                gunaDataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Date",
                    DataPropertyName = "AppointmentDate"
                });

                // Add Appointment Number column
                gunaDataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Number",
                    DataPropertyName = "Appoinmentnumber"
                });

                // Add Status column as ComboBox (Dropdown)
                DataGridViewComboBoxColumn statusCol = new DataGridViewComboBoxColumn()
                {
                    HeaderText = "Status",
                    Name = "Status",
                    DataPropertyName = "Status", // binds to Status in DataTable
                    FlatStyle = FlatStyle.Flat
                };

                // Add only these two options to the combo box
                statusCol.Items.Add("Scheduled");
                statusCol.Items.Add("Cancelled");

                gunaDataGridView1.Columns.Add(statusCol); // Add the combo box column

                // Add Update button column
                DataGridViewButtonColumn updateBtn = new DataGridViewButtonColumn()
                {
                    HeaderText = "Action",
                    Text = "Update",
                    UseColumnTextForButtonValue = true,
                    Name = "Update"
                };
                gunaDataGridView1.Columns.Add(updateBtn);

                // Set the data source of the grid to the loaded DataTable
                gunaDataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                // Show error if something goes wrong
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        // This method triggers when a cell is clicked
        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if clicked cell is in the Update column
            if (gunaDataGridView1.Columns[e.ColumnIndex].Name == "Update" && e.RowIndex >= 0)
            {
                gunaDataGridView1.EndEdit(); // Commit any edits

                // Get Appointment ID from selected row
                string appointmentID = gunaDataGridView1.Rows[e.RowIndex].Cells["AppointmentID"].Value.ToString();

                // Get selected status from combo box
                string newStatus = gunaDataGridView1.Rows[e.RowIndex].Cells["Status"].Value?.ToString();

                // Validation: status must not be empty
                if (string.IsNullOrWhiteSpace(newStatus))
                {
                    MessageBox.Show("Please select a valid status.");
                    return;
                }

                // Debug info for testing
                MessageBox.Show($"Updating Appointment ID: {appointmentID}\nNew Status: {newStatus}");

                // SQL query to update the appointment's status
                string updateQuery = "UPDATE Appointments SET Status = @status WHERE AppointmentID = @id";

                // Set query parameters
                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@status", newStatus),
                    new MySqlParameter("@id", appointmentID)
                };

                try
                {
                    // Run update query
                    Database.ExecuteNonQuery(updateQuery, parameters.ToArray());

                    // Show success message
                    MessageBox.Show("Status updated successfully!");

                    // Reload appointments to refresh the grid
                    LoadAppointments();
                }
                catch (Exception ex)
                {
                    // Show error if update fails
                    MessageBox.Show("Update Error: " + ex.Message);
                }
            }
        }

        // Prevent crash when invalid data is entered into combo box
        private void gunaDataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Invalid value in the Status column. Please ensure it matches the allowed list.");
            e.ThrowException = false;
        }
    }
}
