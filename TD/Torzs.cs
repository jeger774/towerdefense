using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TD
{
    class Torzs
    {
        private const int sleep = 300; //Többször használt konstans érték a program lassításához
        public const int maxTornyok = 5; 
        public static Torony[] Tornyok;
        public static int jelenTornyok;
        public static Szorny[] Szornyek;
        public static bool NincsTobbSzorny = false;
        public static bool JatekVege = false;
        static void Main(string[] args)
        {
            Init();
            Console.ReadKey();
        }
        public static void Init() //A játékhoz szükséges alapok beolvasása, létrehozása, majd felhasználói bemenetre várakozik
        {
            Osveny osveny = new Osveny(); 
            jelenTornyok = 0;
            Tornyok = new Torony[maxTornyok];
            Beolvasas.Beolvas();
            Bemenet.Input();
        }
        static Random r = new Random();
        public static bool Start()
        {
            Szornyek = new Szorny[r.Next(1, 11)]; //Véletlenszerű mennyiségű szörny létrehozása véletlenszerű életerővel (A feladatban nem volt konkrét érték vagy teszteset)
            for (int i = 0; i < Szornyek.Length; i++)
            {
                Szornyek[i] = new Szorny(r.Next(1,4), Osveny.kezdo);
                for (int j = 0; j < i; j++)
                {
                    Szornyek[j].Lepes();
                }
                foreach (var item in Tornyok) //Lő a tornyokkal
                {
                    if (item != null) item.Loves();
                }
                Osveny.Osveny_Kiir();
                Thread.Sleep(sleep);
            }
            while (true)
            {
                for (int k = 0; k < Szornyek.Length; k++) //Mozgatja az összes szörnyet
                {
                    Szornyek[k].Lepes();
                }
                foreach (var item in Tornyok) //Lő a tornyokkal
                {
                    if (item != null) item.Loves();
                }
                int halottak = 0;
                foreach (var item in Szornyek) //Ellenőrzi halt-e meg szörny, ha igen hozzáadja a halottak számához
                {
                    if (item.Halott)
                    {
                        halottak++;
                    }
                }
                if (halottak == Szornyek.Length) //Ha a halottak száma egyenlő az összes szörny számával -> igaz -> játék vége
                {
                    Console.Clear();
                    Osveny.Osveny_Kiir();
                    NincsTobbSzorny = true;
                    Console.WriteLine("Gratulálok, nyertél!");
                    return true;
                }
                if (JatekVege) //Ha Szörny ér az "E" mezőhöz -> igaz -> a játék megáll
                {
                    Console.Clear();
                    Osveny.Osveny_Kiir();
                    NincsTobbSzorny = false;
                    Console.WriteLine("Sajnos vesztettél.");
                    return false;
                }
                Osveny.Osveny_Kiir(); //Minden mozgás után újra kirajzolja az ösvényt
                Thread.Sleep(sleep);
            }
        }
    }
}
