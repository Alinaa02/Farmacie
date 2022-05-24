using System;
using System.Linq;
using System.Configuration;
using System.IO;
using AdministrareFarmacie;
using StocareMedicamente;
using AngajatiFarmacie;


namespace FarmacieGestiune
{
    class Program
    {
        static void Main(string[] args)
        {
            argumente(args);


            string NumeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string _NumeFisier = ConfigurationManager.AppSettings["_NumeFisier"];

            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + NumeFisier;
            Administrare adminMedicamente = new Administrare(caleCompletaFisier);

            string locatieFisierSolutieAngj = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisierAngj = locatieFisierSolutieAngj + "\\" + _NumeFisier;
            Administrare adminAngajati = new Administrare(caleCompletaFisierAngj);


            int nrMedicamente = 0;
            int nrAngajati = 0;

            adminMedicamente.GetMedicamente(out nrMedicamente);
            Medicament medicament = new Medicament();
            Angajat angajat = new Angajat();

            string optiune;
            do
            {
                Console.WriteLine("\nC. Citire informatii medicamente de la tastatura.");
                Console.WriteLine("F. Afisarea medicamentelor din fisier.");
                Console.WriteLine("S. Salvare medicament in fisier.");
                Console.WriteLine("L. Citire angajati farmacie.");
                Console.WriteLine("M. Afisare angajati farmacie.");
                Console.WriteLine("N. Salvare angajati farmacie.");
                Console.WriteLine("P. Cautare angajat farmacie.");
                Console.WriteLine("X. Inchidere program.");
                Console.WriteLine("Alegeti o optiune.\n");
                optiune = Console.ReadLine();
                switch(optiune.ToUpper())
                {
                    case "C":
                        medicament.Citire_Medicament();
                        Console.WriteLine(medicament.MedicamentInfo());
                        break;
                    case "F":
                        Medicament[] medicamente = adminMedicamente.GetMedicamente(out nrMedicamente);
                        AfisareMedicamente(medicamente, nrMedicamente);
                        break;
                    case "S":
                        adminMedicamente.AdaugareMedicament(medicament);
                        break;
                    case "L":
                        angajat.Citire_Angajat();
                        Console.WriteLine(angajat.AngajatInfo());
                        break;
                    case "M":
                        Angajat[] angajati = adminAngajati.GetAngajati(out nrAngajati);
                        AfisareAngajati(angajati, nrAngajati);
                        break;
                    case "N":
                       // nrAngajati = nrAngajati + 1;
                        adminAngajati.AdaugareAngajat(angajat);
                        break;
                    case "P":
                        string nume, prenume;
                        Console.WriteLine("Introduceti numele: ");
                        nume = Console.ReadLine();
                        Console.WriteLine("Introduceti prenumele: ");
                        prenume = Console.ReadLine();
                        Console.WriteLine(adminAngajati.CautareAngajat(nume, prenume).ConversieLaSir_PentruFisier());
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

        public static void AfisareMedicamente(Medicament[] medicament, int nrMedicamente)
        {
            Console.WriteLine("Medicamentele farmaciei sunt: ");
            for(int i = 0;i < nrMedicamente;i++)
            {
                string infoMedicamente = string.Format("Medicamentul cu denumirea {0} are un gramaj de {1} mg, administrandu-se sub forma de {2} si este folosit pentru dureri de {3}",
                    (medicament[i].Denumire ?? "NECUNOSCUT"),
                    (medicament[i].Gramaj ?? "NECUNOSCUT"),
                    (medicament[i].TipMedicament ?? "NECUNOSCUT"),
                    (medicament[i].TipDurere ?? "NECUNOSCUT"));

                Console.WriteLine(infoMedicamente);
            }
        }
        public static void AfisareAngajati(Angajat[] angajat, int nrAngajati)
        {
            Console.WriteLine("Angajatii farmaciei sunt: ");
            for (int i = 0; i < nrAngajati; i++)
            {
                string infoAngajati = string.Format("Angajatul cu numele  {0} {1}  are {2} de ani  si codul angajat {3}",
                    (angajat[i].Nume ?? "NECUNOSCUT"),
                    (angajat[i].Prenume ?? "NECUNOSCUT"),
                    (angajat[i].Varsta ?? "NECUNOSCUT"),
                    (angajat[i].CodAngajat ?? "NECUNOSCUT"));

                Console.WriteLine(infoAngajati);
            }
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
