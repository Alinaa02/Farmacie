using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieMedicament;

namespace NivelStocareMedicamente
{
    public class AdministrareMedicamente_FisierText
    {
        private const int Nr_max_medicamente = 100;
        private string numeFisier;

        public AdministrareMedicamente_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            //se incearca deschiderea fisierului si daca nu exista sa fie creat
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }
        public void AdaugareMedicament(Medicament medicament)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(medicament.ConversieLaSir_PtFisier());
            }
        }

        public Medicament[] GetMedicamente(out int nrMedicamente)
        {
            Medicament[] medicamente = new Medicament[Nr_max_medicamente];

            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrMedicamente = 0;

                //se citeste cate o linie si se creaza un obiect de tip Medicament
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    medicamente[nrMedicamente++] = new Medicament(linieFisier);
                }
            }
            return medicamente;
        }
    }
}
