using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace berek2020
{
    internal class Dolgozo
    {
        public string Nev { get; set; }
        public string Neme { get; set; }
        public string Reszleg { get; set; }
        public int BelepesEve { get; set; }
        public int Ber { get; set; }

        public Dolgozo(string sor)
        {
            var adatok = sor.Split(';');
            Nev = adatok[0];
            Neme = adatok[1];
            Reszleg = adatok[2];
            BelepesEve = int.Parse(adatok[3]);
            Ber = int.Parse(adatok[4]);
        }

        public override string ToString()
        {
            return $"{Nev}, {Neme}, {Reszleg}, {BelepesEve}, {Ber} Ft";
        }
    }
}
