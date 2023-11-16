using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartotekaMestLekce6
{
    internal class Mesto
    {
        public String nazev;
        public Kraj kraj;
        public int pocetObyvatel;
        public bool jeKrajskeMesto;
        //public String[] rieka;
        //public List<String> rieka;
        public List<Rieka> rieka;
    }
    enum Kraj
    {
        Jihočeský,
        Jihomoravský,
        Karlovarský,
        Královéhradecký,
        Liberecký,
        Moravskoslezský,
        Olomoucký,
        Pardubický,
        Plzeňský,
        Praha,
        Středočeský,
        Ústecký,
        Vysočina,
        Zlínský
    }
    enum Rieka
    {
        Bečva,
        Berounka,
        Bílina,
        Blanice,
        Cidlina,
        Dyje,
        Chrudimka,
        Jihlava,
        Jizera,
        Labe,
        Loučná,
        Lužnice,
        Malše,
        Metuje,
        Morava,
        Moravice,
        Mže,
        Odra,
        Ohře,
        Orlice,
        Oslava,
        Ostravice,
        Otava,
        Ploučnice,
        Radbuza,
        Rokytka,
        Sázava,
        Střela,
        Svitava,
        Svratka,
        Úhlava,
        Úpa,
        Úslava,
        Vltava,
        Želivka
    }

}
