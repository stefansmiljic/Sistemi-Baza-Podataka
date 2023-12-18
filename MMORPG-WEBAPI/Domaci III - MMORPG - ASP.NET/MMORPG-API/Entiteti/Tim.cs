using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORPG_API.Entiteti
{
    public class Tim
    {
        public virtual string Naziv { get; set; }
        public virtual int Plasman { get; set; }
        public virtual int BonusPoeni { get; set; }
        public virtual int Max { get; set; }
        public virtual int Min { get; set; }

        public virtual IList<Igrac> Igraci { get; set; }
        //public virtual IList<TimVsTim> Mecevi { get; set; }
        public virtual StazaZaTim StazaZaTim { get; set; }

        public Tim()
        {
            Igraci = new List<Igrac>();
            //Mecevi = new List<TimVsTim>();
        }
    }
}
