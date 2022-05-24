using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdministrareFarmacie;
using StocareMedicamente;
using AngajatiFarmacie;
using System.Configuration;
using System.IO;

//form pentru afisare medicamente


namespace Interfata
{
    public partial class Form4 : Form
    {
        Administrare numFis;

        private Label lblDenumire;
        private Label lblGramaj;
        private Label lblTipMedicament;
        private Label lblTipDurere;

        private Label[] lblsDenumire;
        private Label[] lblsGramaj;
        private Label[] lblsTipMedicament;
        private Label[] lblsTipDurere;

        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 120;
        private const int OFFSET_X = 150;
        public Form4()
        {
            string NumeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + NumeFisier;
            numFis = new Administrare(caleCompletaFisier);
            InitializeComponent();
        }
        private void AfiseazaMedicamente()
        {
            //adaugare control de tip Label pentru 'Denumire';
            lblDenumire = new Label();
            lblDenumire.Width = LATIME_CONTROL;
            lblDenumire.Text = "Denumire";
            lblDenumire.Left = OFFSET_X + 0;
            lblDenumire.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblDenumire);

            //adaugare control de tip Label pentru 'Gramaj';
            lblGramaj = new Label();
            lblGramaj.Width = LATIME_CONTROL;
            lblGramaj.Text = "Gramaj";
            lblGramaj.Left = OFFSET_X + DIMENSIUNE_PAS_X;
            lblGramaj.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblGramaj);

            //adaugare control de tip Label pentru 'Tip Medicament';
            lblTipMedicament = new Label();
            lblTipMedicament.Width = LATIME_CONTROL;
            lblTipMedicament.Text = "Tip Medicament";
            lblTipMedicament.Left = OFFSET_X + 2 * DIMENSIUNE_PAS_X;
            lblTipMedicament.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblTipMedicament);


            //adaugare control de tip Label pentru 'Tip Durere';
            lblTipDurere = new Label();
            lblTipDurere.Width = LATIME_CONTROL;
            lblTipDurere.Text = "Tip Durere";
            lblTipDurere.Left = OFFSET_X + 3 * DIMENSIUNE_PAS_X;
            lblTipDurere.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblTipDurere);

            Medicament[] medicamente = numFis.GetMedicamente(out int nrMedicamente);

            lblsDenumire = new Label[nrMedicamente];
            lblsGramaj = new Label[nrMedicamente];
            lblsTipMedicament = new Label[nrMedicamente];
            lblsTipDurere = new Label[nrMedicamente];

            int i = 0;
            foreach (Medicament medicament in medicamente)
            {
                //adaugare control de tip Label pentru nume
                lblsDenumire[i] = new Label();
                lblsDenumire[i].Width = LATIME_CONTROL;
                lblsDenumire[i].Text = medicament.Denumire;
                lblsDenumire[i].Left = OFFSET_X + 0;
                lblsDenumire[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsDenumire[i]);

                //adaugare control de tip Label pentru prenume
                lblsGramaj[i] = new Label();
                lblsGramaj[i].Width = LATIME_CONTROL;
                lblsGramaj[i].Text = medicament.Gramaj;
                lblsGramaj[i].Left = OFFSET_X + DIMENSIUNE_PAS_X;
                lblsGramaj[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsGramaj[i]);

                //adaugare control de tip Label pentru varsta
                lblsTipMedicament[i] = new Label();
                lblsTipMedicament[i].Width = LATIME_CONTROL;
                lblsTipMedicament[i].Text = medicament.TipMedicament;
                lblsTipMedicament[i].Left = OFFSET_X + 2 * DIMENSIUNE_PAS_X;
                lblsTipMedicament[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsTipMedicament[i]);

                //adaugare control de tip Label pentru cod
                lblsTipDurere[i] = new Label();
                lblsTipDurere[i].Width = LATIME_CONTROL;
                lblsTipDurere[i].Text = medicament.TipDurere;
                lblsTipDurere[i].Left = OFFSET_X + 3 * DIMENSIUNE_PAS_X;
                lblsTipDurere[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsTipDurere[i]);

                i++;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            AfiseazaMedicamente();
        }
    }
}
