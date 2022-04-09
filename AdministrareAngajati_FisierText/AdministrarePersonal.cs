using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persoana;

namespace AdministrareAngajati_FisierText
{
    public class AdministrarePersonal
    {
        private const int nrMaxAngajati = 100;
        private string numeFis;

        public AdministrarePersonal(string numeFis)
        {
            this.numeFis = numeFis;
            Stream streamFisText = File.Open(numeFis, FileMode.OpenOrCreate);
            streamFisText.Close();
        }
        public void AdaugareAngajat(Angajat angajat)
        {
            using (StreamWriter streamWriterFisText = new StreamWriter(numeFis, true))
            {
                streamWriterFisText.WriteLine(angajat.ConversieSir_PtFis());
            }
        }
        public Angajat[] GetAngajati(out int nrAngajati)
        {
            Angajat[] angajati = new Angajat[nrMaxAngajati];
            using (StreamReader streamReader = new StreamReader(numeFis))
            {
                string linieFisier;
                nrAngajati = 0;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    angajati[nrAngajati++] = new Angajat(linieFisier);
                }
            }
            return angajati;
        }
        public Angajat CautareAngajat(string nume, string prenume)
        {
            using (StreamReader streamReader = new StreamReader(numeFis))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    Angajat angj = new Angajat(linieFisier);
                    if (angj.GetNume() == nume && angj.GetPrenume() == prenume)
                        return angj;
                }

            }
            Angajat a = new Angajat();
            return a;

        }
    }
}
