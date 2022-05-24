using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocareMedicamente
{
    public class Medicament
    {
        //initializare constante
        private const char Separator_Principal_Fisier = ';';
        private const int DENUMIRE = 0;
        private const int GRAMAJ = 1;
        private const int TIP_MEDICAMENT = 2;
        private const int TIP_DURERE = 3;

        public enum Tip_Medicament
        {
            Pilule = 1,
            Capsule = 2,
            Unguent = 3,
            Picaturi = 4,
            Injectie = 5

        }
        //proprietati auto-implemented
        public string Denumire { get; set; }
        public string Gramaj { get; set; }
        public string TipMedicament { get; set; }
        public string TipDurere { get; set; }

        //constructor implicit
        public Medicament()
        {
            Denumire = string.Empty;
            Gramaj = string.Empty;
            TipMedicament = string.Empty;
            TipDurere = string.Empty;
        }
        //constructor cu parametri
        public Medicament(string denumire, string gramaj, string tipMedicament, string tipDurere)
        {
            Denumire = denumire;
            Gramaj = gramaj;
            TipMedicament = tipMedicament;
            TipDurere = tipDurere;

        }
        public void Citire_Medicament()
        {
            Console.WriteLine("Introduceti denumirea medicamentului: ");
            Denumire = Console.ReadLine();
            Console.WriteLine("Introduceti gramajul medicamentului: ");
            Gramaj = Console.ReadLine();
            Console.WriteLine("Introduceti tipul de medicament (pilule, capsule, unguent, picaturi, injectie): ");
            TipMedicament = Console.ReadLine();
            Console.WriteLine("Introduceti tipul de durere pe care il combate medicamentul (cap, spate, dinti, ochi, stomac):  ");
            TipDurere = Console.ReadLine();
        }
        public string MedicamentInfo()
        {
            return $" Denumire:       Gramaj:        Tip Medicament:        Tip Durere:     \n" +
                $"   {Denumire}      {Gramaj}            {TipMedicament}       {TipDurere}";
        }
        public Medicament(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(Separator_Principal_Fisier);
            Denumire = dateFisier[DENUMIRE];
            Gramaj = dateFisier[GRAMAJ];
            TipMedicament = dateFisier[TIP_MEDICAMENT];
            TipDurere = dateFisier[TIP_DURERE];
        }
        public string ConversieLaSir_PentruFisier_Medicament()
        {
            string obiectMedicamentPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}",
                Separator_Principal_Fisier, 
                (Denumire ?? " NECUNOSCUT "), 
                (Gramaj ?? " NECUNOSCUT "), 
                (TipMedicament ?? " NECUNOSCUT "), 
                (TipDurere ?? " NECUNOSCUT "));

            return obiectMedicamentPentruFisier;
        }

    }
}
