using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORPG_API.Entiteti
{
    public class Staza
    {
        public virtual string Naziv { get; set; }
        public virtual int BonusPoeni { get; set; }
        public virtual string Potrebne_Rase { get; set; }
        public virtual string Potrebne_Klase { get; set; }
        public virtual string Tip { get; set; }

        public virtual IList<Predmet> Predmeti { get; set; }
    }
    public class StazaZaIgraca : Staza
    {
        public virtual int BrIgranjaStaze { get; set; }
        public virtual int BrUbijenihNeprijatelja { get; set; }
        public virtual Igrac Igrac { get; set; }
    }
    public class StazaZaTim : Staza
    {
        public virtual Tim Tim { get; set; }
    }
}
