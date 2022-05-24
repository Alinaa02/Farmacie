
namespace Interfata
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAfiseaza = new System.Windows.Forms.Button();
            this.btnSalvare = new System.Windows.Forms.Button();
            this.btnAfisMed = new System.Windows.Forms.Button();
            this.btnSalvMed = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(302, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestiune Farmacie";
            // 
            // btnAfiseaza
            // 
            this.btnAfiseaza.Location = new System.Drawing.Point(63, 59);
            this.btnAfiseaza.Name = "btnAfiseaza";
            this.btnAfiseaza.Size = new System.Drawing.Size(144, 46);
            this.btnAfiseaza.TabIndex = 1;
            this.btnAfiseaza.Text = "Afisare angajati";
            this.btnAfiseaza.UseVisualStyleBackColor = true;
            this.btnAfiseaza.Click += new System.EventHandler(this.btnAfiseaza_Click);
            // 
            // btnSalvare
            // 
            this.btnSalvare.Location = new System.Drawing.Point(63, 120);
            this.btnSalvare.Name = "btnSalvare";
            this.btnSalvare.Size = new System.Drawing.Size(144, 37);
            this.btnSalvare.TabIndex = 2;
            this.btnSalvare.Text = "Salveaza angajati";
            this.btnSalvare.UseVisualStyleBackColor = true;
            this.btnSalvare.Click += new System.EventHandler(this.btnSalvare_Click);
            // 
            // btnAfisMed
            // 
            this.btnAfisMed.Location = new System.Drawing.Point(63, 176);
            this.btnAfisMed.Name = "btnAfisMed";
            this.btnAfisMed.Size = new System.Drawing.Size(144, 35);
            this.btnAfisMed.TabIndex = 3;
            this.btnAfisMed.Text = "Afisare medicamente";
            this.btnAfisMed.UseVisualStyleBackColor = true;
            this.btnAfisMed.Click += new System.EventHandler(this.btnAfisMed_Click);
            // 
            // btnSalvMed
            // 
            this.btnSalvMed.Location = new System.Drawing.Point(63, 228);
            this.btnSalvMed.Name = "btnSalvMed";
            this.btnSalvMed.Size = new System.Drawing.Size(144, 41);
            this.btnSalvMed.TabIndex = 4;
            this.btnSalvMed.Text = "Salveaza medicamente";
            this.btnSalvMed.UseVisualStyleBackColor = true;
            this.btnSalvMed.Click += new System.EventHandler(this.btnSalvMed_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(420, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "Iesire program";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSalvMed);
            this.Controls.Add(this.btnAfisMed);
            this.Controls.Add(this.btnSalvare);
            this.Controls.Add(this.btnAfiseaza);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Farmacie";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAfiseaza;
        private System.Windows.Forms.Button btnSalvare;
        private System.Windows.Forms.Button btnAfisMed;
        private System.Windows.Forms.Button btnSalvMed;
        private System.Windows.Forms.Button button1;
    }
}

