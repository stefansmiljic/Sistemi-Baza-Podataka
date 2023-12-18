using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMORPG.Entiteti;

namespace MMORPG
{
    #region Igrac
    public class IgracPregled
    {
        public string ID;
        public string Ime;
        public string Prezime;
        public string Nadimak;
        public int Uzrast;
        public IgracPregled() { }
        public IgracPregled(string id, string ime, string prezime,
            string nadimak, int uzrast)
        {
            this.ID = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Nadimak = nadimak;
            this.Uzrast = uzrast;
        }
    }

    public class IgracBasic
    {
        public int Id;
        public string Ime;
        public string Prezime;
        public string Nadimak;
        public string Lozinka;
        public char Pol;
        public int Uzrast;
        public TimBasic Tim;//basic
        public Lik Lik;//basic
        public virtual IList<Sesija> Sesije { get; set; }
        public virtual IList<Pomocnik> Pomocnici { get; set; }
        public virtual IList<Proizvod> Proizvodi { get; set; }


        public IgracBasic()
        {
            Sesije = new List<Sesija>();
            Pomocnici = new List<Pomocnik>();
            Proizvodi = new List<Proizvod>();
        }
        public IgracBasic(int id, string ime, string prezime, string nadimak, string lozinka, char pol, int uzrast)
        {
            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Nadimak = nadimak;
            this.Lozinka = lozinka;
            this.Pol = pol;
            this.Uzrast = uzrast;
        }
    }
    #endregion
    #region Tim
    public class TimPregled
    {
        public string Naziv;
        public int Plasman;
        public int BonusPoeni;
        public int Max;
        public int Min;
        public TimPregled() { }
        public TimPregled(string naziv, int plasman, int bonusPoeni, int max, int min)
        {
            this.Naziv = naziv;
            this.Plasman = plasman;
            this.BonusPoeni = bonusPoeni;
            this.Max = max;
            this.Min = min;
        }
    }
    public class TimBasic
    {
        public string Naziv;
        public int Plasman;
        public int BonusPoeni;
        public int Max;
        public int Min;
        public virtual IList<Igrac> Igraci { get; set; }
        public StazaZaTim StazaZaTim;
        public TimBasic()
        {
            this.Igraci = new List<Igrac>();
        }
        public TimBasic(string naziv, int plasman, int bonusPoeni, int max, int min, StazaZaTim stazaZaTim)
        {
            Naziv = naziv;
            Plasman = plasman;
            BonusPoeni = bonusPoeni;
            Max = max;
            Min = min;
        }
    }
    #endregion
    #region Predmet
    public class PredmetPregled
    {
        public string Naziv;
        public string Opis;
        public string Staza { get; set; }
        public PredmetPregled() { }
        public PredmetPregled(string naziv, string opis, string staza)
        {
            this.Naziv = naziv;
            this.Opis = opis;
            this.Staza = staza;
        }
    }
    public class KljucniPredmetPregled : PredmetPregled
    {
        public string NadimciLikova;
        public KljucniPredmetPregled() { }
        public KljucniPredmetPregled(string nadimciLikova)
        {
            NadimciLikova = nadimciLikova;
        }
    }

    public class PredmetXPPregled : PredmetPregled
    {
        public int BonusUIskustvu;
        public string RasePredmet;

        public PredmetXPPregled() { }
        public PredmetXPPregled(int bonusUIskustvu, string rasePredmet)
        {
            this.BonusUIskustvu = bonusUIskustvu;
            this.RasePredmet = rasePredmet;
        }
    }

    public class PredmetBasic
    {
        public string Naziv;
        public string Opis;
        public Staza NazivStaze;
        public PredmetBasic() { }
        public PredmetBasic(string naziv, string opis, Staza nazivStaze)
        {
            this.Naziv = naziv;
            this.Opis = opis;
            this.NazivStaze = nazivStaze;
        }
    }
    public class KljucniPredmetBasic : PredmetBasic
    {
        public string NadimciLikova;
        public KljucniPredmetBasic() { }
        public KljucniPredmetBasic(string nadimciLikova)
        {
            this.NadimciLikova = nadimciLikova;
        }
    }
    public class PredmetXPBasic : PredmetBasic
    {
        public int BonusUIskustvu;
        public string RasePredmet;
        public PredmetXPBasic() { }
        public PredmetXPBasic(int bonusUIskustvu, string rasePredmet)
        {
            BonusUIskustvu = bonusUIskustvu;
            RasePredmet = rasePredmet;
        }
    }
    #endregion
    #region Pomocnik
    public class PomocnikPregled
    {
        public string Ime;
        public string Rasa;
        public string Klasa;
        public int BonusUZastiti;
        public string ImeI;

