using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using StocareMedicamente;
using AngajatiFarmacie;
using System.Configuration;

namespace AdministrareFarmacie
{

    public class Administrare
    {
        private const int nrMaxMedicamente = 1000;
        private const int nrMaxAngajati = 100;
        private string numeFisier;

        public Administrare(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AdaugareAngajat(Angajat angajat)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(angajat.ConversieLaSir_PentruFisier());
            }
        }
        public void AdaugareMedicament( Medicament medicament)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(medicament.ConversieLaSir_PentruFisier_Medicament());
            }
        }
        public Angajat[] GetAngajati(out int nrAngajati)
        {
            Angajat[] angajat = new Angajat[nrMaxAngajati];
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier; 
                nrAngajati = 0;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    angajat[nrAngajati++] = new Angajat(linieFisier);
                }
            }
            Array.Resize(ref angajat, nrAngajati);
            return angajat;
        }
        public Medicament[] GetMedicamente(out int nrMedicamente)
        {
            Medicament[] medicament = new Medicament[nrMaxMedicamente];
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrMedicamente = 0;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    medicament[nrMedicamente++] = new Medicament(linieFisier);
                }
            }
            Array.Resize(ref medicament, nrMedicamente);
            return medicament;
        }

        public void AdaugareAngajat(Angajat[] angajati)
        {
            throw new NotImplementedException();
        }

        public Angajat CautareAngajat(string nume, string prenume)
        {
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    Angajat angajat = new Angajat(linieFisier);
                    if (angajat.Nume == nume && angajat.Prenume == prenume)
                        return angajat;
                }

            }
            Angajat a = new Angajat();
            return a;

        }

    }
}
