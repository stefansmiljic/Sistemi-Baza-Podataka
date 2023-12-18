using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MMORPG.Entiteti;

namespace MMORPG.Mapiranja
{
    public class SesijaMapiranja : ClassMap<Sesija>
    {
        public SesijaMapiranja() 
        {
            Table("SESIJA");

            Id(x => x.VremePovezivanjaNaServer, "VREME_POVEZIVANJA_NA_SERVER").GeneratedBy.Assigned();

            Map(x => x.VremeUcestvovanja, "VREME_UCESTVOVANJA");
            Map(x => x.ZaradjeniGold, "ZARADJENI_GOLD");
            Map(x => x.ZaradjeniXPpoeni, "ZARADJENI_XP_POENI");

            References(x => x.Igrac).Column("IGRAC_ID").LazyLoad();
        }
    }
}
