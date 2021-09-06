using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD
{
    class ToronySorsolas
    {
        // Nem volt konkrét érték/teszteset a feladatban szóval hasraütéssel választottam meg a tornyok számát, a sorsolásuk véletlenszerű.
        static Random r = new Random();
        public static void ToronySorsolasEsElhelyezes()
        {
            Console.Clear();
            var idOsveny = Osveny.GetOsveny();
            int random = 0;
            Osveny.Osveny_Kiir();
            int y = 0;
            string sorsolt = "";
            for (int i = 0; i < Torzs.maxTornyok; i++)
            {
                if (Torzs.jelenTornyok < Torzs.maxTornyok)
                {
                    random = r.Next(0, 101);
                    if (random <= 25) sorsolt = "Piros torony\nIsmétlési sebesség: 3\nHatótáv:9";
                    else if (random >= 26 && random <= 60) sorsolt = "Sárga torony\nIsmétlési sebesség: 3\nHatótáv:6";
                    else if (random >= 61) sorsolt = "Kék torony\nIsmétlési sebesség: 2\nHatótáv:2";
                    Console.WriteLine(sorsolt);
                    y = 0;
                    switch (sorsolt.Split(' ')[0])
                    {
                        case "Piros":
                            Console.WriteLine("Hova?");
                            y = int.Parse(Console.ReadLine());
                            idOsveny[2, y] = 7;
                            Torzs.Tornyok[Torzs.jelenTornyok++] = new Torony(2, y, 9, 3);
                            Console.Clear();
                            Osveny.Osveny_Kiir();
                            break;
                        case "Sárga":
                            Console.WriteLine("Hova?");
                            y = int.Parse(Console.ReadLine());
                            idOsveny[2, y] = 6;
                            Torzs.Tornyok[Torzs.jelenTornyok++] = new Torony(2, y, 6, 3);
                            Console.Clear();
                            Osveny.Osveny_Kiir();
                            break;
                        case "Kék":
                            Console.WriteLine("Hova?");
                            y = int.Parse(Console.ReadLine());
                            idOsveny[2, y] = 5;
                            Torzs.Tornyok[Torzs.jelenTornyok++] = new Torony(2, y, 2, 2);
                            Console.Clear();
                            Osveny.Osveny_Kiir();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Nem helyezhetsz el több tornyot!");
                    break;
                };
                
            }
        }
    }
}
