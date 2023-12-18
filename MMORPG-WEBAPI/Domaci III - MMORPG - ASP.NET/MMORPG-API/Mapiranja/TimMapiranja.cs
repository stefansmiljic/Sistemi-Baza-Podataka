using FluentNHibernate.Mapping;
using MMORPG_API.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORPG_API.Mapiranja
{
    public class TimMapiranja : ClassMap<Tim>
    {
        public TimMapiranja()
        {
            Table("TIM");

            Id(x => x.Naziv, "NAZIV").GeneratedBy.Assigned();

            Map(x => x.Plasman, "PLASMAN");
            Map(x => x.BonusPoeni, "BONUSPOENI");
            Map(x => x.Max, "MAX");
            Map(x => x.Min, "MIN");

            HasMany(x => x.Igraci).KeyColumn("NAZIV_TIMA").Cascade.All().Inverse();
            HasOne(x => x.StazaZaTim).PropertyRef(x => x.Tim);

        }
    }
}
