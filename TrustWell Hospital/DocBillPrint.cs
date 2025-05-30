using Microsoft.Win32;
using MySql.Data.MySqlClient;
using Mysqlx.Prepare;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace TrustWell_Hospital
{
    public partial class DocBillPrint: Form
    {
        private int Docid;
        private string DoctorName;
        private string Special;
        private int Fee;
        private string PatientName;
        private string RefNo;
        private string PatientMobile;
        private string DocAppDay;
        private int bill;
        private int AppointmentCount = 0;
        private string PatientID;
        private int TotalPrice;
        private int Appointmentid_save_space;

        public DocBillPrint(int doctorID,string docName, string spec,int fees , string patientname , string refno,string patientmobile ,string doctorAppointmentDate , string patientID_)
        {
            Docid = doctorID;
            DoctorName = docName;
            Special = spec;
            Fee = fees;
            PatientName = patientname;
            //RefNo = refno;

            Random random = new Random();
            int randomNumber = random.Next(1000, 10000);
            RefNo = $"REF-{DateTime.Now.ToString("yyyy-MM-dd")}{randomNumber}";


            PatientMobile = patientmobile;
            DocAppDay = doctorAppointmentDate;
            PatientID = patientID_;
            InitializeComponent();
            LoadHosphitalFee();
            LoadRoomNo();


            label6.Text = $"Patient Name : {PatientName}";
            label8.Text = $"RefNo : {RefNo}";
            label7.Text = $"Patient Mobile : {PatientMobile}";

            label9.Text = $"Date & Time : {DocAppDay}";
            label10.Text = $"Patient No : {PatientName}";

            label12.Text = $"Consultant : {DoctorName}";
            label13.Text = $"Speciality : {Special}";


            label14.Text = $"Doctor Charges : {Fee}";



            bill = int.Parse(hosp_price);
            //int total = Fee + hosfee;
            
            label16.Text = $"Total : {Fee + bill}";
            TotalPrice = Fee + bill;


            label17.Text = $"Invoice date : {DateTime.Now.ToString("yyyy-MM-dd")}";
        }

        public string data;
        private void LoadRoomNo()
        {
            string query = "SELECT * FROM Doc_availability Where DoctorID = @DOCID";
            MySqlParameter[] parameters = {
            new MySqlParameter("@DOCID", Docid)
        };

            DataTable dt = Database.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                data =  row["RoomNo"].ToString();

                label15.Text = "Room No:" + data;
            }
        }

        public string hosp_price;
        private void LoadHosphitalFee()
        {
            //eception handeling :::
            try
            {
                string query = "SELECT * FROM Hospital Where ID = 1";

                MySqlParameter[] parameters = new MySqlParameter[0];

                DataTable dt = Database.ExecuteQuery(query , parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    hosp_price = row["Price"].ToString();

                    label19.Text = "Hosphital Fees: " + hosp_price;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Loading the Hosphital Charges:::");
                Console.WriteLine(ex);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LoadPreQueryData()
        {
            string query = "SELECT COUNT(*) AS total FROM Appointments WHERE DoctorID = @DoctorId AND AppointmentDate = @AppointmentDate";

            MySqlParameter[] parameters = {
                new MySqlParameter("@DoctorId" , Docid),
                new MySqlParameter("@AppointmentDate" , DocAppDay),

            };

            try
            {

                DataTable result = Database.ExecuteQuery(query, parameters);

                if(result.Rows.Count > 0)
                {
                    AppointmentCount = int.Parse(result.Rows[0]["total"].ToString());

                }
                else
                {
                    AppointmentCount = 0;
                }

            }
            catch (Exception eg)
            {
                MessageBox.Show("Error Loading Appointment Count : " + eg.Message);
            }

        }

        private void GetAppointmentID()
        {
            string query = "SELECT AppointmentID FROM Appointments WHERE PatientID = @patientid AND DoctorID = @doctorid AND AppointmentDate = @appdate";

            MySqlParameter[] parameters = {
                new MySqlParameter("@patientid" , PatientID),
                new MySqlParameter("@doctorid" , Docid),
                new MySqlParameter("@appdate" , DocAppDay),

            };

            try
            {

                DataTable result = Database.ExecuteQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    Appointmentid_save_space = int.Parse(result.Rows[0]["AppointmentID"].ToString());
                    MessageBox.Show("Appointment data successfully collected.");

                    InsertIntoBilling();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Loading Appointment NUMBER : " + ex.Message);
            }

        }

        private void InsertIntoBilling()
        {
            string query = "INSERT INTO Billing (ReferenceNum , PatientID , AppointmentID , StaffID , TotalAmount , PaymentStatus , PaymentMethod , BillingDate , CreatedAt) VALUES (@refno , @patientid , @appointmentid , @staffid , @totalammount , @stat , @paymentmethod , @billingdate , @createdat)";
            MySqlParameter[] parameters = {
                new MySqlParameter("@refno", RefNo),
                new MySqlParameter("@patientid", PatientID),
                new MySqlParameter("@appointmentid", Appointmentid_save_space),
                new MySqlParameter("@staffid", UserSession.StaffId),
                new MySqlParameter("@totalammount", TotalPrice),
                new MySqlParameter("@stat", "Paid"),
                new MySqlParameter("@paymentmethod", "cash"),
                new MySqlParameter("@BillingDate", DateTime.Now.ToString("yyyy-MM-dd")),
                new MySqlParameter("@createdat", DateTime.Now.ToString("yyyy-MM-dd")),

            };

            try
            {
                Database.ExecuteNonQuery(query, parameters);
                Console.WriteLine("User inserted successfully.");
                MessageBox.Show("Appointment Inserted Sucessfully.");
            }
            catch(Exception ef)
            {
                MessageBox.Show("Theres a plob in billing insert " + ef.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            LoadPreQueryData();
            Appointment_Data_Insertion();

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bmp, new Rectangle(0, 0, panel1.Width, panel1.Height));
            e.Graphics.DrawImage(bmp, 0, 0);

        }

        private void DocBillPrint_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Appointment_Data_Insertion()
        {

            string query = "INSERT INTO Appointments (PatientID, DoctorID ,AppointmentDate ,Appoinmentnumber, Status , ScheduledBy, CreatedAt) VALUES (@patientid , @docid , @appDate , @appnum , @sText, @scheduledBy , @created_date)";
            MySqlParameter[] parameters = {
                new MySqlParameter("@patientid", PatientID),
                new MySqlParameter("@docid", Docid),
                new MySqlParameter("@appDate", DocAppDay),
                new MySqlParameter("@appnum", AppointmentCount + 1),
                new MySqlParameter("@sText", "Scheduled" ),
                new MySqlParameter("@scheduledBy", UserSession.StaffId),
                new MySqlParameter("@created_date",DateTime.Now.ToString("yyyy-MM-dd") )
            };

            Database.ExecuteNonQuery(query, parameters);
            Console.WriteLine("User inserted successfully.");
            MessageBox.Show("Appointment Inserted Sucessfully.");

            GetAppointmentID();
        }


        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
