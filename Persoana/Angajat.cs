using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persoana
{
    public class Angajat
    {
        private const char Separator_Principal_Fisier = ' ';
        private const int Id = 0;
        private const int Nume = 1;
        private const int Prenume = 2;

        private int idAngajat;
        private string nume;
        private string prenume;

        public Angajat()
        {
            nume = prenume = string.Empty;
        }
        public Angajat(int idAngajat, string nume, string prenume)
        {
            this.idAngajat = idAngajat;
            this.nume = nume;
            this.prenume = prenume;
        }
        public Angajat(string linieFis)
        {
            var dateFis = linieFis.Split(Separator_Principal_Fisier);
            idAngajat = Convert.ToInt32(dateFis[Id]);
            nume = dateFis[Nume];
            prenume = dateFis[Prenume];
        }
        public string ConversieSir_PtFis()
        {
            string obiectAngajatPtFis = string.Format("{1}{0}{2}{0}{3}{0}",
                Separator_Principal_Fisier,
                idAngajat.ToString(),
                (nume ?? "NECUNOSCUT"),
                (prenume ?? "NECUNOSCUT"));
            return obiectAngajatPtFis;
        }
        public int GetIdAngajat()
        {
            return idAngajat;
        }
        public string GetNume()
        {
            return nume;
        }
        public string GetPrenume()
        {
            return prenume;
        }
        public void SetIdAngajat(int idAngajat)
        {
            this.idAngajat = idAngajat;
        }

    }
}
