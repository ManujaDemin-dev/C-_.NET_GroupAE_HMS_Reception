using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace TrustWell_Hospital
{
    public partial class view_btn_doc : Form
    {
        private int doctor_id;
        public view_btn_doc(int DOCID)
        {
            InitializeComponent();
            doctor_id = DOCID;
            LoadDoctorsDetails();
        }

        private void LoadDoctorsDetails()
        {
            string query = "SELECT d.DoctorID, d.DoctorName, s.Specialization, d.Fees, d.ContactNumber, GROUP_CONCAT(CONCAT( a.available_day, '(',a.start_time, '-' , a.end_time,')') ORDER BY a.available_day SEPARATOR ' ,') AS available_days FROM Doctors d JOIN Doc_specialization s ON d.specialization = s.specialization_id JOIN Doc_availability a ON d.DoctorID = a.DoctorID WHERE a.availablity = 'available' AND d.DoctorID = @DOCID GROUP BY d.DoctorID";
            MySqlParameter[] parameters = {
            new MySqlParameter("@DOCID", doctor_id)
        };

            DataTable dt = Database.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                label2.Text = "Doctor Name: " + row["DoctorName"].ToString();
                label6.Text = "Specialization :" + row["Specialization"].ToString();
                //label5.Text = "Doctor Id :" + row["DoctorID"].ToString();
                label4.Text = "Contact Infomation :" + row["ContactNumber"].ToString();
                label3.Text = "Doctor Fees :" + row["Fees"].ToString();
                label7.Text = "Availability :" + row["available_days"].ToString();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void view_btn_doc_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
