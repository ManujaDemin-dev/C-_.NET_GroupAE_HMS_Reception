namespace TrustWell_Hospital
{
    internal class LabTestsPage : Labpayment2
    {
        private int patientID;
        private string patientName;

        public LabTestsPage(int patientID, string patientName)
            : base(patientName, string.Empty, string.Empty) // Pass required arguments to the base constructor  
        {
            this.patientID = patientID;
            this.patientName = patientName;
        }
    }
}