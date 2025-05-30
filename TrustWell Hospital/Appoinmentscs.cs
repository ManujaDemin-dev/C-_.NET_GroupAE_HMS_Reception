using System;
using System.Collections.Generic;
using System.Data;
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
            // Handled in constructor
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

                // Replace "Completed" with "Cancelled" before displaying
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

                // Appointment ID
                gunaDataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Appointment ID",
                    DataPropertyName = "AppointmentID",
                    Name = "AppointmentID"
                });

                // Patient ID (Hidden)
                gunaDataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Patient ID",
                    DataPropertyName = "PatientID",
                    Name = "PatientID",
                    Visible = false
                });

                // Doctor Name
                gunaDataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Doctor Name",
                    DataPropertyName = "DoctorName"
                });

                // Appointment Date
                gunaDataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Date",
                    DataPropertyName = "AppointmentDate"
                });

                // Appointment Number
                gunaDataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Number",
                    DataPropertyName = "Appoinmentnumber"
                });

                // Status ComboBox
                DataGridViewComboBoxColumn statusCol = new DataGridViewComboBoxColumn()
                {
                    HeaderText = "Status",
                    Name = "Status",
                    DataPropertyName = "Status",
                    FlatStyle = FlatStyle.Flat
                };
                statusCol.Items.Add("Scheduled");
                statusCol.Items.Add("Cancelled");
                gunaDataGridView1.Columns.Add(statusCol);

                // Update Button
                gunaDataGridView1.Columns.Add(new DataGridViewButtonColumn()
                {
                    HeaderText = "Action",
                    Text = "Update",
                    UseColumnTextForButtonValue = true,
                    Name = "Update"
                });

                // Set data source
                gunaDataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        // Handle clicks in the DataGridView
        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gunaDataGridView1.Columns[e.ColumnIndex].Name == "Update" && e.RowIndex >= 0)
            {
                gunaDataGridView1.EndEdit(); // Commit any edits

                // Get Appointment ID
                string appointmentID = gunaDataGridView1.Rows[e.RowIndex].Cells["AppointmentID"].Value.ToString();

                // Get new Status
                string newStatus = gunaDataGridView1.Rows[e.RowIndex].Cells["Status"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(newStatus))
                {
                    MessageBox.Show("Please select a valid status.");
                    return;
                }

                // Update query
                string updateQuery = "UPDATE Appointments SET Status = @status WHERE AppointmentID = @id";

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@status", newStatus),
                    new MySqlParameter("@id", appointmentID)
                };

                try
                {
                    Database.ExecuteNonQuery(updateQuery, parameters.ToArray());

                    MessageBox.Show("Status updated successfully!");
                    LoadAppointments(); // Refresh grid
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update Error: " + ex.Message);
                }
            }
        }

        // Handle DataError in ComboBox
        private void gunaDataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Invalid value in the Status column. Please ensure it matches the allowed list.");
            e.ThrowException = false;
        }
    }
}
