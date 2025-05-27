namespace TrustWell_Hospital
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cuiPictureBox1 = new CuoreUI.Controls.cuiPictureBox();
            this.cuiLabel1 = new CuoreUI.Controls.cuiLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cuiPanel1 = new CuoreUI.Controls.cuiPanel();
            this.button1 = new Guna.UI.WinForms.GunaButton();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new Guna.UI.WinForms.GunaTextBox();
            this.textBox1 = new Guna.UI.WinForms.GunaTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cuiPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label2.Location = new System.Drawing.Point(52, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Email :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.label3.Location = new System.Drawing.Point(35, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cuiPictureBox1
            // 
            this.cuiPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.cuiPictureBox1.BackgroundImage = global::TrustWell_Hospital.Properties.Resources.logo;
            this.cuiPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cuiPictureBox1.Content = null;
            this.cuiPictureBox1.ImageTint = System.Drawing.Color.White;
            this.cuiPictureBox1.Location = new System.Drawing.Point(1274, 9);
            this.cuiPictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cuiPictureBox1.Name = "cuiPictureBox1";
            this.cuiPictureBox1.OutlineThickness = 1F;
            this.cuiPictureBox1.PanelOutlineColor = System.Drawing.Color.Empty;
            this.cuiPictureBox1.Rotation = 0;
            this.cuiPictureBox1.Rounding = new System.Windows.Forms.Padding(8);
            this.cuiPictureBox1.Size = new System.Drawing.Size(188, 162);
            this.cuiPictureBox1.TabIndex = 6;
            this.cuiPictureBox1.Load += new System.EventHandler(this.cuiPictureBox1_Load);
            // 
            // cuiLabel1
            // 
            this.cuiLabel1.BackColor = System.Drawing.Color.Transparent;
            this.cuiLabel1.Content = "TrustWell\\ Hospital";
            this.cuiLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cuiLabel1.HorizontalAlignment = System.Drawing.StringAlignment.Center;
            this.cuiLabel1.Location = new System.Drawing.Point(1478, 25);
            this.cuiLabel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cuiLabel1.Name = "cuiLabel1";
            this.cuiLabel1.Size = new System.Drawing.Size(425, 58);
            this.cuiLabel1.TabIndex = 7;
            this.cuiLabel1.TabStop = false;
            this.cuiLabel1.Tag = "";
            this.cuiLabel1.VerticalAlignment = System.Drawing.StringAlignment.Near;
            this.cuiLabel1.Load += new System.EventHandler(this.cuiLabel1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1550, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "trustwellhospital@gmail.com";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1550, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(239, 22);
            this.label4.TabIndex = 9;
            this.label4.Text = "No.55, Pitipana, Homagama.";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // cuiPanel1
            // 
            this.cuiPanel1.BackColor = System.Drawing.Color.Transparent;
            this.cuiPanel1.Controls.Add(this.button1);
            this.cuiPanel1.Controls.Add(this.label7);
            this.cuiPanel1.Controls.Add(this.textBox2);
            this.cuiPanel1.Controls.Add(this.textBox1);
            this.cuiPanel1.Controls.Add(this.label6);
            this.cuiPanel1.Controls.Add(this.label5);
            this.cuiPanel1.Controls.Add(this.label2);
            this.cuiPanel1.Controls.Add(this.label3);
            this.cuiPanel1.Location = new System.Drawing.Point(792, 219);
            this.cuiPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cuiPanel1.Name = "cuiPanel1";
            this.cuiPanel1.OutlineThickness = 1F;
            this.cuiPanel1.PanelColor = System.Drawing.Color.White;
            this.cuiPanel1.PanelOutlineColor = System.Drawing.Color.White;
            this.cuiPanel1.Rounding = new System.Windows.Forms.Padding(30);
            this.cuiPanel1.Size = new System.Drawing.Size(640, 577);
            this.cuiPanel1.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.AnimationHoverSpeed = 0.07F;
            this.button1.AnimationSpeed = 0.03F;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.button1.BorderColor = System.Drawing.Color.Black;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.button1.FocusedColor = System.Drawing.Color.Empty;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = null;
            this.button1.ImageSize = new System.Drawing.Size(20, 20);
            this.button1.Location = new System.Drawing.Point(234, 473);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.button1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.button1.OnHoverForeColor = System.Drawing.Color.White;
            this.button1.OnHoverImage = null;
            this.button1.OnPressedColor = System.Drawing.Color.Black;
            this.button1.Radius = 12;
            this.button1.Size = new System.Drawing.Size(174, 48);
            this.button1.TabIndex = 20;
            this.button1.Text = "Sign In";
            this.button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.label7.Location = new System.Drawing.Point(231, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 37);
            this.label7.TabIndex = 19;
            this.label7.Text = "Sign In";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Transparent;
            this.textBox2.BaseColor = System.Drawing.Color.White;
            this.textBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.textBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox2.FocusedBaseColor = System.Drawing.Color.White;
            this.textBox2.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.textBox2.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBox2.Location = new System.Drawing.Point(190, 336);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.textBox2.PasswordChar = '\0';
            this.textBox2.Radius = 12;
            this.textBox2.SelectedText = "";
            this.textBox2.Size = new System.Drawing.Size(351, 45);
            this.textBox2.TabIndex = 18;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Transparent;
            this.textBox1.BaseColor = System.Drawing.Color.White;
            this.textBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.FocusedBaseColor = System.Drawing.Color.White;
            this.textBox1.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.textBox1.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textBox1.Location = new System.Drawing.Point(190, 270);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Padding = new System.Windows.Forms.Padding(5, 2, 5, 2);
            this.textBox1.PasswordChar = '\0';
            this.textBox1.Radius = 12;
            this.textBox1.SelectedText = "";
            this.textBox1.Size = new System.Drawing.Size(351, 45);
            this.textBox1.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(100, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(412, 46);
            this.label6.TabIndex = 5;
            this.label6.Text = "Receptionist Application";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.label5.Location = new System.Drawing.Point(180, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(219, 46);
            this.label5.TabIndex = 5;
            this.label5.Text = "Welcome to,";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.cuiPanel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cuiLabel1);
            this.Controls.Add(this.cuiPictureBox1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cuiPanel1.ResumeLayout(false);
            this.cuiPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CuoreUI.Controls.cuiPictureBox cuiPictureBox1;
        private CuoreUI.Controls.cuiLabel cuiLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private CuoreUI.Controls.cuiPanel cuiPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI.WinForms.GunaTextBox textBox2;
        private Guna.UI.WinForms.GunaTextBox textBox1;
        private Guna.UI.WinForms.GunaButton button1;
        private System.Windows.Forms.Label label7;
    }
}

