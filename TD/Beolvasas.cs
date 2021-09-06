using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Resources;

namespace TD
{
    class Beolvasas
    {
        public static void Beolvas() //A solutionhöz mellékelt .map fájl beolvasása
        {
            int n = File.ReadAllLines("palya.map").Length;
            StreamReader sr = new StreamReader("palya.map");
            string temp = "";
            bool osvenyVege = false;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                temp = sr.ReadLine();
                if (!(temp[0] == '#'))
                {
                    if (!osvenyVege && temp[0] == '-')
                    {
                        sb.Append($"{temp}\n");
                    }
                    else if (!osvenyVege)
                    {
                        osvenyVege = true;
                        sb.Remove(sb.Length-1, 1);
                        Osveny.SetOsveny(sb.ToString().Split('\n'));
                    }
                }
            }
        }
    }
}