        public PomocnikPregled()
        { }
        public PomocnikPregled(string ime, string rasa, string klasa, int bonusUZastiti, string imeI)
        {
            Ime = ime;
            Rasa = rasa;
            Klasa = klasa;
            BonusUZastiti = bonusUZastiti;
            ImeI = imeI;
        }
    }

    public class PomocnikBasic
    {
        public int Id;
        public string Ime;
        public string Rasa;
        public string Klasa;
        public int BonusUZastiti;
        public Igrac Igrac;

        public PomocnikBasic()
        {

        }

        public PomocnikBasic(int id, string ime, string rasa, string klasa, int bonus)
        {
            this.Id = id;
            this.Ime = ime;
            this.Rasa = rasa;
            this.Klasa = klasa;
            this.BonusUZastiti = bonus;
        }

    }
    #endregion
    #region Proizvod
    public class ProizvodPregled
    {
        public string Naziv;
        public string Opis;
        public string Klase;
        public string Rase;

        public ProizvodPregled() { }
        public ProizvodPregled(string naziv, string opis, string klase, string rase)
        {
            this.Naziv = naziv;
            this.Opis = opis;
            this.Klase = klase;
            this.Rase = rase;
        }
    }
    public class OklopPregled : ProizvodPregled
    {
        public int PoeniZaOdbranu;
        public OklopPregled() { }
        public OklopPregled(int poeniZaOdbranu)
        {
            this.PoeniZaOdbranu = poeniZaOdbranu;
        }
    }
    public class OruzjePregled : ProizvodPregled
    {
        public int PoeniZaNapad;
        public OruzjePregled() { }
        public OruzjePregled(int poeniZaNapad)
        {
            this.PoeniZaNapad = poeniZaNapad;
        }
    }
    public class ProizvodBasic
    {
        public string Naziv;
        public string Tip;
        public string Opis;
        public string Klase;
        public string Rase;
        public virtual IList<Igrac> Igraci { get; set; }
        public ProizvodBasic()
        {
            Igraci = new List<Igrac>();
        }
        public ProizvodBasic(string naziv, string tip, string opis,
            string klase, string rase)
        {
            this.Naziv = naziv;
            this.Tip = tip;
            this.Opis = opis;
            this.Klase = klase;
            this.Rase = rase;
        }
    }
    public class OklopBasic : ProizvodBasic
    {
        public int PoeniZaOdbranu;
        public OklopBasic() { }
        public OklopBasic(int poeniZaOdbranu)
        {
            this.PoeniZaOdbranu = poeniZaOdbranu;
        }
    }
    public class OruzjeBasic : ProizvodBasic
    {
        public int PoeniZaNapad;
        public OruzjeBasic() { }
        public OruzjeBasic(int poeniZaNapad)
        {
            this.PoeniZaNapad = poeniZaNapad;
        }
    }
    #endregion
    #region Staza
    public class StazaPregled
    {
        public string Naziv;
        public int BonusPoeni;
        public string Potrebne_Rase;
        public string Potreble_Klase;

        public StazaPregled() { }
        public StazaPregled(string naziv, int bonusPoeni, string potrebne_Rase, string potreble_Klase)
        {
            this.Naziv = naziv;
            this.BonusPoeni = bonusPoeni;
            this.Potrebne_Rase = potrebne_Rase;
            this.Potreble_Klase = potreble_Klase;
        }
    }
    public class StazaZaIgracaPregled : StazaPregled
    {
        public int BrIgranjaStaze;
        public int BrUbijenihNeprijatelja;
        public StazaZaIgracaPregled() { }
        public StazaZaIgracaPregled(int brIgranjaStaze, int brUbijenihNeprijatelja)
        {
            BrIgranjaStaze = brIgranjaStaze;
            BrUbijenihNeprijatelja = brUbijenihNeprijatelja;
        }

        public StazaZaIgracaPregled(string naziv, int bonusPoeni, string potrebne_Rase, string potreble_Klase, int brIgranjaStaze, int brUbijenihNeprijatelja) : base(naziv, bonusPoeni, potrebne_Rase, potreble_Klase)
        {
        }
    }
    public class StazaZaTimPregled : StazaPregled
    {
        public Tim Tim;
        public StazaZaTimPregled() { }

