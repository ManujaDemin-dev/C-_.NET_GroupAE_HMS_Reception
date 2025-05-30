namespace TrustWell_Hospital
{
    partial class PatientMiniPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblNIC = new System.Windows.Forms.Label();
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cuiButton1 = new CuoreUI.Controls.cuiButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();

            this.gunaPanel1.SuspendLayout();
            this.SuspendLayout();

            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblAddress.Location = new System.Drawing.Point(166, 476);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(59, 25);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "label1";

            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblEmail.Location = new System.Drawing.Point(166, 423);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(63, 28);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "label1";

            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblContact.Location = new System.Drawing.Point(166, 378);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(59, 25);
            this.lblContact.TabIndex = 3;
            this.lblContact.Text = "label1";

            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblDOB.Location = new System.Drawing.Point(166, 324);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(63, 28);
            this.lblDOB.TabIndex = 4;
            this.lblDOB.Text = "label1";

            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblGender.Location = new System.Drawing.Point(166, 273);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(63, 28);
            this.lblGender.TabIndex = 5;
            this.lblGender.Text = "label1";

            // 
            // lblNIC
            // 
            this.lblNIC.AutoSize = true;
            this.lblNIC.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblNIC.Location = new System.Drawing.Point(166, 222);
            this.lblNIC.Name = "lblNIC";
            this.lblNIC.Size = new System.Drawing.Size(63, 28);
            this.lblNIC.TabIndex = 6;
            this.lblNIC.Text = "label1";

            // 
            // gunaPanel1
            // 
            this.gunaPanel1.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.gunaPanel1.Controls.Add(this.label1);
            this.gunaPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaPanel1.Location = new System.Drawing.Point(0, 0);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(1249, 74);
            this.gunaPanel1.TabIndex = 7;

            // 
            // label1 (Header Label)
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(442, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 46);
            this.label1.Text = "Patient Information";
            this.label1.Click += new System.EventHandler(this.label1_Click);

            // 
            // cuiButton1 (Edit Button)
            // 
            this.cuiButton1.Content = "Edit ";
            this.cuiButton1.Location = new System.Drawing.Point(1008, 627);
            this.cuiButton1.Name = "cuiButton1";
            this.cuiButton1.Size = new System.Drawing.Size(153, 45);
            this.cuiButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.cuiButton1.NormalBackground = System.Drawing.Color.LightSkyBlue;
            this.cuiButton1.NormalForeColor = System.Drawing.Color.Black;
            this.cuiButton1.Click += new System.EventHandler(this.cuiButton1_Click);

            // 
            // Additional Labels
            // 
            // Create a shared Font object
            System.Drawing.Font sharedFont = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);

            // Assign the font and configure each label
            this.label2.Font = sharedFont;
            this.label2.Location = new System.Drawing.Point(714, 138);
            this.label2.Size = new System.Drawing.Size(425, 29);
            this.label2.Text = "label2"; // TODO: Replace with actual text

            this.label3.Font = sharedFont;
            this.label3.Location = new System.Drawing.Point(714, 221);
            this.label3.Size = new System.Drawing.Size(293, 29);
            this.label3.Text = "label3";

            this.label4.Font = sharedFont;
            this.label4.Location = new System.Drawing.Point(714, 272);
            this.label4.Size = new System.Drawing.Size(293, 29);
            this.label4.Text = "label4";

            this.label5.Font = sharedFont;
            this.label5.Location = new System.Drawing.Point(714, 320);
            this.label5.Size = new System.Drawing.Size(293, 29);
            this.label5.Text = "label5";

            this.label6.Font = sharedFont;
            this.label6.Location = new System.Drawing.Point(714, 374);
            this.label6.Size = new System.Drawing.Size(293, 29);
            this.label6.Text = "label6";

            this.label7.Font = sharedFont;
            this.label7.Location = new System.Drawing.Point(712, 423);
            this.label7.Size = new System.Drawing.Size(447, 59);
            this.label7.Text = "label7";


            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblName.Location = new System.Drawing.Point(166, 135);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(63, 28);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "label1";

            // 
            // PatientMiniPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 721);
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.label2, this.label3, this.label4, this.label5, this.label6, this.label7,
                this.cuiButton1, this.gunaPanel1, this.lblNIC, this.lblGender, this.lblDOB,
                this.lblContact, this.lblEmail, this.lblAddress, this.lblName
            });
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatientMiniPage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PatientMiniPage_Load);

            this.gunaPanel1.ResumeLayout(false);
            this.gunaPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblNIC;
        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private System.Windows.Forms.Label label1;
        private CuoreUI.Controls.cuiButton cuiButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblName;
    }
}