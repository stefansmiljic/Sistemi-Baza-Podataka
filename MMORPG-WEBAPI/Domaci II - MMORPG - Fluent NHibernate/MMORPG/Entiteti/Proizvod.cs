using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORPG.Entiteti
{
    public class Proizvod
    {
        public virtual string Naziv { get; set; }
        public virtual string Tip { get; set; }
        public virtual string Opis { get; set; }
        public virtual string Klase { get; set; }
        public virtual string Rase { get; set; }
        public virtual IList<Igrac> Igraci { get; set; }
        public Proizvod() 
        {
            Igraci = new List<Igrac>();
        }
    }
    public class Oklop : Proizvod 
    {
        public virtual int PoeniZaOdbranu { get; set; }
    }
    public class Oruzje : Proizvod
    {
        public virtual int PoeniZaNapad { get; set; }
    }
}
