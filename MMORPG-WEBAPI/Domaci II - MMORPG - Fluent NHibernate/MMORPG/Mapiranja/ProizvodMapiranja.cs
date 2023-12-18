using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using MMORPG.Entiteti;

namespace MMORPG.Mapiranja
{
    public class ProizvodMapiranja : ClassMap<Proizvod>
    {
        public ProizvodMapiranja()
        {
            Table("PROIZVOD");
            Id(x => x.Naziv, "NAZIV").GeneratedBy.Assigned();

            DiscriminateSubClassesOnColumn("TIP");
            Map(x => x.Opis, "OPIS");
            Map(x => x.Rase, "RASE");
            Map(x => x.Klase, "KLASE");

            HasManyToMany(x => x.Igraci)
                .Table("IGRAC_PROIZVOD")
                .ParentKeyColumn("NAZIV_P")
                .ChildKeyColumn("IGRAC_ID")
                .Cascade.All();
        }
    }
    class OklopMapiranja : SubclassMap<Oklop>
    {
        public OklopMapiranja()
        {
            DiscriminatorValue("OKLOP");
            Map(x => x.PoeniZaOdbranu, "POENI_ZA_ODBRANU");
        }
    }
    class OruzjeMapiranja : SubclassMap<Oruzje>
    {
        public OruzjeMapiranja()
        {
            DiscriminatorValue("ORUZJE");
            Map(x => x.PoeniZaNapad, "POENI_ZA_NAPAD");
        }
    }
}
