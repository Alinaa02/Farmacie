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


//form pentru afisare angajati

namespace Interfata
{
    public partial class Form2 : Form
    {
        
        Administrare numeFis;
        
        private Label lblNume;
        private Label lblPrenume;
        private Label lblVarsta;
        private Label lblCod;

        private Label[] lblsNume;
        private Label[] lblsPrenume;
        private Label[] lblsVarsta;
        private Label[] lblsCod;
        

        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 120;
        private const int OFFSET_X = 150;
        
        public Form2()
        {
            
            string _NumeFisier = ConfigurationManager.AppSettings["_NumeFisier"];
            string locatieFisierSolutieAngj = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisierAngj = locatieFisierSolutieAngj + "\\" + _NumeFisier;
            numeFis = new Administrare(caleCompletaFisierAngj);
            
            
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            AfiseazaAngajati();
        }
        private void AfiseazaAngajati()
        {

            //adaugare control de tip Label pentru 'Nume';
            lblNume = new Label();
            lblNume.Width = LATIME_CONTROL;
            lblNume.Text = "Nume";
            lblNume.Left = OFFSET_X + 0;
            lblNume.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblNume);

            //adaugare control de tip Label pentru 'Prenume';
            lblPrenume = new Label();
            lblPrenume.Width = LATIME_CONTROL;
            lblPrenume.Text = "Prenume";
            lblPrenume.Left = OFFSET_X + DIMENSIUNE_PAS_X;
            lblPrenume.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblPrenume);

            //adaugare control de tip Label pentru 'Varsta';
            lblVarsta = new Label();
            lblVarsta.Width = LATIME_CONTROL;
            lblVarsta.Text = "Varsta";
            lblVarsta.Left = OFFSET_X + 2 * DIMENSIUNE_PAS_X;
            lblVarsta.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblVarsta);


            //adaugare control de tip Label pentru 'Cod';
            lblCod = new Label();
            lblCod.Width = LATIME_CONTROL;
            lblCod.Text = "Cod";
            lblCod.Left = OFFSET_X + 3 * DIMENSIUNE_PAS_X;
            lblCod.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblCod);

            Angajat[] angajati = numeFis.GetAngajati(out int nrAngajati);

            lblsNume = new Label[nrAngajati];
            lblsPrenume = new Label[nrAngajati];
            lblsVarsta = new Label[nrAngajati];
            lblsCod = new Label[nrAngajati];

            int i = 0;
            foreach (Angajat angajat in angajati)
            {
                //adaugare control de tip Label pentru nume
                lblsNume[i] = new Label();
                lblsNume[i].Width = LATIME_CONTROL;
                lblsNume[i].Text = angajat.Nume;
                lblsNume[i].Left = OFFSET_X + 0;
                lblsNume[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsNume[i]);

                //adaugare control de tip Label pentru prenume
                lblsPrenume[i] = new Label();
                lblsPrenume[i].Width = LATIME_CONTROL;
                lblsPrenume[i].Text = angajat.Prenume;
                lblsPrenume[i].Left = OFFSET_X + DIMENSIUNE_PAS_X;
                lblsPrenume[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsPrenume[i]);

                //adaugare control de tip Label pentru varsta
                lblsVarsta[i] = new Label();
                lblsVarsta[i].Width = LATIME_CONTROL;
                lblsVarsta[i].Text = angajat.Varsta;
                lblsVarsta[i].Left = OFFSET_X + 2 * DIMENSIUNE_PAS_X;
                lblsVarsta[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsVarsta[i]);

                //adaugare control de tip Label pentru cod
                lblsCod[i] = new Label();
                lblsCod[i].Width = LATIME_CONTROL;
                lblsCod[i].Text = angajat.CodAngajat;
                lblsCod[i].Left = OFFSET_X + 3 * DIMENSIUNE_PAS_X;
                lblsCod[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsCod[i]);

                i++;

            }
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            AfiseazaAngajati();
        }
    }
}
