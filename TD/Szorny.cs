using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD
{
    class Szorny
    {
        private int x;
        private bool halott;
        private int elet;
        private int y;
        private bool el;
        private readonly int[] Helyzet;

        public int Elet { get => elet; set => elet = value; }
        public int Y { get => y; set => y = value; }
        public int X { get => x; set => x = value; }
        public bool El { get => el; set => el = value; }
        public bool Halott { get => halott; set => halott = value; }
        private bool Irany() //Megszabja a szörnyek haladási irányát és a "mozgathatóság" feltételét
        {
            var idOsveny = Osveny.GetOsveny();
            if (idOsveny[x, y + 1] == 0 || idOsveny[x, y + 1] == 4 || idOsveny[x,y + 1] == 3) //Csak akkor lépnek ha előttük üres mező(0) vagy másik szörny(4), vagy az end mező(3) van
            {
                idOsveny[x,y] = 0;
                y++;
                idOsveny[x, y] = 4;
                Osveny.SetOsveny(idOsveny);
                return true;
            }
            return false;
        }
        public void Lepes()  //Ha halott a példány nem lép, ha nem teljesül a "mozgathatóság" feltétele nem lép és a játék véget ér
        {
            if (halott) return;
            if (!Irany()) Torzs.JatekVege = true;
        }
        public void Destroy() //Ha egy szörny élete 0, eltávolítja az ösvényről és az adott szörny példány halott állapotú lesz
        {
            if (Elet <= 0)
            {
                Halott = true;
                var idOsveny = Osveny.GetOsveny();
                idOsveny[X, Y] = 0;
            }
        }
        public Szorny(int elet, int[] helyzet)
        {
            Elet = elet;
            Helyzet = helyzet;
            X = helyzet[0];
            Y = helyzet[1];
            Halott = false;
            El = true;
        }
    }
}