        public StazaZaTimPregled(string naziv, int bonusPoeni, string potrebne_Rase, string potreble_Klase) : base(naziv, bonusPoeni, potrebne_Rase, potreble_Klase)
        {
        }
    }
    public class StazaBasic
    {
        public string Naziv;
        public int BonusPoeni;
        public string Potrebne_Rase;
        public string Potrebne_Klase;
        public string Tip;
        public virtual IList<Predmet> Predmeti { get; set; }

        public StazaBasic()
        {
            this.Predmeti = new List<Predmet>();
        }
        public StazaBasic(string naziv, int bonusPoeni, string potrebne_Rase, string potrebne_Klase, string tip)
        {
            this.Naziv = naziv;
            this.BonusPoeni = bonusPoeni;
            this.Potrebne_Rase = potrebne_Rase;
            this.Potrebne_Klase = potrebne_Klase;
            this.Tip = tip;
        }
    }
    public class StazaZaIgracaBasic : StazaBasic
    {
        public int BrIgranjaStaze;
        public int BrUbijenihNeprijatelja;
        public Igrac Igrac;
        public StazaZaIgracaBasic() { }
        public StazaZaIgracaBasic(int brIgranjaStaze, int brUbijenihNeprijatelja, Igrac igrac)
        {
            this.BrIgranjaStaze = brIgranjaStaze;
            this.BrUbijenihNeprijatelja = brUbijenihNeprijatelja;
            this.Igrac = igrac;
        }
    }
    public class StazaZaTimBasic : StazaBasic
    {
        public Tim Tim;
        public StazaZaTimBasic() { }
        public StazaZaTimBasic(Tim tim)
        {
            this.Tim = tim;
        }
    }
    #endregion
    #region Lik
    public class LikPregled
    {
        public string Ime;
        public int KolicinaZlata;
        public int Iskustvo;
        public int StepenZamora;
        public int NivoZdravstvenogStanja;
        public string Klasa;
        public char FCovek;
        public char FPatuljak;
        public char FOrk;
        public char FDemon;
        public char FVilenjak;
        public string UmesnostSkrivanja;
        public string TipOruzja;
        public string EnergijaZaMagiju;

        public LikPregled() { }
        public LikPregled(int zlato, string ime, int xp, int zamor, int hp,
            string klasa, char fcovek, char fpatuljak, char fork, char fdemon,
            char fvilenjak, string umesnostSkrivanja, string tipOruzja,
            string energijaZaMagiju)
        {
            this.KolicinaZlata = zlato;
            this.Ime = ime;
            this.Iskustvo = xp;
            this.StepenZamora = zamor;
            this.NivoZdravstvenogStanja = hp;
            this.Klasa = klasa;
            this.FCovek = fcovek;
            this.FPatuljak = fpatuljak;
            this.FOrk = fork;
            this.FDemon = fdemon;
            this.FVilenjak = fvilenjak;
            this.UmesnostSkrivanja = umesnostSkrivanja;
            this.TipOruzja = tipOruzja;
            this.EnergijaZaMagiju = energijaZaMagiju;
        }
    }
    public class LopovPregled : LikPregled
    {
        public int MaxNivoZamki;
        public int NivoBuke;
        public LopovPregled() { }
        public LopovPregled(int maxNivoZamki, int nivoBuke)
        {
            this.MaxNivoZamki = maxNivoZamki;
            this.NivoBuke = nivoBuke;
        }
    }
    public class SvestenikPregled : LikPregled
    {
        public string TipBlagoslova;
        public string TipReligije;
        public char MogucnostLecenja;

