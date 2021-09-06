using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD
{
    class Bemenet
    {
        public static bool Input() //A játék "menüje"
        {
            Osveny.Osveny_Kiir();
            while (true)
            {
                if (Torzs.NincsTobbSzorny) return true;
                if (Torzs.JatekVege) return true;
                Console.WriteLine("Tornyok elhelyezése: torony\nJáték indítása:start");
                switch (Console.ReadLine())
                {
                    case "start":
                        Torzs.Start();
                        break;
                    case "torony":
                        ToronySorsolas.ToronySorsolasEsElhelyezes();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
