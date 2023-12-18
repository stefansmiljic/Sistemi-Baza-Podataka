using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MMORPG.Entiteti;

namespace MMORPG.Mapiranja
{
    public class StazaMapiranja : ClassMap<Staza>
    {
        public StazaMapiranja() 
        {
            Table("STAZA");
            Id(x => x.Naziv, "NAZIV_STAZE").GeneratedBy.Assigned();
            DiscriminateSubClassesOnColumn("TIP");

            Map(x => x.BonusPoeni, "BONUS_POENI");
            Map(x => x.Potrebne_Klase, "POTREBNE_KLASE");
            Map(x => x.Potrebne_Rase, "POTREBNE_RASE");

            HasMany(x => x.Predmeti).KeyColumn("NAZIV_STAZE");
        }
    }
    class StazaZaIgracaMapiranja : SubclassMap<StazaZaIgraca>
    {
        public StazaZaIgracaMapiranja()
        {
            DiscriminatorValue("IGRAC");
            Map(x => x.BrIgranjaStaze, "BR_IGRANJA_STAZE");
            Map(x => x.BrUbijenihNeprijatelja, "BR_UBIJENIH_NEP");
            //HasOne(x => x.Igrac).Cascade.All();
        }
    }
    class StazaZaTimaMapiranja : SubclassMap<StazaZaTim>
    {
        public StazaZaTimaMapiranja()
        {
            DiscriminatorValue("TIM");
            References(x => x.Tim, "TIM").Unique();
        }
    }
}
