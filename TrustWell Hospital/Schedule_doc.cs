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
    public partial class Schedule_doc: Form
    {
        private int Docid;
        private string DoctorName;
        private string Special;
        private int Fee;
        private string PatientName;
        private string RefNo;
        private string PatientMobile;
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
            label1.Text = $"Doctor ID : {Docid}";
            label3.Text = $"Doctor Name : {DoctorName}";
            label4.Text = $"Doctor Specialization : {Special}";
            label9.Text = $"Doctor Fee : {Fee}";
            label5.Text = $"Patient Name : {PatientName}";
            //label6.Text = $" : {PatientName}";
            label7.Text = $"Patient Mobilie : {PatientMobile}";
            //label10.Text = $"hELLOW DOC ID : {RefNo}";
        }

        private void Schedule_doc_Load(object sender, EventArgs e)
        {

        }
    }
}
