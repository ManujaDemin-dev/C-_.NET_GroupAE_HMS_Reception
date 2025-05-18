using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WindowsFormsApp1;
using System.Linq;

namespace TrustWell_Hospital
{
    public partial class Labbill1 : Form
    {
        private List<(int TestID, string TestName, decimal TestPrice)> selectedTests;
        private string patientName;
        private string referenceNo;
        private string contactNumber;
        private int  patientID;
        private decimal total = 0;
        private String Date;
        private List<(int TestID, string TestName, decimal TestPrice)> cart;

        public Labbill1(List<(int TestID, string TestName, decimal TestPrice)> selectedTests, string patientName, string referenceNo, string contactNumber,int patientID)
        {
            InitializeComponent();
            this.selectedTests = selectedTests;
            this.patientName = patientName;
            this.referenceNo = referenceNo;
            this.contactNumber = contactNumber;
            this.patientID = patientID;

            this.Load += Labbill_Load;
        }

        private void Labbill_Load(object sender, EventArgs e)
        {
            pname.Text = this.patientName;
            refnum.Text = this.referenceNo;
            pNo.Text = this.contactNumber;
            d_t.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Date = d_t.Text;
            txtBillSummary.Text = GenerateTextBillSummary();
        }

        private string GenerateTextBillSummary()
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("======= LAB TEST BILL =======");
            sb.AppendLine($"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine($"Patient Name: {patientName}");
            sb.AppendLine($"Reference No: {referenceNo}");
            sb.AppendLine($"Contact No: {contactNumber}");
            sb.AppendLine("-----------------------------");
            sb.AppendLine("Tests:");
            foreach (var test in selectedTests)
            {
                sb.AppendLine($"{test.TestName} - Rs. {test.TestPrice:N2}");
                total += test.TestPrice;
            }
            sb.AppendLine("-----------------------------");
            sb.AppendLine($"Total Price: Rs. {total:N2}");
            sb.AppendLine("=============================");
            return sb.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SaveStyledPDF();

            foreach (var test in selectedTests)
            {
                string query = "INSERT INTO LabTests (PatientID,Status,TestType,ReferenceID) VALUES (@PatientId,'Pending',@TestType,@ReferenceID)";
                MySqlParameter[] parameters = {
                    new MySqlParameter("@PatientId", patientID),
                    new MySqlParameter("@TestType", test.TestID),
                    new MySqlParameter("@ReferenceID", referenceNo),
                    };
                Database.ExecuteNonQuery(query, parameters);
            }
            try
            {
                List<int> testIds = cart.Select(t => t.TestID).ToList();
                string inClause = string.Join(",", testIds);
                string query = "INSERT INTO Billing (ReferenceNum,PatientID,StaffID,TestType,TotalAmount,PaymentStatus,PaymentMethod,BillingDate,CreatedAt)" +
                        " VALUES (@ReferenceNum,@PatientId,@staffid,@testtype,@totalAmount,'Pending','Cash',@BillingDate,NOW())";
                    MySqlParameter[] parameters = {
                    new MySqlParameter("@ReferenceNum", referenceNo),
                    new MySqlParameter("@PatientId", patientID),
                    new MySqlParameter("@staffid", UserSession.StaffId),
                    new MySqlParameter("@testtype" , inClause),
                    new MySqlParameter("@totalAmount",total),
                    new MySqlParameter("@BillingDate", Date),
                    };
                    Database.ExecuteNonQuery(query, parameters);
                }
           
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while inserting billing data:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveStyledPDF()
        {
            try
            {
                string fileName = $"LabBill_{DateTime.Now:yyyyMMddHHmmss}.pdf";
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 40f, 40f, 100f, 60f);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                    string logoUrl = "https://drive.google.com/uc?id=1Wbx5Mx9Sdb4BDMn0fadq0HPqsLWNwVdn&export=download"; // Replace this with your actual image URL
                    writer.PageEvent = new CustomPdfPageEvent(logoUrl);

                    pdfDoc.Open();

                    var titleFont = FontFactory.GetFont("Arial", 18f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    var boldFont = FontFactory.GetFont("Arial", 12f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                    var normalFont = FontFactory.GetFont("Arial", 12f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                    Paragraph title = new Paragraph("TRUSTWELL HOSPITAL LAB BILL", titleFont)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 20f
                    };
                    pdfDoc.Add(title);

                    PdfPTable infoTable = new PdfPTable(2)
                    {
                        WidthPercentage = 100,
                        SpacingAfter = 20f
                    };
                    infoTable.SetWidths(new float[] { 1, 2 });

                    void AddInfoRow(string label, string value)
                    {
                        infoTable.AddCell(new PdfPCell(new Phrase(label, boldFont)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                        infoTable.AddCell(new PdfPCell(new Phrase(value, normalFont)) { Border = iTextSharp.text.Rectangle.NO_BORDER });
                    }

                    AddInfoRow("Patient Name:", patientName);
                    AddInfoRow("Reference No:", referenceNo);
                    AddInfoRow("Contact No:", contactNumber);
                    AddInfoRow("Date:", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    pdfDoc.Add(infoTable);

                    LineSeparator separator = new LineSeparator(1f, 100f, BaseColor.GRAY, Element.ALIGN_CENTER, -1);
                    pdfDoc.Add(new Chunk(separator));

                    PdfPTable testTable = new PdfPTable(2)
                    {
                        WidthPercentage = 100,
                        SpacingBefore = 20f,
                        SpacingAfter = 10f
                    };
                    testTable.SetWidths(new float[] { 3, 1 });

                    testTable.AddCell(new PdfPCell(new Phrase("Test Name", boldFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });
                    testTable.AddCell(new PdfPCell(new Phrase("Price (Rs)", boldFont)) { BackgroundColor = BaseColor.LIGHT_GRAY });

                    decimal total = 0;
                    foreach (var test in selectedTests)
                    {
                        testTable.AddCell(new Phrase(test.TestName, normalFont));
                        testTable.AddCell(new Phrase(test.TestPrice.ToString("N2"), normalFont));
                        total += test.TestPrice;
                    }

                    PdfPCell totalCellLabel = new PdfPCell(new Phrase("Total", boldFont)) { HorizontalAlignment = Element.ALIGN_RIGHT };
                    testTable.AddCell(totalCellLabel);
                    testTable.AddCell(new Phrase(total.ToString("N2"), boldFont));

                    pdfDoc.Add(testTable);

                    Paragraph footer = new Paragraph("Thank you for choosing TrustWell Hospital.\nGet well soon!", normalFont)
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingBefore = 20f
                    };
                    pdfDoc.Add(footer);

                    pdfDoc.Close();
                    stream.Close();
                }

                MessageBox.Show("PDF saved successfully in your Downloads folder.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class CustomPdfPageEvent : PdfPageEventHelper
    {
        private readonly string logoUrl;
        private iTextSharp.text.Image logo;

        public CustomPdfPageEvent(string logoUrl)
        {
            this.logoUrl = logoUrl;
            try
            {
                using (var client = new WebClient())
                {
                    byte[] imageBytes = client.DownloadData(logoUrl);
                    logo = iTextSharp.text.Image.GetInstance(imageBytes);
                }
            }
            catch
            {
                logo = null;
            }
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            PdfPTable headerTable = new PdfPTable(1) { TotalWidth = document.PageSize.Width - 80f };
            if (logo != null)
            {
                logo.ScaleToFit(100f, 100f);
                PdfPCell logoCell = new PdfPCell(logo)
                {
                    Border = iTextSharp.text.Rectangle.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    PaddingBottom = 10f
                };
                headerTable.AddCell(logoCell);
            }
            headerTable.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 10, writer.DirectContent);

            iTextSharp.text.Font footerFont = FontFactory.GetFont("Arial", 9f, iTextSharp.text.Font.NORMAL, BaseColor.GRAY);
            ColumnText.ShowTextAligned(writer.DirectContent, Element.ALIGN_CENTER,
                new Phrase("Trustwell Hospital, Pitipana, Homagama. www.trustwell.com Tel: +94 117 778 009", footerFont),
                document.PageSize.Width / 2, document.BottomMargin / 2, 0);
        }
    }
}
