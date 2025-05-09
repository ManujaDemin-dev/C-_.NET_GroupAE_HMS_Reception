namespace TrustWell_Hospital
{
    internal class LabTestsPage : Labpayment2
    {
        private int patientID;
        private string patientName;

        public LabTestsPage(int patientID, string patientName)
        {
            this.patientID=patientID;
            this.patientName=patientName;
        }
    }
}