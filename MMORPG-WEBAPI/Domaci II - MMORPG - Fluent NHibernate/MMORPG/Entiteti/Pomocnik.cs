using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORPG.Entiteti
{
    public class Pomocnik
    {
        public virtual int Id { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Rasa { get; set; }
        public virtual string Klasa { get; set; }
        public virtual int BonusUZastiti { get; set; }

        public virtual Igrac Igrac { get; set; }
    }
}
