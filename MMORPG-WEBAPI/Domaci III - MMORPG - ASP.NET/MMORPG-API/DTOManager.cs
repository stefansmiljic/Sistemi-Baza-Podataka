using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using NHibernate;
using NHibernate.Util;
using MMORPG_API.Entiteti;

namespace MMORPG_API
{
    public class DTOManager
    {
        #region Igrac
        public static List<IgracPregled> vratiIgrace()
        {
            List<IgracPregled> odInfos = new List<IgracPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from Igrac");
                IList<Igrac> igraci = q.List<Igrac>();

                foreach (Igrac i in igraci)
                {
                    odInfos.Add(new IgracPregled(i.Id.ToString(), i.Ime, i.Prezime, i.Nadimak, i.Uzrast));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return odInfos;
        }
        public static void sacuvajIgraca(IgracBasic igrac, string naziv)
        {
            //TimBasic t = new TimBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Igrac i = new Igrac();

                Tim t1 = s.Load<Tim>(naziv);

                i.Ime = igrac.Ime;
                i.Prezime = igrac.Prezime;
                i.Nadimak = igrac.Nadimak;
                i.Pol = igrac.Pol;
                i.Uzrast = igrac.Uzrast;
                i.Lozinka = igrac.Lozinka;
                i.Tim = t1;


                s.Save(i);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static void obrisiIgraca(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Igrac igrac = s.Load<Igrac>(id);

                s.Delete(igrac);
                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }


        }
        public static IgracBasic izmeniIgraca(IgracBasic igrac, int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Igrac i = s.Load<Igrac>(id);
                i.Ime = igrac.Ime;
                i.Prezime = igrac.Prezime;
                i.Pol = igrac.Pol;
                i.Nadimak = igrac.Nadimak;
                i.Lozinka = igrac.Lozinka;
                i.Uzrast = igrac.Uzrast;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch(Exception ec)
            {
            }
            return igrac;
        }
        #endregion
        #region Tim
        public static List<TimPregled> vratiTimove()
        {
            List<TimPregled> Infos = new List<TimPregled>();
            try
            {
                ISession s = DataLayer.GetSession();
                IQuery q = s.CreateQuery("from Tim");
                IList<Tim> timovi = q.List<Tim>();

                foreach (Tim t in timovi)
                {
                    Infos.Add(new TimPregled(t.Naziv, t.Plasman, t.BonusPoeni, t.Max, t.Min));
                }

                s.Close();
            }
            catch (Exception ec)
            {

            }

            return Infos;
        }
        public static void sacuvajTim(TimBasic tim)
        {
            //TimBasic t = new TimBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Tim t = new Tim();
                /*t.Naziv = t1.Naziv;
                t.Plasman = t1.Plasman;
                t.Min = t1.Min;
                t.Max = t1.Max;
                t.BonusPoeni = t1.BonusPoeni;*/

                t.Naziv = tim.Naziv;
                t.Plasman = tim.Plasman;
                t.Min = tim.Min;
                t.Max = tim.Max;
                t.BonusPoeni = tim.BonusPoeni;


                s.Save(t);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static void obrisiTim(string naziv)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Tim tim = s.Load<Tim>(naziv);
                s.Delete(tim);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            { }

        }
        public static TimBasic izmeniTim(TimBasic tim, string naziv)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Tim i = s.Load<Tim>(naziv);
                i.Plasman = tim.Plasman;
                i.BonusPoeni = tim.BonusPoeni;
                i.Max = tim.Max;
                i.Min = tim.Min;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return tim;
        }
        #endregion
        #region Pomocnik
        public static List<PomocnikPregled> vratiPomocnike()
        {
            List<PomocnikPregled> odInfos = new List<PomocnikPregled>();
            try
            {
                ISession s = DataLayer.GetSession();

                IQuery q = s.CreateQuery("from Pomocnik");
                IList<Pomocnik> pomocnici = q.List<Pomocnik>();

                foreach (Pomocnik i in pomocnici)
                {
                    odInfos.Add(new PomocnikPregled(i.Ime, i.Rasa, i.Klasa, i.BonusUZastiti, i.Igrac.Ime + " " + i.Igrac.Prezime));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return odInfos;
        }
        public static void sacuvajPomocnika(PomocnikBasic pom, string idigraca)
        {
            //TimBasic t = new TimBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                Pomocnik p = new Pomocnik();
                int ajdi = Convert.ToInt32(idigraca);
                Igrac igrac = s.Load<Igrac>(ajdi);

                p.Ime = pom.Ime;
                p.Rasa = pom.Rasa;
                p.Klasa = pom.Klasa;
                p.BonusUZastiti = pom.BonusUZastiti;
                p.Igrac = igrac;


                s.Save(p);

                s.Flush();

                s.Close();
            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static void obrisiPomocnika(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Pomocnik p = s.Load<Pomocnik>(id);
                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            { }
        }

        public static PomocnikBasic izmeniPomocnika(PomocnikBasic pomocnik, int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Pomocnik i = s.Load<Pomocnik>(id);
                i.Ime = pomocnik.Ime;
                i.Rasa = pomocnik.Rasa;
                i.Klasa = pomocnik.Klasa;
                i.BonusUZastiti = pomocnik.BonusUZastiti;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return pomocnik;
        }
        #endregion
        #region Proizvod
        public static List<ProizvodPregled> vratiProizvode()
        {
            List<ProizvodPregled> odInfos = new List<ProizvodPregled>();
            try
            {
                ISession s = DataLayer.GetSession();


                IQuery q = s.CreateQuery("from Proizvod");
                IList<Proizvod> proizvodi = q.List<Proizvod>();

                foreach (Proizvod i in proizvodi)
                {
                    odInfos.Add(new ProizvodPregled(i.Naziv, i.Opis, i.Klase, i.Rase));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }
            return odInfos;
        }
        public static void sacuvajProizvod(ProizvodBasic pro, string tipProizvoda, int poeni)
        {
            //TimBasic t = new TimBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                if (tipProizvoda == "Oklop")
                {
                    Oklop ok = new Oklop();
                    ok.Naziv = pro.Naziv;
                    ok.Opis = pro.Opis;
                    ok.Tip = "OKLOP";
                    ok.Rase = pro.Rase;
                    ok.Klase = pro.Klase;
                    ok.PoeniZaOdbranu = poeni;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                else if (tipProizvoda == "Oruzje")
                {
                    Oruzje or = new Oruzje();
                    or.Naziv = pro.Naziv;
                    or.Opis = pro.Opis;
                    or.Tip = "ORUZJE";
                    or.Rase = pro.Rase;
                    or.Klase = pro.Klase;
                    or.PoeniZaNapad = poeni;
                    s.Save(or);

                    s.Flush();

                    s.Close();
                }




            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static void obrisiProizvod(string naziv)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Proizvod p = s.Load<Proizvod>(naziv);
                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            { }

        }

        public static OklopBasic izmeniOklop(OklopBasic oklop, string naziv)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Oklop i = s.Load<Oklop>(naziv);
                i.Opis = oklop.Opis;
                i.Rase = oklop.Rase;
                i.Klase = oklop.Klase;
                i.PoeniZaOdbranu = oklop.PoeniZaOdbranu;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch(Exception ec) { }
            return oklop;
        }
        public static OruzjeBasic izmeniOruzje(OruzjeBasic oruzje, string naziv)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Oruzje i = s.Load<Oruzje>(naziv);
                i.Opis = oruzje.Opis;
                i.Rase = oruzje.Rase;
                i.Klase = oruzje.Klase;
                i.PoeniZaNapad = oruzje.PoeniZaNapad;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec) { }
            return oruzje;
        }
        #endregion
        #region Staza
        public static List<StazaPregled> vratiStaze()
        {
            List<StazaPregled> odInfos = new List<StazaPregled>();
            try
            {
                ISession s = DataLayer.GetSession();


                IQuery q = s.CreateQuery("from Staza");
                IList<Staza> proizvodi = q.List<Staza>();

                foreach (Staza i in proizvodi)
                {
                    odInfos.Add(new StazaPregled(i.Naziv, i.BonusPoeni, i.Potrebne_Klase, i.Potrebne_Rase));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return odInfos;
        }
        public static void sacuvajStazu(StazaBasic staza, string tipStaze, int brigr, int brUb, int igrId, string tim)
        {
            //TimBasic t = new TimBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                if (tipStaze == "Igrac")
                {
                    StazaZaIgraca ok = new StazaZaIgraca();
                    ok.Naziv = staza.Naziv;
                    ok.BonusPoeni = staza.BonusPoeni;
                    ok.Tip = "IGRAC";
                    ok.Potrebne_Rase = staza.Potrebne_Rase;
                    ok.Potrebne_Klase = staza.Potrebne_Klase;
                    ok.BrIgranjaStaze = brigr;
                    ok.BrUbijenihNeprijatelja = brUb;
                    Igrac igrac = s.Load<Igrac>(igrId);
                    ok.Igrac = igrac;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                else if (tipStaze == "Tim")
                {
                    StazaZaTim or = new StazaZaTim();
                    or.Naziv = staza.Naziv;
                    or.BonusPoeni = staza.BonusPoeni;
                    or.Tip = "IGRAC";
                    or.Potrebne_Rase = staza.Potrebne_Rase;
                    or.Potrebne_Klase = staza.Potrebne_Klase;
                    Tim tims = s.Load<Tim>(tim);
                    or.Tim = tims;
                    s.Save(or);

                    s.Flush();

                    s.Close();
                }




            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static void obrisiStazu(string naziv)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Staza staza = s.Load<Staza>(naziv);
                s.Delete(staza);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            { }

        }
        
        public static StazaZaIgracaBasic izmeniStazuZaIgraca(StazaZaIgracaBasic staza, string naziv)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                StazaZaIgraca i = s.Load<StazaZaIgraca>(naziv);
                i.BonusPoeni = staza.BonusPoeni;
                i.Potrebne_Klase = staza.Potrebne_Klase;
                i.Potrebne_Rase = staza.Potrebne_Rase;
                i.BrIgranjaStaze = staza.BrIgranjaStaze;
                i.BrUbijenihNeprijatelja = staza.BrUbijenihNeprijatelja;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return staza;
        }
        public static StazaZaTimBasic izmeniStazuZaTim(StazaZaTimBasic staza, string naziv)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                StazaZaTim i = s.Load<StazaZaTim>(naziv);
                i.BonusPoeni = staza.BonusPoeni;
                i.Potrebne_Klase = staza.Potrebne_Klase;
                i.Potrebne_Rase = staza.Potrebne_Rase;
                i.Tim = staza.Tim;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return staza;
        }
        #endregion
        #region Predmet
        public static List<PredmetPregled> vratiPredmete()
        {
            List<PredmetPregled> odInfos = new List<PredmetPregled>();
            try
            {
                ISession s = DataLayer.GetSession();


                IQuery q = s.CreateQuery("from Predmet");
                IList<Predmet> proizvodi = q.List<Predmet>();

                foreach (Predmet i in proizvodi)
                {
                    odInfos.Add(new PredmetPregled(i.Naziv, i.Opis, i.NazivStaze.Naziv));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return odInfos;
        }
        public static void sacuvajPredmet(PredmetBasic pr, string tipPredmeta, string nadimci, int bonisk, string rase, string staza)
        {
            //TimBasic t = new TimBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                if (tipPredmeta == "Kljucni")
                {
                    KljucniPredmet ok = new KljucniPredmet();
                    ok.Naziv = pr.Naziv;
                    ok.Opis = pr.Opis;
                    ok.NadimciLikova = nadimci;
                    Staza st = s.Load<Staza>(staza);
                    ok.NazivStaze = st;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                else if (tipPredmeta == "XP")
                {
                    PredmetXP or = new PredmetXP();
                    or.Naziv = pr.Naziv;
                    or.Opis = pr.Opis;
                    or.BonusUIskustvu = bonisk;
                    or.RasePremdet = rase;
                    Staza st = s.Load<Staza>(staza);
                    or.NazivStaze = st;
                    s.Save(or);

                    s.Flush();

                    s.Close();
                }




            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static void obrisiPredmet(string naziv)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Predmet p = s.Load<Predmet>(naziv);
                s.Delete(p);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            { }

        }

        public static KljucniPredmetBasic izmeniKljucniPredmet(KljucniPredmetBasic predmet, string naziv)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                KljucniPredmet i = s.Load<KljucniPredmet>(naziv);
                i.Opis = predmet.Opis;
                i.NadimciLikova = predmet.NadimciLikova;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return predmet;
        }

        public static PredmetXPBasic izmeniPredmetXP(PredmetXPBasic predmet, string naziv)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                PredmetXP i = s.Load<PredmetXP>(naziv);
                i.Opis = predmet.Opis;
                i.BonusUIskustvu = predmet.BonusUIskustvu;
                i.RasePremdet = predmet.RasePredmet;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return predmet;
        }

        #endregion
        #region Lik
        public static List<LikPregled> vratiLikove()
        {
            List<LikPregled> odInfos = new List<LikPregled>();
            try
            {
                ISession s = DataLayer.GetSession();


                IQuery q = s.CreateQuery("from Lik");
                IList<Lik> likovi = q.List<Lik>();

                foreach (Lik i in likovi)
                {
                    odInfos.Add(new LikPregled(i.KolicinaZlata, i.Ime, i.Iskustvo, i.StepenZamora, i.NivoZdravstvenogStanja,
                        i.Klasa, i.FCovek, i.FPatuljak, i.FOrk, i.FDemon, i.FVilenjak, i.UmesnostSkrivanja, i.TipOruzja, i.EnergijaZaMagiju.ToString()));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return odInfos;
        }
        public static void sacuvajLika(LikBasic lik, string klasaLika, string rasaLika, int igracID, int zamke, int buka, string religija,
            string blagoslov, char lecenje, char luksamostrel, int oklop, char oberuke, char stit, string magije)
        {
            //TimBasic t = new TimBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                if (klasaLika == "LOPOV")
                {
                    Lopov ok = new Lopov();
                    ok.Ime = lik.Ime;
                    ok.KolicinaZlata = lik.KolicinaZlata;
                    ok.Iskustvo = ok.Iskustvo;
                    ok.StepenZamora = lik.StepenZamora;
                    ok.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                    ok.MaxNivoZamki = zamke;
                    ok.NivoBuke = buka;
                    ok.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                    ok.TipOruzja = lik.TipOruzja;
                    ok.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                    ok.FCovek = lik.FCovek;
                    ok.FPatuljak = lik.FPatuljak;
                    ok.FOrk = lik.FOrk;
                    ok.FDemon = lik.FDemon;
                    ok.FVilenjak = lik.FVilenjak;
                    Igrac st = s.Load<Igrac>(igracID);
                    ok.Igrac = st;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                else if (klasaLika == "SVESTENIK")
                {
                    Svestenik ok = new Svestenik();
                    ok.Ime = lik.Ime;
                    ok.KolicinaZlata = lik.KolicinaZlata;
                    ok.Iskustvo = ok.Iskustvo;
                    ok.StepenZamora = lik.StepenZamora;
                    ok.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                    ok.TipBlagoslova = blagoslov;
                    ok.TipReligije = religija;
                    ok.MogucnostLecenja = lecenje;
                    ok.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                    ok.TipOruzja = lik.TipOruzja;
                    ok.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                    ok.FCovek = lik.FCovek;
                    ok.FPatuljak = lik.FPatuljak;
                    ok.FOrk = lik.FOrk;
                    ok.FDemon = lik.FDemon;
                    ok.FVilenjak = lik.FVilenjak;
                    Igrac st = s.Load<Igrac>(igracID);
                    ok.Igrac = st;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                if (klasaLika == "STRELAC")
                {
                    Strelac ok = new Strelac();
                    ok.Ime = lik.Ime;
                    ok.KolicinaZlata = lik.KolicinaZlata;
                    ok.Iskustvo = ok.Iskustvo;
                    ok.StepenZamora = lik.StepenZamora;
                    ok.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                    ok.LukIliSamostrel = luksamostrel;
                    ok.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                    ok.TipOruzja = lik.TipOruzja;
                    ok.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                    ok.FCovek = lik.FCovek;
                    ok.FPatuljak = lik.FPatuljak;
                    ok.FOrk = lik.FOrk;
                    ok.FDemon = lik.FDemon;
                    ok.FVilenjak = lik.FVilenjak;
                    Igrac st = s.Load<Igrac>(igracID);
                    ok.Igrac = st;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                else if (klasaLika == "OKLOPNIK")
                {
                    Oklopnik ok = new Oklopnik();
                    ok.Ime = lik.Ime;
                    ok.KolicinaZlata = lik.KolicinaZlata;
                    ok.Iskustvo = ok.Iskustvo;
                    ok.StepenZamora = lik.StepenZamora;
                    ok.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                    ok.MaxTezinaOklopa = oklop;
                    ok.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                    ok.TipOruzja = lik.TipOruzja;
                    ok.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                    ok.FCovek = lik.FCovek;
                    ok.FPatuljak = lik.FPatuljak;
                    ok.FOrk = lik.FOrk;
                    ok.FDemon = lik.FDemon;
                    ok.FVilenjak = lik.FVilenjak;
                    Igrac st = s.Load<Igrac>(igracID);
                    ok.Igrac = st;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                if (klasaLika == "BORAC")
                {
                    Borac ok = new Borac();
                    ok.Ime = lik.Ime;
                    ok.KolicinaZlata = lik.KolicinaZlata;
                    ok.Iskustvo = ok.Iskustvo;
                    ok.StepenZamora = lik.StepenZamora;
                    ok.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                    ok.OruzjeUObeRuke = oberuke;
                    ok.KoristiStit = stit;
                    ok.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                    ok.TipOruzja = lik.TipOruzja;
                    ok.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                    ok.FCovek = lik.FCovek;
                    ok.FPatuljak = lik.FPatuljak;
                    ok.FOrk = lik.FOrk;
                    ok.FDemon = lik.FDemon;
                    ok.FVilenjak = lik.FVilenjak;
                    Igrac st = s.Load<Igrac>(igracID);
                    ok.Igrac = st;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                else if (klasaLika == "CAROBNJAK")
                {
                    Carobnjak ok = new Carobnjak();
                    ok.Ime = lik.Ime;
                    ok.KolicinaZlata = lik.KolicinaZlata;
                    ok.Iskustvo = ok.Iskustvo;
                    ok.StepenZamora = lik.StepenZamora;
                    ok.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                    ok.SpisakMagija = magije;
                    ok.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                    ok.TipOruzja = lik.TipOruzja;
                    ok.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                    ok.FCovek = lik.FCovek;
                    ok.FPatuljak = lik.FPatuljak;
                    ok.FOrk = lik.FOrk;
                    ok.FDemon = lik.FDemon;
                    ok.FVilenjak = lik.FVilenjak;
                    Igrac st = s.Load<Igrac>(igracID);
                    ok.Igrac = st;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }



            }
            catch (Exception ec)
            {
                //handle exceptions
            }
        }
        public static void obrisiLika(int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Lik l = s.Load<Lik>(id);
                s.Delete(l);
                s.Flush();
                s.Close();
            }
            catch (Exception ex)
            { }

        }

        public static LopovBasic izmeniLopova(LopovBasic lik, int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Lopov i = s.Load<Lopov>(id);
                i.Ime = lik.Ime;
                i.KolicinaZlata = lik.KolicinaZlata;
                i.Iskustvo = lik.Iskustvo;
                i.StepenZamora = lik.StepenZamora;
                i.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                i.FCovek = lik.FCovek;
                i.FPatuljak = lik.FPatuljak;
                i.FOrk = lik.FOrk;
                i.FDemon = lik.FDemon;
                i.FVilenjak = lik.FVilenjak;
                i.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                i.TipOruzja = lik.TipOruzja;
                i.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                i.MaxNivoZamki = lik.MaxNivoZamki;
                i.NivoBuke = lik.NivoBuke;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return lik;
        }

        public static SvestenikBasic izmeniSvestenika(SvestenikBasic lik, int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Svestenik i = s.Load<Svestenik>(id);
                i.Ime = lik.Ime;
                i.KolicinaZlata = lik.KolicinaZlata;
                i.Iskustvo = lik.Iskustvo;
                i.StepenZamora = lik.StepenZamora;
                i.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                i.FCovek = lik.FCovek;
                i.FPatuljak = lik.FPatuljak;
                i.FOrk = lik.FOrk;
                i.FDemon = lik.FDemon;
                i.FVilenjak = lik.FVilenjak;
                i.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                i.TipOruzja = lik.TipOruzja;
                i.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                i.TipBlagoslova = lik.TipBlagoslova;
                i.TipReligije = lik.TipReligije;
                i.MogucnostLecenja = lik.MogucnostLecenja;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return lik;
        }

        public static StrelacBasic izmeniStrelca(StrelacBasic lik, int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Strelac i = s.Load<Strelac>(id);
                i.Ime = lik.Ime;
                i.KolicinaZlata = lik.KolicinaZlata;
                i.Iskustvo = lik.Iskustvo;
                i.StepenZamora = lik.StepenZamora;
                i.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                i.FCovek = lik.FCovek;
                i.FPatuljak = lik.FPatuljak;
                i.FOrk = lik.FOrk;
                i.FDemon = lik.FDemon;
                i.FVilenjak = lik.FVilenjak;
                i.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                i.TipOruzja = lik.TipOruzja;
                i.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                i.LukIliSamostrel = lik.LukIliSamostrel;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return lik;
        }

        public static OklopnikBasic izmeniOklopnika(OklopnikBasic lik, int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Oklopnik i = s.Load<Oklopnik>(id);
                i.Ime = lik.Ime;
                i.KolicinaZlata = lik.KolicinaZlata;
                i.Iskustvo = lik.Iskustvo;
                i.StepenZamora = lik.StepenZamora;
                i.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                i.FCovek = lik.FCovek;
                i.FPatuljak = lik.FPatuljak;
                i.FOrk = lik.FOrk;
                i.FDemon = lik.FDemon;
                i.FVilenjak = lik.FVilenjak;
                i.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                i.TipOruzja = lik.TipOruzja;
                i.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                i.MaxTezinaOklopa = lik.MaxTezinaOklopa;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return lik;
        }

        public static BoracBasic izmeniBorca(BoracBasic lik, int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Borac i = s.Load<Borac>(id);
                i.Ime = lik.Ime;
                i.KolicinaZlata = lik.KolicinaZlata;
                i.Iskustvo = lik.Iskustvo;
                i.StepenZamora = lik.StepenZamora;
                i.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                i.FCovek = lik.FCovek;
                i.FPatuljak = lik.FPatuljak;
                i.FOrk = lik.FOrk;
                i.FDemon = lik.FDemon;
                i.FVilenjak = lik.FVilenjak;
                i.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                i.TipOruzja = lik.TipOruzja;
                i.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                i.OruzjeUObeRuke = lik.OruzjeUObeRuke;
                i.KoristiStit=lik.KoristiStit;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return lik;
        }

        public static CarobnjakBasic izmeniCarobnjaka(CarobnjakBasic lik, int id)
        {
            try
            {
                ISession s = DataLayer.GetSession();
                Carobnjak i = s.Load<Carobnjak>(id);
                i.Ime = lik.Ime;
                i.KolicinaZlata = lik.KolicinaZlata;
                i.Iskustvo = lik.Iskustvo;
                i.StepenZamora = lik.StepenZamora;
                i.NivoZdravstvenogStanja = lik.NivoZdravstvenogStanja;
                i.FCovek = lik.FCovek;
                i.FPatuljak = lik.FPatuljak;
                i.FOrk = lik.FOrk;
                i.FDemon = lik.FDemon;
                i.FVilenjak = lik.FVilenjak;
                i.UmesnostSkrivanja = lik.UmesnostSkrivanja;
                i.TipOruzja = lik.TipOruzja;
                i.EnergijaZaMagiju = lik.EnergijaZaMagiju;
                i.SpisakMagija = lik.SpisakMagija;
                s.SaveOrUpdate(i);
                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
            }
            return lik;
        }

        #endregion
    }
}