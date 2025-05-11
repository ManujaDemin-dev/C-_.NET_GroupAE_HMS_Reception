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
    public partial class Labbill1 : Form
    {
        //store the selected test details
        private List<(int TestID, string TestName, decimal TestPrice)> selectedTests;
        private string patientName;
        private string referenceNo;
        private string contactNumber;

        public Labbill1(List<(int TestID, string TestName, decimal TestPrice)> selectedTests, string patientName, string referenceNo, string contactNumber)
        {
            InitializeComponent();
            this.selectedTests = selectedTests;
            this.patientName = patientName;
            this.referenceNo = referenceNo;
            this.contactNumber = contactNumber;

            this.Load += Labbill_Load;
        }


        private void Labbill_Load(object sender, EventArgs e)
        {
            pname.Text = this.patientName;
            refnum.Text = this.referenceNo;
            pNo.Text = this.contactNumber;

            d_t.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            //create the bill
            StringBuilder summary = new StringBuilder();
            summary.AppendLine("======= LAB TEST BILL =======");
            summary.AppendLine($"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            summary.AppendLine($"Patient Name: {patientName}");
            summary.AppendLine($"Reference No: {referenceNo}");
            summary.AppendLine($"Contact No: {contactNumber}");
            summary.AppendLine("-----------------------------");
            summary.AppendLine("Tests:");

            decimal total = 0;
            foreach (var test in selectedTests)
            {
                summary.AppendLine($"{test.TestName} - Rs. {test.TestPrice:N2}");
                total += test.TestPrice;
            }

            summary.AppendLine("-----------------------------");
            summary.AppendLine($"Total Price: Rs. {total:N2}");
            summary.AppendLine("=============================");

            txtBillSummary.Text = summary.ToString();
        }

        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bill is printed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bmp, new Rectangle(0, 0, panel1.Width, panel1.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void btnPrint_MouseClick(object sender, MouseEventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
