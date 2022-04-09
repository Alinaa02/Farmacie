using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieMedicament;
using NivelStocareMedicamente;
using System.Configuration;
using AdministrareAngajati_FisierText;
using Persoana;

namespace Farmacie
{
    class Program
    {

        static void Main(string[] args)
        {
            argumente(args);

            Medicament medNou = new Medicament();
            int nrMedicamente = 0;
            string numeFisier = ConfigurationManager.AppSettings.Get("numeFisier");
            AdministrareMedicamente_FisierText adminMed = new AdministrareMedicamente_FisierText(numeFisier);
            adminMed.GetMedicamente(out nrMedicamente);

            Angajat angajatFar = new Angajat();
            int nrAngajati = 0;
            string numeFis = ConfigurationManager.AppSettings.Get("numeFis");
            AdministrarePersonal adminisAng = new AdministrarePersonal(numeFis);
            adminisAng.GetAngajati(out nrAngajati);

            string optiune;
            do
            {
                Console.WriteLine("C. Citire informatii medicamente de la tastatura.");
                Console.WriteLine("A. Afisarea ultimului medicament introdus.");
                Console.WriteLine("F. Afisarea medicamentelor din fisier.");
                Console.WriteLine("S. Salvare medicament in fisier.");
                Console.WriteLine("L. Citire angajati farmacie.");
                Console.WriteLine("R. Afisarea ultimului angajat adaugat.");
                Console.WriteLine("M. Afisare angajati farmacie.");
                Console.WriteLine("N. Salvare angajati farmacie.");
                Console.WriteLine("P. Cautare angajat farmacie.");
                Console.WriteLine("X. Inchidere program.");
                Console.WriteLine("Alegeti o optiune.");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "C":
                        medNou = CitireMedTastatura();
                        break;
                    case "A":
                        AfisareMed(medNou);
                        break;
                    case "F":
                        Medicament[] medicamente = adminMed.GetMedicamente(out nrMedicamente);
                        AfisareMedicamente(medicamente, nrMedicamente);
                        break;
                    case "S":
                        int idMedicament = nrMedicamente + 1;
                        medNou.SetIdMedicament(idMedicament);
                        //se adauga un nou medicament in fisier
                        adminMed.AdaugareMedicament(medNou);
                        nrMedicamente = nrMedicamente + 1;

                        break;
                    case "L":
                        angajatFar = CitireAngajatTastatura();
                        break;
                    case "R":
                        AfisareAngajat(angajatFar);
                        break;
                    case "M":
                        Angajat[] angajati = adminisAng.GetAngajati(out nrAngajati);
                        AfisareAngajati(angajati, nrAngajati);
                        break;
                    case "N":
                        int idAngajat = nrAngajati + 1;
                        angajatFar.SetIdAngajat(idAngajat);
                        adminisAng.AdaugareAngajat(angajatFar);
                        nrAngajati++;
                        break;
                    case "P":
                        string nume, prenume;
                        Console.WriteLine("Introduceti numele: ");
                        nume = Console.ReadLine();
                        Console.WriteLine("Introduceti prenumele: ");
                        prenume = Console.ReadLine();
                        Console.WriteLine(adminisAng.CautareAngajat(nume, prenume).ConversieSir_PtFis());
                        break;
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta.");
                        break;
                }
            } while (optiune.ToUpper() != "X");
            Console.ReadKey();
        }

        private static void AfisareAngajati(object angajati, int nrAngajati)
        {
            throw new NotImplementedException();
        }
        public static void AfisareMed(Medicament medicament)
        {
            string infoMedicament = string.Format("Medicamentul cu id-ul #{0} poarta denumirea de: {1}",
                medicament.GetIdMedicament(),
                medicament.GetNume() ?? "NECUNOSCUT");

            Console.WriteLine(infoMedicament);
        }

        public static void AfisareMedicamente(Medicament[] medicamente, int nrMedicamente)
        {
            Console.WriteLine("Medicamentele sunt: ");
            for (int i = 0; i < nrMedicamente; i++)
            {
                AfisareMed(medicamente[i]);
            }
        }

        public static Medicament CitireMedTastatura()
        {
            Console.WriteLine("Introduceti numele medicamentului: ");
            string nume = Console.ReadLine();

            Medicament medicament = new Medicament(0, nume);

            return medicament;
        }
        public static void AfisareAngajat(Angajat angajat)
        {
            string infoAngajat = string.Format("Angajatul cu id-ul #{0} are numele: {1} {2}",
                angajat.GetIdAngajat(),
                angajat.GetNume() ?? "NECUNOSCUT",
                angajat.GetPrenume() ?? "NECUNOSCUT");
            Console.WriteLine(infoAngajat);
        }
        public static void AfisareAngajati(Angajat[] angajati, int nrAngajati)
        {
            Console.WriteLine("Angajatii farmaciei sunt: ");
            for (int i = 0; i < nrAngajati; i++)
            {
                AfisareAngajat(angajati[i]);
            }
        }
        public static Angajat CitireAngajatTastatura()
        {
            Console.WriteLine("Introduceti numele: ");
            string nume = Console.ReadLine();
            Console.WriteLine("Introduceti prenumele: ");
            string prenume = Console.ReadLine();
            Angajat angajat = new Angajat(0, nume, prenume);
            return angajat;
        }
        public static void argumente(string[] args)
        {
            int i = 0;
            var aaa = args.GroupBy(arg => arg.First()).OrderBy(arg => arg.Key).ToList();
            string[][] lin = new string[aaa.Count()][];
            foreach (var bbb in aaa)
            {
                int j = 0;
                lin[i] = new string[bbb.Count()];
                foreach (var bin in bbb)
                {
                    lin[i][j] = bin;
                    j++;
                }
                i++;
            }
            foreach (var linie in lin)
            {
                Console.WriteLine($"{linie.First()[0]}:");
                foreach (var car in linie)
                {
                    Console.WriteLine(car + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