        public SvestenikPregled() { }
        public SvestenikPregled(string tipBlagoslova, string tipReligije, char mogucnostLecenja)
        {
            this.TipBlagoslova = tipBlagoslova;
            this.TipReligije = tipReligije;
            this.MogucnostLecenja = mogucnostLecenja;
        }
    }
    public class StrelacPregled : LikPregled
    {
        public char LukIliSamostrel;
        public StrelacPregled() { }
        public StrelacPregled(char lukIliSamostrel)
        {
            this.LukIliSamostrel = lukIliSamostrel;
        }
    }
    public class OklopnikPregled : LikPregled
    {
        public int MaxTezinaOklopa;
        public OklopnikPregled() { }
        public OklopnikPregled(int maxTezinaOklopa)
        {
            this.MaxTezinaOklopa = maxTezinaOklopa;
        }
    }
    public class BoracPregled : LikPregled
    {
        public char OruzjeUObeRuke;
        public char KoristiStit;
        public BoracPregled() { }
        public BoracPregled(char oruzjeUObeRuke, char koristiStit)
        {
            this.OruzjeUObeRuke = oruzjeUObeRuke;
            this.KoristiStit = koristiStit;
        }
    }
    public class CarobnjakPregled : LikPregled
    {
        public string SpisakMagija;
        public CarobnjakPregled() { }
        public CarobnjakPregled(string spisakMagija)
        {
            this.SpisakMagija = spisakMagija;
        }
    }
    public class LikBasic
    {
        public int Id;
        public string Ime;
        public int KolicinaZlata;
        public int Iskustvo;
        public int StepenZamora;
        public int NivoZdravstvenogStanja;
        public IgracBasic Igrac;
        public string Klasa;

        public char FCovek;
        public char FPatuljak;
        public char FOrk;
        public char FDemon;
        public char FVilenjak;
        public string UmesnostSkrivanja;
        public string TipOruzja;
        public int EnergijaZaMagiju;
        public LikBasic() { }

        public LikBasic(int id, string ime, int kolicinaZlata, int iskustvo, int stepenZamora, int nivoZdravstvenogStanja, IgracBasic igrac, string klasa, char fCovek, char fPatuljak, char fOrk, char fDemon, char fVilenjak, string umesnostSkrivanja, string tipOruzja, int energijaZaMagiju)
        {
            this.Id = id;
            this.Ime = ime;
            this.KolicinaZlata = kolicinaZlata;
            this.Iskustvo = iskustvo;
            this.StepenZamora = stepenZamora;
            this.NivoZdravstvenogStanja = nivoZdravstvenogStanja;
            this.Igrac = igrac;
            this.Klasa = klasa;
            this.FCovek = fCovek;
            this.FPatuljak = fPatuljak;
            this.FOrk = fOrk;
            this.FDemon = fDemon;
            this.FVilenjak = fVilenjak;
            this.UmesnostSkrivanja = umesnostSkrivanja;
            this.TipOruzja = tipOruzja;
            this.EnergijaZaMagiju = energijaZaMagiju;
        }
    }
    public class LopovBasic : LikBasic
    {
        public int MaxNivoZamki;
        public int NivoBuke;
        public LopovBasic() { }
        public LopovBasic(int maxNivoZamki, int nivoBuke)
        {
            this.MaxNivoZamki = maxNivoZamki;
            this.NivoBuke = nivoBuke;
        }
    }
    public class SvestenikBasic : LikBasic
    {
        public string TipBlagoslova;
        public string TipReligije;
        public char MogucnostLecenja;

        public SvestenikBasic() { }
        public SvestenikBasic(string tipBlagoslova, string tipReligije, char mogucnostLecenja)
        {
            this.TipBlagoslova = tipBlagoslova;
            this.TipReligije = tipReligije;
            this.MogucnostLecenja = mogucnostLecenja;
        }
    }
    public class StrelacBasic : LikBasic
    {
        public char LukIliSamostrel;
        public StrelacBasic() { }
        public StrelacBasic(char lukIliSamostrel)
        {
            this.LukIliSamostrel = lukIliSamostrel;
        }
    }
    public class OklopnikBasic : LikBasic
    {
        public int MaxTezinaOklopa;
        public OklopnikBasic() { }
        public OklopnikBasic(int maxTezinaOklopa)
        {
            this.MaxTezinaOklopa = maxTezinaOklopa;
        }
    }
    public class BoracBasic : LikBasic
    {
        public char OruzjeUObeRuke;
        public char KoristiStit;
        public BoracBasic() { }
        public BoracBasic(char oruzjeUObeRuke, char koristiStit)
        {
            this.OruzjeUObeRuke = oruzjeUObeRuke;
            this.KoristiStit = koristiStit;
        }
    }
    public class CarobnjakBasic : LikBasic
    {
        public string SpisakMagija;
        public CarobnjakBasic() { }
        public CarobnjakBasic(string spisakMagija)
        {
            this.SpisakMagija = spisakMagija;
        }
    }
    #endregion
}