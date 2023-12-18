using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MMORPG.Entiteti;

namespace MMORPG.Mapiranja
{
    public class PredmetMapiranja : ClassMap<Predmet>
    {
        public PredmetMapiranja() 
        {
            Table("PREDMET");
            Id(x => x.Naziv, "NAZIV").GeneratedBy.Assigned();
            DiscriminateSubClassesOnColumn("TIP");

            Map(x => x.Opis, "OPIS");

            References(x => x.NazivStaze).Column("NAZIV_STAZE").LazyLoad();
        }
    }
    class KljucniPredmetMapiranja : SubclassMap<KljucniPredmet> 
    {
        public KljucniPredmetMapiranja()
        {
            Map(x => x.NadimciLikova, "NADIMCI_LIKOVA");
            DiscriminatorValue("KLJUCNI");
        }
    }
    class PredmetXPMapiranja : SubclassMap<PredmetXP>
    {
        public PredmetXPMapiranja()
        {
            Map(x => x.BonusUIskustvu, "BONUS_U_ISKUSTVU");
            Map(x => x.RasePremdet, "RASE_PREDMET");
            DiscriminatorValue("XP");
        }
    }
}
