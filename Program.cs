using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace KartotekaMestLekce6
{
    internal class Program
    {
        static public List<Mesto> seznamMest = new List<Mesto>();

        static void Main(string[] args)
        {
            vytvorSeznamMest();
            VyberMenu();
        }
        static void VyberMenu()
        {
            int volba;
            Console.WriteLine("Vyber číselnou volbu: \n 1) Vypsat krajská města \n 2) Vypsat města na zadané řece  \n 3) Vypsat města s počtem obyvatel menším než...\n 4) Vypsat města s počtem obyvatel větším než... \n 5) Vypsat města v daném kraji \n 6) Vypsat města začínající na zadané písmeno (písmena) \n 7) Vypsat krajská města na Labi\n 8) Ukonči \n");
            while (!int.TryParse(Console.ReadLine(), out volba) || (volba < 1) || (volba > 8)) Console.WriteLine("Zadej číslo od 1 do 8.");
            Console.WriteLine();
            switch (volba)
            {
                case 1:
                    Console.WriteLine("Vypsání krajských měst:\n");
                    Console.WriteLine(vypisList(seznamMest.Where(x => x.jeKrajskeMesto == true).OrderBy(x=>x.nazev).ToList()));
                    Console.ReadLine();
                    VyberMenu();
                    break;
                case 2:
                    Console.Write("Zadej název řeky: ");
                    Rieka rieka = new Rieka();
                    while (!Enum.TryParse(formatovat(Console.ReadLine()), out rieka)) Console.WriteLine("Napiš platný název řeky.");
                    //Rieka nazevReky = (Rieka)14;
                    Console.WriteLine(vypisList(seznamMest.Where(x => x.rieka.Contains(rieka)).OrderBy(x => x.nazev).ToList())); 
                    Console.ReadLine();
                    VyberMenu();
                    break;
                case 3:
                    Console.Write("Zadej počet obyvatel pro vypsání měst s méně obyvateli než: ");
                    int obyvatele;
                    while (!int.TryParse(Console.ReadLine(), out obyvatele)) Console.WriteLine("Zadej kladné celé číslo.");
                    Console.WriteLine(vypisList(seznamMest.Where(x => x.pocetObyvatel<obyvatele).OrderByDescending(x => x.pocetObyvatel).ToList()));
                    Console.ReadLine();
                    VyberMenu();
                    break;
                case 4:
                    Console.Write("Zadej počet obyvatel pro vypsání měst s více obyvateli než: ");
                    while (!int.TryParse(Console.ReadLine(), out obyvatele)) Console.WriteLine("Zadej kladné celé číslo.");
                    Console.WriteLine(vypisList(seznamMest.Where(x => x.pocetObyvatel > obyvatele).OrderByDescending(x => x.pocetObyvatel).ToList()));
                    Console.ReadLine();
                    VyberMenu();
                    break;
                case 5:
                    volba = 0;
                    foreach (Kraj kraj in Enum.GetValues(typeof(Kraj)))
                    {
                        volba++;
                        Console.WriteLine(volba + ". "+kraj.ToString());
                    }
                    Console.Write("zadej číslo kraje, kterého města chceš vypsat: ");
                    while (!int.TryParse(Console.ReadLine(), out volba) || (volba < 1) || (volba > Enum.GetValues(typeof(Kraj)).Length)) Console.WriteLine("Zadej číslo kraje.");
                    Kraj vybranyKraj = (Kraj)volba-1;
                    Console.WriteLine("Města v kraji "+vybranyKraj+":");
                    Console.Write(vypisList(seznamMest.Where(x => x.kraj == vybranyKraj).OrderBy(x => x.nazev).ToList()));
                    Console.ReadLine();
                    VyberMenu();
                    break;
                case 6:
                    Console.Write("Zadej počáteční písmeno / písmena: ");
                    String pocatecniPismena = formatovat(Console.ReadLine());
                    Console.WriteLine(vypisList(seznamMest.Where(x => x.nazev.StartsWith(pocatecniPismena)).OrderBy(x => x.nazev).ToList()));
                    Console.ReadLine();
                    VyberMenu();
                    break;
                case 7:
                    Console.WriteLine("Výpis krajských měst na Labi: ");
                    Console.WriteLine(vypisList(seznamMest.Where(x => x.jeKrajskeMesto==true && x.rieka.Contains(Rieka.Labe)).OrderBy(x => x.nazev).ToList()));
                    Console.ReadLine();
                    VyberMenu();
                    break;
                case 8:
                    Console.WriteLine("ukončit.\n");
                    break;
            }
        }
            static void vytvorSeznamMest()
        {
            seznamMest.Add(new Mesto() { nazev = "Praha", jeKrajskeMesto = true, kraj = Kraj.Praha, pocetObyvatel = 1272690, rieka = new List<Rieka>{ Rieka.Vltava, Rieka.Berounka, Rieka.Rokytka } });
            seznamMest.Add(new Mesto() { nazev = "Brno", jeKrajskeMesto = true, kraj = Kraj.Jihomoravský, pocetObyvatel = 384277, rieka = new List<Rieka>{ Rieka.Svratka, Rieka.Svitava } });
            seznamMest.Add(new Mesto() { nazev = "Český Krumlov", jeKrajskeMesto = false, kraj = Kraj.Jihočeský, pocetObyvatel = 13056, rieka = new List<Rieka>{ Rieka.Vltava } });
            seznamMest.Add(new Mesto() { nazev = "Kroměříž", jeKrajskeMesto = false, kraj = Kraj.Zlínský, pocetObyvatel = 28880, rieka = new List<Rieka>{ Rieka.Morava } });
            seznamMest.Add(new Mesto() { nazev = "Hradec Králové", jeKrajskeMesto = true, kraj = Kraj.Královéhradecký, pocetObyvatel = 93506, rieka = new List<Rieka>{ Rieka.Labe, Rieka.Orlice } });
            seznamMest.Add(new Mesto() { nazev = "Pardubice", jeKrajskeMesto = true, kraj = Kraj.Pardubický, pocetObyvatel = 90458, rieka = new List<Rieka> { Rieka.Labe, Rieka.Chrudimka } });
            seznamMest.Add(new Mesto() { nazev = "Kolín", jeKrajskeMesto = false, kraj = Kraj.Středočeský, pocetObyvatel = 33289, rieka = new List<Rieka> { Rieka.Labe } });
            seznamMest.Add(new Mesto() { nazev = "Rychnov nad Kněžnou", jeKrajskeMesto = false, kraj = Kraj.Královéhradecký, pocetObyvatel = 11178, rieka = new List<Rieka> { } });
            seznamMest.Add(new Mesto() { nazev = "Jihlava", jeKrajskeMesto = true, kraj = Kraj.Vysočina, pocetObyvatel = 50891, rieka = new List<Rieka> { Rieka.Jihlava } });
            seznamMest.Add(new Mesto() { nazev = "Děčín", jeKrajskeMesto = false, kraj = Kraj.Ústecký, pocetObyvatel = 47180, rieka = new List<Rieka> { Rieka.Labe, Rieka.Ploučnice } });
            seznamMest.Add(new Mesto() { nazev = "Liberec", jeKrajskeMesto = true, kraj = Kraj.Liberecký, pocetObyvatel = 107389, rieka = new List<Rieka> { Rieka.Nisa } });
        }
        static string vypisList(List<Mesto> listMest)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var mesto in listMest) sb.Append(mesto.nazev.PadRight(25)+"počet obyvatel: "+mesto.pocetObyvatel+"\n");
            return sb.ToString();
        }
        static string formatovat(String s)
        {
            s = s.First().ToString().ToUpper()+s.Substring(1).ToLower();
            return s;
        }


    }
}
