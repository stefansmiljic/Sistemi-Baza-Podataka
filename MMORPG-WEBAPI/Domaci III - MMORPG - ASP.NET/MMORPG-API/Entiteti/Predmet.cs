using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORPG_API.Entiteti
{
    public class Predmet
    {
        public virtual string Naziv { get; set; }
        public virtual string Opis { get; set; }
        public virtual string Tip { get; set; }
        public virtual Staza NazivStaze { get; set; }
        public Predmet() { }
    }
    public class KljucniPredmet : Predmet
    {
        public virtual string NadimciLikova { get; set; }
    }
    public class PredmetXP : Predmet
    {
        public virtual int BonusUIskustvu { get; set; }
        public virtual string RasePremdet { get; set; }
    }
}
