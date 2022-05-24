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


//form pentru salvare angajati


namespace Interfata
{
    public partial class Form3 : Form
    {
        bool compara = false;
        Administrare adminAngajat, adminAngajati;
        int nrAngajati = 0;
        Angajat angajat = new Angajat();
        int nrMedicamente = 0;
        Medicament medicament = new Medicament();

        public Form3()
        {
            string NumeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + NumeFisier;

            string _NumeFisier = ConfigurationManager.AppSettings["_NumeFisier"];
            string locatieFisierSolutieAngj = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisierAngj = locatieFisierSolutieAngj + "\\" + _NumeFisier;

            adminAngajat = new Administrare(caleCompletaFisierAngj);
            adminAngajati = new Administrare(caleCompletaFisierAngj);

            adminAngajati.GetAngajati(out nrAngajati);
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
                textBox1.BackColor = Color.White;
            else
                textBox1.BackColor = Color.AliceBlue;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 0)
                textBox2.BackColor = Color.White;
            else
                textBox2.BackColor = Color.AliceBlue;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length != 0)
                textBox3.BackColor = Color.White;
            else
                textBox3.BackColor = Color.AliceBlue;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Length != 0)
                textBox4.BackColor = Color.White;
            else
                textBox4.BackColor = Color.AliceBlue;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = Color.White;
                    btn.ForeColor = Color.Black;
                    btn.FlatAppearance.BorderColor = Color.LimeGreen;
                }
            }

            lblNume.ForeColor = Color.LimeGreen;
            lblPrenume.ForeColor = Color.LimeGreen;
            lblVarsta.ForeColor = Color.LimeGreen;
            lblCod.ForeColor = Color.LimeGreen;
            button2.BackColor = Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.BackColor = Color.White;
            textBox2.Text = "";
            textBox2.BackColor = Color.White;
            textBox3.Text = "";
            textBox3.BackColor = Color.White;
            textBox4.Text = "";
            textBox4.BackColor = Color.White;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ok = 1;
            if (compara == false)
            {
                button1.Width = 2 * button1.Width;
                compara = true;
            }
            if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0 )
            {

                if (textBox1.Text.Any(c => char.IsDigit(c)) || textBox1.TextLength > 15)
                {
                    textBox1.BackColor = Color.Black;
                    ok = 0;
                }
                if (textBox2.Text.Any(c => char.IsDigit(c)) || textBox2.TextLength > 15)
                {
                    textBox2.BackColor = Color.Black;
                    ok = 0;
                }
                if (!int.TryParse(textBox3.Text, out _))
                {
                    textBox3.BackColor = Color.Black;
                    ok = 0;
                }

                if (!long.TryParse(textBox4.Text, out _) || textBox4.TextLength > 13)
                {
                    textBox4.BackColor = Color.Black;
                    ok = 0;
                }



                if (ok == 1)
                {

                    button1.Text = "Angajatul s-a salvat";
                    button1.BackColor = Color.White;
                    nrAngajati = nrAngajati + 1;
                    angajat = new Angajat(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                    adminAngajati.AdaugareAngajat(angajat);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                if (ok == 0)
                {
                    button1.Text = "Nu ati introdus date corecte!";
                    button1.BackColor = Color.Black;
                }

            }
            else
            {
                button1.Text = "Completati toate datele!";
                button1.BackColor = Color.Red;
                if (textBox1.Text.Length == 0)
                    textBox1.BackColor = Color.LightPink;

                if (textBox2.Text.Length == 0)
                    textBox2.BackColor = Color.LightPink;

                if (textBox3.Text.Length == 0)
                    textBox3.BackColor = Color.LightPink;
                if (textBox4.Text.Length == 0)
                    textBox4.BackColor = Color.LightPink;



            }

            button1.Left = (this.ClientSize.Width - button1.Width) / 2;
        }
    }
}
