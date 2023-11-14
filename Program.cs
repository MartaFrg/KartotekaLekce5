using KartotekaLekce5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kartoteka
{
    internal class Program
    {
        static Dictionary<String, int> TelefonniSeznam = new Dictionary<String, int>();
        static void Main(string[] args)
        {
            VyberMenu();
        }
        static void VyberMenu()
        {
            int volba;
            Console.WriteLine();
            Console.WriteLine("Vyber číselnou volbu: \n 1) Vypsat všechny údaje \n 2) Přidání kontaktu \n 3) Vyhledej telefonní číslo kontaktu \n 4) Ukonči \n");
            while (!int.TryParse(Console.ReadLine(), out volba) || (volba < 1) || (volba > 4)) Console.WriteLine("Zadej číslo od 1 do 4.");
            Console.Write("Tvoje volba je ");
            switch (volba)
            {
                case 1:
                    Console.WriteLine("vypsat všechny údaje.\n");
                    VypisVsechKontaktu();
                    break;
                case 2:
                    Console.WriteLine("přidat kontakt.\n");
                    PridatKontakt();
                    break;
                case 3:
                    Console.WriteLine("vyhledat kontakt.\n");
                    VyhledatKontakt();
                    break;
                case 4:
                    Console.WriteLine("ukončit.\n");
                    break;
            }
        }

        static void PridatKontakt()
        {
            string jmeno;
            int cisloTelefonu;
            Console.WriteLine("Zadej nový kontakt do telefonního seznamu:");
            Console.Write("Jméno: ");
            jmeno = Console.ReadLine();
            Console.Write("Telefonní číslo: ");
            while (!int.TryParse(Console.ReadLine(), out cisloTelefonu)) Console.WriteLine("Zadej platné telefonní číslo.");
            TelefonniSeznam.Add(jmeno, cisloTelefonu);
            VyberMenu();
        }
        static void VypisVsechKontaktu()
        {
            Console.WriteLine("jméno".PadRight(15) + "telefonní číslo");
            foreach (KeyValuePair<String, int> item in TelefonniSeznam)
            { Console.WriteLine(item.Key.PadRight(14) + " " + item.Value); }
            VyberMenu();
        }
        static void VyhledatKontakt()
        {
            Console.WriteLine("Zadej jméno hledaného kontaktu: ");
            string jmeno = Console.ReadLine();
            if (TelefonniSeznam.ContainsKey(jmeno))
            {
                Console.WriteLine();
                Console.WriteLine($"Telefonní číslo {jmeno} je {TelefonniSeznam[jmeno]}.");
            }
            else
            {
                Console.WriteLine("Požadovaná osoba není v seznamu.");
            }
            VyberMenu();
        }
    }
}
