using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORPG.Entiteti
{
    public class Igrac
    {
        public virtual int Id { get; protected set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Nadimak { get; set; }
        public virtual string Lozinka { get; set; }
        public virtual char Pol { get; set; }
        public virtual int Uzrast { get; set; }

        public virtual Tim Tim { get; set; }
        public virtual Lik Lik { get; set; }
        public virtual IList<Sesija> Sesije { get; set; }
        public virtual IList<Pomocnik> Pomocnici { get; set; }
        public virtual IList<Proizvod> Proizvodi { get; set; }

        public Igrac()
        {
            Sesije = new List<Sesija>();
            Pomocnici = new List<Pomocnik>();
            Proizvodi = new List<Proizvod>();
        }

    }
}
