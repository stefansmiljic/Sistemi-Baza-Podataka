using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMORPG_API.Entiteti
{
    public class Lik
    {
        public virtual int Id { get; set; }
        public virtual string Ime { get; set; }
        public virtual int KolicinaZlata { get; set; }
        public virtual int Iskustvo { get; set; }
        public virtual int StepenZamora { get; set; }
        public virtual int NivoZdravstvenogStanja { get; set; }
        public virtual Igrac Igrac { get; set; }
        public virtual string Klasa { get; set; }

        public virtual char FCovek { get; set; }
        public virtual char FPatuljak { get; set; }
        public virtual char FOrk { get; set; }
        public virtual char FDemon { get; set; }
        public virtual char FVilenjak { get; set; }
        public virtual string UmesnostSkrivanja { get; set; }
        public virtual string TipOruzja { get; set; }
        public virtual int EnergijaZaMagiju { get; set; }

    }
    public class Lopov : Lik
    {
        public virtual int MaxNivoZamki { get; set; }
        public virtual int NivoBuke { get; set; }
    }
    public class Svestenik : Lik
    {
        public virtual string TipBlagoslova { get; set; }
        public virtual string TipReligije { get; set; }
        public virtual char MogucnostLecenja { get; set; }
    }
    public class Strelac : Lik
    {
        public virtual char LukIliSamostrel { get; set; }
    }
    public class Oklopnik : Lik
    {
        public virtual int MaxTezinaOklopa { get; set; }
    }
    public class Borac : Lik
    {
        public virtual char OruzjeUObeRuke { get; set; }
        public virtual char KoristiStit { get; set; }
    }
    public class Carobnjak : Lik
    {
        public virtual string SpisakMagija { get; set; }
    }
}
