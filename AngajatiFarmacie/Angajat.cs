using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngajatiFarmacie
{
    public class Angajat
    {
        //initializare constante
        private const char Separator_Principal_Fisier = ';';
        private const int NUME = 0;
        private const int PRENUME = 1;
        private const int VARSTA = 2;
        private const int COD_ANGAJAT = 3;

        //proprietati auto-implemented
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Varsta { get; set; }
        public string CodAngajat { get; set; }

        //constructor implicit
        public Angajat()
        {
            Nume = string.Empty;
            Prenume = string.Empty;
            Varsta = string.Empty;
            CodAngajat = string.Empty;
        }
        public Angajat(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(Separator_Principal_Fisier);
            Nume = dateFisier[NUME];
            Prenume = dateFisier[PRENUME];
            Varsta = dateFisier[VARSTA];
            CodAngajat = dateFisier[COD_ANGAJAT];
        }
        //constructor cu parametri
        public Angajat(string nume, string prenume, string varsta, string codAngajat)
        {
            Nume = nume;
            Prenume = prenume;
            Varsta = varsta;
            CodAngajat = codAngajat;

        }
        public void Citire_Angajat()
        {
            Console.WriteLine("Introduceti numele angajatului: ");
            Nume = Console.ReadLine();
            Console.WriteLine("Introduceti prenumele angajatului: ");
            Prenume = Console.ReadLine();
            Console.WriteLine("Introduceti varsta: ");
            Varsta = Console.ReadLine();
            Console.WriteLine("Introduceti codul angajatului: ");
            CodAngajat = Console.ReadLine();
        }
        public string AngajatInfo()
        {
            return $" Nume: {Nume} \n Prenume: {Prenume}  \n   Varsta: {Varsta}  \n Cod Angajat:  {CodAngajat} ";
        }
        public string ConversieLaSir_PentruFisier()
        {
            string obiectAngajatPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}",
                Separator_Principal_Fisier,
                (Nume ?? " NECUNOSCUT "),
                (Prenume ?? " NECUNOSCUT "),
                (Varsta ?? " NECUNOSCUT "),
                (CodAngajat ?? " NECUNOSCUT "));

            return obiectAngajatPentruFisier;
        }
    }
}
