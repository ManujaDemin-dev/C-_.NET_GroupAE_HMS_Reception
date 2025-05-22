using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        //d_t.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        public DocBillPrint(int doctorID,string docName, string spec,int fees , string patientname , string refno,string patientmobile ,string doctorAppointmentDate)
        {
            Docid = doctorID;
            DoctorName = docName;
            Special = spec;
            Fee = fees;
            PatientName = patientname;
            RefNo = refno;
            PatientMobile = patientmobile;
            DocAppDay = doctorAppointmentDate;
            InitializeComponent();


            label6.Text = $"Patient Name : {PatientName}";
            label8.Text = $"RefNo : {RefNo}";
            label7.Text = $"Patient Mobile : {PatientMobile}";
            label9.Text = $"Date & Time : {DocAppDay}";
            label10.Text = $"Patient No : {PatientName}";
            label11.Text = "Room No : {get me from the avalability table}";

            label12.Text = $"Consultant : {DoctorName}";
            label13.Text = $"Speciality : {Special}";


            label14.Text = $"Doctor Charges : {Fee}";
            label15.Text = $"Hosphital Chages: GET FROM table :/ ";



            //int total = Fee + hosfee;
            label16.Text = $"Total Payment : total ;/ ";


            label17.Text = $"Invoice date : {DateTime.Now.ToString("yyyy-MM-dd")}";
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

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

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
