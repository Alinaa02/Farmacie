using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieMedicament
{
    public class Medicament
    {
        //initializare constante
        private const char Separator_Principal_Fisier = ';';

        private const int ID = 0;
        private const int Nume = 1;

        //proprietati auto-implemented
        private int idMedicament; //identificator unic medicament
        private string nume;

        //constructor implicit
        public Medicament()
        {
            nume = string.Empty;
        }

        //constructor cu parametri
        public Medicament(int idMedicament, string nume)
        {
            this.idMedicament = idMedicament;
            this.nume = nume;
        }

        //constructor cu un singur parametru de tip string care reprezinta o linie dintr-un fisier
        public Medicament(string linieFisier)
        {
            var dateFisier = linieFisier.Split(Separator_Principal_Fisier);

            //ordinea de preluare a campurilor
            idMedicament = Convert.ToInt32(dateFisier[ID]);
            nume = dateFisier[Nume];

        }
        public string ConversieLaSir_PtFisier()
        {
            string obiectMedPentruFisier = string.Format("{1}{0}{2}",
                Separator_Principal_Fisier,
                idMedicament.ToString(),
                (nume ?? " NECUNOSCUT "));

            return obiectMedPentruFisier;
        }

        public int GetIdMedicament()
        {
            return idMedicament;
        }

        public string GetNume()
        {
            return nume;
        }

        public void SetIdMedicament(int idMedicament)
        {
            this.idMedicament = idMedicament;
        }
    }
}
