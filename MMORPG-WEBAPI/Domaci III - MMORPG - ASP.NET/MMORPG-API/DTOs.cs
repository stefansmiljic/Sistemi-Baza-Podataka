using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMORPG_API.Entiteti;

namespace MMORPG_API
{
    #region Igrac
    public class IgracPregled
    {
        public string ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Nadimak { get; set; }
        public int Uzrast { get; set; }
        public IgracPregled() { }
        public IgracPregled(string id, string ime, string prezime,
            string nadimak, int uzrast)
        {
            ID = id;
            Ime = ime;
            Prezime = prezime;
            Nadimak = nadimak;
            Uzrast = uzrast;
        }
    }

    public class IgracBasic
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Nadimak { get; set; }
        public string Lozinka { get; set; }
        public char Pol { get; set; }
        public int Uzrast { get; set; }
        public TimBasic Tim { get; set; }//basic
        public Lik Lik { get; set; }//basic
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
            Id = id;
            Ime = ime;
            Prezime = prezime;
            Nadimak = nadimak;
            Lozinka = lozinka;
            Pol = pol;
            Uzrast = uzrast;
        }
    }
    #endregion
    #region Tim
    public class TimPregled
    {
        public string Naziv { get; set; }
        public int Plasman { get; set; }
        public int BonusPoeni { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public TimPregled() { }
        public TimPregled(string naziv, int plasman, int bonusPoeni, int max, int min)
        {
            Naziv = naziv;
            Plasman = plasman;
            BonusPoeni = bonusPoeni;
            Max = max;
            Min = min;
        }
    }
    public class TimBasic
    {
        public string Naziv { get; set; }
        public int Plasman { get; set; }
        public int BonusPoeni { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public virtual IList<Igrac> Igraci { get; set; }
        public StazaZaTim StazaZaTim { get; set; }
        public TimBasic()
        {
            Igraci = new List<Igrac>();
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
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Staza { get; set; }
        public PredmetPregled() { }
        public PredmetPregled(string naziv, string opis, string staza)
        {
            Naziv = naziv;
            Opis = opis;
            Staza = staza;
        }
    }
    public class KljucniPredmetPregled : PredmetPregled
    {
        public string NadimciLikova { get; set; }
        public KljucniPredmetPregled() { }
        public KljucniPredmetPregled(string nadimciLikova)
        {
            NadimciLikova = nadimciLikova;
        }
    }

    public class PredmetXPPregled : PredmetPregled
    {
        public int BonusUIskustvu { get; set; }
        public string RasePredmet { get; set; }

        public PredmetXPPregled() { }
        public PredmetXPPregled(int bonusUIskustvu, string rasePredmet)
        {
            BonusUIskustvu = bonusUIskustvu;
            RasePredmet = rasePredmet;
        }
    }

    public class PredmetBasic
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Tip { get; set; }
        public Staza NazivStaze { get; set; }
        public PredmetBasic() { }
        public PredmetBasic(string naziv, string opis, Staza nazivStaze)
        {
            Naziv = naziv;
            Opis = opis;
            NazivStaze = nazivStaze;
        }
    }
    public class KljucniPredmetBasic : PredmetBasic
    {
        public string NadimciLikova { get; set; }
        public KljucniPredmetBasic() { }
        public KljucniPredmetBasic(string nadimciLikova)
        {
            NadimciLikova = nadimciLikova;
        }
    }
    public class PredmetXPBasic : PredmetBasic
    {
        public int BonusUIskustvu { get; set; }
        public string RasePredmet { get; set; }
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
        public string Ime { get; set; }
        public string Rasa { get; set; }
        public string Klasa { get; set; }
        public int BonusUZastiti { get; set; }
        public string ImeI { get; set; }

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
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Rasa { get; set; }
        public string Klasa { get; set; }
        public int BonusUZastiti { get; set; }
        public Igrac Igrac { get; set; }

        public PomocnikBasic()
        {

        }

        public PomocnikBasic(int id, string ime, string rasa, string klasa, int bonus)
        {
            Id = id;
            Ime = ime;
            Rasa = rasa;
            Klasa = klasa;
            BonusUZastiti = bonus;
        }

    }
    #endregion
    #region Proizvod
    public class ProizvodPregled
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string Klase { get; set; }
        public string Rase { get; set; }

        public ProizvodPregled() { }
        public ProizvodPregled(string naziv, string opis, string klase, string rase)
        {
            Naziv = naziv;
            Opis = opis;
            Klase = klase;
            Rase = rase;
        }
    }
    public class OklopPregled : ProizvodPregled
    {
        public int PoeniZaOdbranu { get; set; }
        public OklopPregled() { }
        public OklopPregled(int poeniZaOdbranu)
        {
            PoeniZaOdbranu = poeniZaOdbranu;
        }
    }
    public class OruzjePregled : ProizvodPregled
    {
        public int PoeniZaNapad { get; set; }
        public OruzjePregled() { }
        public OruzjePregled(int poeniZaNapad)
        {
            PoeniZaNapad = poeniZaNapad;
        }
    }
    public class ProizvodBasic
    {
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string Opis { get; set; }
        public string Klase { get; set; }
        public string Rase { get; set; }
        public virtual IList<Igrac> Igraci { get; set; }
        public ProizvodBasic()
        {
            Igraci = new List<Igrac>();
        }
        public ProizvodBasic(string naziv, string tip, string opis,
            string klase, string rase)
        {
            Naziv = naziv;
            Tip = tip;
            Opis = opis;
            Klase = klase;
            Rase = rase;
        }
    }
    public class OklopBasic : ProizvodBasic
    {
        public int PoeniZaOdbranu { get; set; }
        public OklopBasic() { }
        public OklopBasic(int poeniZaOdbranu)
        {
            PoeniZaOdbranu = poeniZaOdbranu;
        }
    }
    public class OruzjeBasic : ProizvodBasic
    {
        public int PoeniZaNapad { get; set; }
        public OruzjeBasic() { }
        public OruzjeBasic(int poeniZaNapad)
        {
            PoeniZaNapad = poeniZaNapad;
        }
    }
    #endregion
    #region Staza
    public class StazaPregled
    {
        public string Naziv { get; set; }
        public int BonusPoeni { get; set; }
        public string Potrebne_Rase { get; set; }
        public string Potreble_Klase { get; set; }

        public StazaPregled() { }
        public StazaPregled(string naziv, int bonusPoeni, string potrebne_Rase, string potreble_Klase)
        {
            Naziv = naziv;
            BonusPoeni = bonusPoeni;
            Potrebne_Rase = potrebne_Rase;
            Potreble_Klase = potreble_Klase;
        }
    }
    public class StazaZaIgracaPregled : StazaPregled
    {
        public int BrIgranjaStaze { get; set; }
        public int BrUbijenihNeprijatelja { get; set; }
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
        public Tim Tim { get; set; }
        public StazaZaTimPregled() { }

        public StazaZaTimPregled(string naziv, int bonusPoeni, string potrebne_Rase, string potreble_Klase) : base(naziv, bonusPoeni, potrebne_Rase, potreble_Klase)
        {
        }
    }
    public class StazaBasic
    {
        public string Naziv { get; set; }
        public int BonusPoeni { get; set; }
        public string Potrebne_Rase { get; set; }
        public string Potrebne_Klase { get; set; }
        public string Tip { get; set; }
        public virtual IList<Predmet> Predmeti { get; set; }

        public StazaBasic()
        {
            Predmeti = new List<Predmet>();
        }
        public StazaBasic(string naziv, int bonusPoeni, string potrebne_Rase, string potrebne_Klase, string tip)
        {
            Naziv = naziv;
            BonusPoeni = bonusPoeni;
            Potrebne_Rase = potrebne_Rase;
            Potrebne_Klase = potrebne_Klase;
            Tip = tip;
        }
    }
    public class StazaZaIgracaBasic : StazaBasic
    {
        public int BrIgranjaStaze { get; set; }
        public int BrUbijenihNeprijatelja { get; set; }
        public Igrac Igrac { get; set; }
        public StazaZaIgracaBasic() { }
        public StazaZaIgracaBasic(int brIgranjaStaze, int brUbijenihNeprijatelja, Igrac igrac)
        {
            BrIgranjaStaze = brIgranjaStaze;
            BrUbijenihNeprijatelja = brUbijenihNeprijatelja;
            Igrac = igrac;
        }
    }
    public class StazaZaTimBasic : StazaBasic
    {
        public Tim Tim { get; set; }
        public StazaZaTimBasic() { }
        public StazaZaTimBasic(Tim tim)
        {
            Tim = tim;
        }
    }
    #endregion
    #region Lik
    public class LikPregled
    {
        public string Ime { get; set; }
        public int KolicinaZlata { get; set; }
        public int Iskustvo { get; set; }
        public int StepenZamora { get; set; }
        public int NivoZdravstvenogStanja { get; set; }
        public string Klasa { get; set; }
        public char FCovek { get; set; }
        public char FPatuljak { get; set; }
        public char FOrk { get; set; }
        public char FDemon { get; set; }
        public char FVilenjak { get; set; }
        public string UmesnostSkrivanja { get; set; }
        public string TipOruzja { get; set; }
        public string EnergijaZaMagiju { get; set; }

        public LikPregled() { }
        public LikPregled(int zlato, string ime, int xp, int zamor, int hp,
            string klasa, char fcovek, char fpatuljak, char fork, char fdemon,
            char fvilenjak, string umesnostSkrivanja, string tipOruzja,
            string energijaZaMagiju)
        {
            KolicinaZlata = zlato;
            Ime = ime;
            Iskustvo = xp;
            StepenZamora = zamor;
            NivoZdravstvenogStanja = hp;
            Klasa = klasa;
            FCovek = fcovek;
            FPatuljak = fpatuljak;
            FOrk = fork;
            FDemon = fdemon;
            FVilenjak = fvilenjak;
            UmesnostSkrivanja = umesnostSkrivanja;
            TipOruzja = tipOruzja;
            EnergijaZaMagiju = energijaZaMagiju;
        }
    }
    public class LopovPregled : LikPregled
    {
        public int MaxNivoZamki { get; set; }
        public int NivoBuke { get; set; }
        public LopovPregled() { }
        public LopovPregled(int maxNivoZamki, int nivoBuke)
        {
            MaxNivoZamki = maxNivoZamki;
            NivoBuke = nivoBuke;
        }
    }
    public class SvestenikPregled : LikPregled
    {
        public string TipBlagoslova { get; set; }
        public string TipReligije { get; set; }
        public char MogucnostLecenja { get; set; }

        public SvestenikPregled() { }
        public SvestenikPregled(string tipBlagoslova, string tipReligije, char mogucnostLecenja)
        {
            TipBlagoslova = tipBlagoslova;
            TipReligije = tipReligije;
            MogucnostLecenja = mogucnostLecenja;
        }
    }
    public class StrelacPregled : LikPregled
    {
        public char LukIliSamostrel { get; set; }
        public StrelacPregled() { }
        public StrelacPregled(char lukIliSamostrel)
        {
            LukIliSamostrel = lukIliSamostrel;
        }
    }
    public class OklopnikPregled : LikPregled
    {
        public int MaxTezinaOklopa { get; set; }
        public OklopnikPregled() { }
        public OklopnikPregled(int maxTezinaOklopa)
        {
            MaxTezinaOklopa = maxTezinaOklopa;
        }
    }
    public class BoracPregled : LikPregled
    {
        public char OruzjeUObeRuke { get; set; }
        public char KoristiStit { get; set; }
        public BoracPregled() { }
        public BoracPregled(char oruzjeUObeRuke, char koristiStit)
        {
            OruzjeUObeRuke = oruzjeUObeRuke;
            KoristiStit = koristiStit;
        }
    }
    public class CarobnjakPregled : LikPregled
    {
        public string SpisakMagija { get; set; }
        public CarobnjakPregled() { }
        public CarobnjakPregled(string spisakMagija)
        {
            SpisakMagija = spisakMagija;
        }
    }
    public class LikBasic
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public int KolicinaZlata { get; set; }
        public int Iskustvo { get; set; }
        public int StepenZamora { get; set; }
        public int NivoZdravstvenogStanja { get; set; }
        public IgracBasic Igrac { get; set; }
        public string Klasa { get; set; }

        public char FCovek { get; set; }
        public char FPatuljak { get; set; }
        public char FOrk { get; set; }
        public char FDemon { get; set; }
        public char FVilenjak { get; set; }
        public string UmesnostSkrivanja { get; set; }
        public string TipOruzja { get; set; }
        public int EnergijaZaMagiju { get; set; }
        public LikBasic() { }

        public LikBasic(int id, string ime, int kolicinaZlata, int iskustvo, int stepenZamora, int nivoZdravstvenogStanja, IgracBasic igrac, string klasa, char fCovek, char fPatuljak, char fOrk, char fDemon, char fVilenjak, string umesnostSkrivanja, string tipOruzja, int energijaZaMagiju)
        {
            Id = id;
            Ime = ime;
            KolicinaZlata = kolicinaZlata;
            Iskustvo = iskustvo;
            StepenZamora = stepenZamora;
            NivoZdravstvenogStanja = nivoZdravstvenogStanja;
            Igrac = igrac;
            Klasa = klasa;
            FCovek = fCovek;
            FPatuljak = fPatuljak;
            FOrk = fOrk;
            FDemon = fDemon;
            FVilenjak = fVilenjak;
            UmesnostSkrivanja = umesnostSkrivanja;
            TipOruzja = tipOruzja;
            EnergijaZaMagiju = energijaZaMagiju;
        }
    }
    public class LopovBasic : LikBasic
    {
        public int MaxNivoZamki { get; set; }
        public int NivoBuke { get; set; }
        public LopovBasic() { }
        public LopovBasic(int maxNivoZamki, int nivoBuke)
        {
            MaxNivoZamki = maxNivoZamki;
            NivoBuke = nivoBuke;
        }
    }
    public class SvestenikBasic : LikBasic
    {
        public string TipBlagoslova { get; set; }
        public string TipReligije { get; set; }
        public char MogucnostLecenja { get; set; }

        public SvestenikBasic() { }
        public SvestenikBasic(string tipBlagoslova, string tipReligije, char mogucnostLecenja)
        {
            TipBlagoslova = tipBlagoslova;
            TipReligije = tipReligije;
            MogucnostLecenja = mogucnostLecenja;
        }
    }
    public class StrelacBasic : LikBasic
    {
        public char LukIliSamostrel { get; set; }
        public StrelacBasic() { }
        public StrelacBasic(char lukIliSamostrel)
        {
            LukIliSamostrel = lukIliSamostrel;
        }
    }
    public class OklopnikBasic : LikBasic
    {
        public int MaxTezinaOklopa { get; set; }
        public OklopnikBasic() { }
        public OklopnikBasic(int maxTezinaOklopa)
        {
            MaxTezinaOklopa = maxTezinaOklopa;
        }
    }
    public class BoracBasic : LikBasic
    {
        public char OruzjeUObeRuke { get; set; }
        public char KoristiStit { get; set; }
        public BoracBasic() { }
        public BoracBasic(char oruzjeUObeRuke, char koristiStit)
        {
            OruzjeUObeRuke = oruzjeUObeRuke;
            KoristiStit = koristiStit;
        }
    }
    public class CarobnjakBasic : LikBasic
    {
        public string SpisakMagija { get; set; }
        public CarobnjakBasic() { }
        public CarobnjakBasic(string spisakMagija)
        {
            SpisakMagija = spisakMagija;
        }
    }
    #endregion
}