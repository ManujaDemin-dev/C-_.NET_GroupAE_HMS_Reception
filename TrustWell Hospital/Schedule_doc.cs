using Guna.UI.WinForms;
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System.IO;
using System.Net;

namespace TrustWell_Hospital
{
    public partial class Schedule_doc: Form
    {
        private int Docid;
        private string DoctorName;
        private string Special;
        private int Fee;
        private string PatientName;
        private string RefNo;
        private string PatientMobile;
        private bool isDoctorAvailable = false;

        public Schedule_doc(int doctorID,string docName,string spec, int fees,string patientname , string refno ,string patientmobile)
        {
            InitializeComponent();
            Docid = doctorID;
            DoctorName = docName;
            Special = spec;
            Fee = fees;
            PatientName = patientname;
            RefNo = refno;
            PatientMobile = patientmobile;
            HeaderLoad();
            AvalabilityData();
        }

        private void HeaderLoad()
        {
            label1.Text = $"Doctor ID : {Docid}";
            label3.Text = $"Doctor Name : {DoctorName}";
            label4.Text = $"Doctor Specialization : {Special}";
            label9.Text = $"Doctor Fee : {Fee}";
            label5.Text = $"Patient Name : {PatientName}";
            //label6.Text = $" : {PatientName}";
            label7.Text = $"Patient Mobilie : {PatientMobile}";
            //label10.Text = $"hELLOW DOC ID : {RefNo}";
        }

        List<string> docDay = new List<string>();

        private void AvalabilityData()
        {
            string query = "SELECT available_day, start_time, end_time FROM Doc_availability WHERE DoctorID = @DOCID";
            MySqlParameter[] parameters = {
            new MySqlParameter("@DOCID", Docid)
        };

            DataTable dt = Database.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                foreach (DataRow row in dt.Rows)
                {
                    string day = row["available_day"].ToString();
                    string startTime = row["start_time"].ToString();
                    string endTime = row["end_time"].ToString();
                    //DataRow row = dt.Rows[0];

                    sb.AppendLine($"- {day}: {startTime} to {endTime}");
                    docDay.Add(day);
                }
                
                label13.Text = $"Doctor Avalability Days: = {sb.ToString()}";
                label18.Text = $"{docDay}";

            }
            else
            {
                label13.Text = "No Availability data found for this doctor :(";

            }
                
        }





        private void Schedule_doc_Load(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private string doctorAppointmentdate;

        private void button3_Click(object sender, EventArgs e)
        {
            label17.Text = dateTimePicker1.Value.DayOfWeek.ToString();
            doctorAppointmentdate = dateTimePicker1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedDay = label17.Text;

            if (docDay.Contains(selectedDay))
            {
                MessageBox.Show("Doctor is available on the selected date");
                label18.Text = "Doctor is available on teh selected date";
                isDoctorAvailable = true; 
            }
            else
            {
                MessageBox.Show("Doctor is not available on this selected day.");
                label18.Text = "Doctor is not available.";
                isDoctorAvailable = false;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(label17.Text))
            {
                MessageBox.Show("Please select an appointment date first.");
                return;
            }

            if (!isDoctorAvailable)
            {
                MessageBox.Show("Doctor is not available on the selected date. Please choose a valid day.");
                return;
            }

            // Generate ref no properly (you had an issue here too)
            string refNo = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + PatientName;

            // Proceed to bill
            DocBillPrint popup = new DocBillPrint(Docid, DoctorName, Special, Fee, PatientName, refNo, PatientMobile, doctorAppointmentdate);
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.ShowDialog();
        }

    }
}
