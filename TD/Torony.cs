using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD
{
    class Torony
    {
        private int ismSeb;
        private int y;
        private int x;
        private int hatotav;
        private int toronyIterator;
        private int Y { get => y; set => y = value; }
        private int X { get => x; set => x = value; }
        private int Hatotav { get => hatotav; set => hatotav = value; }
        private int IsmSeb { get => ismSeb; set => ismSeb = value; }
        private int ToronyIterator { get => toronyIterator; set => toronyIterator = value; }

        public Torony(int y, int x, int hatotav, int ismSeb)
        {
            Y = y;
            X = x;
            Hatotav = hatotav;
            IsmSeb = ismSeb;
            toronyIterator = 1;
        }
        public bool Loves() //A tornyok lövését kezelő metódus, ismétlési sebességet ellenőriz elsőnek
        {
            if (ismSeb != ToronyIterator)
            {
                ToronyIterator++;
                return false;
            }
            else toronyIterator = 1;
            var idOsveny = Osveny.GetOsveny();
            int xPoz = 0;
            for (int i = 0; i < Hatotav; i++)
            {
                for (int j = 0; j < Hatotav; j++)
                {
                    if (X - Hatotav+i < 50 && X-Hatotav+i > 0)
                    xPoz = X - Hatotav+i;
                    switch(idOsveny[1, xPoz])
                    {
                        case 4:
                            for (int v = 0; v < Torzs.Szornyek.Length; v++)
                            {
                                if (Torzs.Szornyek[v].Y == (x-Hatotav+i))
                                {
                                    Torzs.Szornyek[v].Elet -= 1;
                                    Torzs.Szornyek[v].Destroy();
                                    return true;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return false;
        }
    }
}
