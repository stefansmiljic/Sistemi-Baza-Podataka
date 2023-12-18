using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MMORPG_API.Entiteti;

namespace MMORPG_API.Mapiranja
{
    public class PomocnikMapiranja : ClassMap<Pomocnik>
    {
        public PomocnikMapiranja()
        {
            Table("POMOCNIK");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Ime, "IME");
            Map(x => x.Rasa, "RASA");
            Map(x => x.Klasa, "KLASA");
            Map(x => x.BonusUZastiti, "BONUS_U_ZASTITI");

            References(x => x.Igrac).Column("ID_IGRACA").LazyLoad();
        }
    }
}
