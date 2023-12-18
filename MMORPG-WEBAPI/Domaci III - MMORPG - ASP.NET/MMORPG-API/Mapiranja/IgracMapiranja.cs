using FluentNHibernate.Mapping;
using MMORPG_API.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORPG_API.Mapiranja
{
    public class IgracMapiranja : ClassMap<Igrac>
    {
        public IgracMapiranja()
        {
            Table("IGRAC");

            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();

            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Pol, "POL");
            Map(x => x.Nadimak, "NADIMAK");
            Map(x => x.Lozinka, "LOZINKA");
            Map(x => x.Uzrast, "UZRAST");

            References(x => x.Tim).Column("NAZIV_TIMA").LazyLoad();

            HasMany(x => x.Sesije).KeyColumn("IGRAC_ID").Cascade.All().Inverse();

            HasMany(x => x.Pomocnici).KeyColumn("ID_IGRACA").Cascade.All().Inverse();

            HasOne(x => x.Lik).PropertyRef(x => x.Igrac);

            //HasMany(x => x.Proizvodi).KeyColumn("ID_IGRACA").Cascade.All().Inverse();

            HasManyToMany(x => x.Proizvodi)
                .Table("IGRAC_PROIZVOD")
                .ParentKeyColumn("IGRAC_ID")
                .ChildKeyColumn("NAZIV_P")
                .Cascade.All()
                .Inverse();
        }
    }
}
