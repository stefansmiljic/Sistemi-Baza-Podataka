using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMORPG.Entiteti;
using NHibernate.Linq;
using NHibernate;
using NHibernate.Util;
using System.Windows.Forms.VisualStyles;

namespace MMORPG
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

                MMORPG.Entiteti.Igrac i = new MMORPG.Entiteti.Igrac();

                Tim t1 = s.Load<MMORPG.Entiteti.Tim>(naziv);

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

                foreach(Tim t in timovi)
                {
                    Infos.Add(new TimPregled(t.Naziv, t.Plasman, t.BonusPoeni, t.Max, t.Min));
                }

                s.Close();
            }
            catch(Exception ec)
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

                MMORPG.Entiteti.Tim t = new MMORPG.Entiteti.Tim();
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
                    odInfos.Add(new PomocnikPregled(i.Ime, i.Rasa, i.Klasa, i.BonusUZastiti, i.Igrac.Ime+" "+i.Igrac.Prezime));
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

                MMORPG.Entiteti.Pomocnik p = new MMORPG.Entiteti.Pomocnik();
                int ajdi = Convert.ToInt32(idigraca);
                Igrac igrac = s.Load<MMORPG.Entiteti.Igrac>(ajdi);

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
        public static void sacuvajProizvod(ProizvodBasic pro, string tipProizvoda,int poeni)
        {
            //TimBasic t = new TimBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                if(tipProizvoda=="Oklop")
                {
                    Entiteti.Oklop ok = new Entiteti.Oklop();
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
                else if(tipProizvoda=="Oruzje")
                {
                    Entiteti.Oruzje or = new Entiteti.Oruzje();
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
                        odInfos.Add(new StazaPregled(i.Naziv, i.BonusPoeni, i.Potrebne_Klase, i.Potrebne_Rase ));
                }

                s.Close();

            }
            catch (Exception ec)
            {
                //handle exceptions
            }

            return odInfos;
        }
        public static void sacuvajStazu(StazaBasic staza,string tipStaze, int brigr, int brUb, int igrId, string tim)
        {
            //TimBasic t = new TimBasic();
            try
            {
                ISession s = DataLayer.GetSession();

                if (tipStaze == "Igrac")
                {
                    Entiteti.StazaZaIgraca ok = new Entiteti.StazaZaIgraca();
                    ok.Naziv = staza.Naziv;
                    ok.BonusPoeni = staza.BonusPoeni;
                    ok.Tip = "IGRAC";
                    ok.Potrebne_Rase = staza.Potrebne_Rase;
                    ok.Potrebne_Klase = staza.Potrebne_Klase;
                    ok.BrIgranjaStaze = brigr;
                    ok.BrUbijenihNeprijatelja = brUb;
                    Entiteti.Igrac igrac= s.Load<Entiteti.Igrac>(igrId);
                    ok.Igrac = igrac;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                else if (tipStaze == "Tim")
                {
                    Entiteti.StazaZaTim or = new Entiteti.StazaZaTim();
                    or.Naziv = staza.Naziv;
                    or.BonusPoeni = staza.BonusPoeni;
                    or.Tip = "IGRAC";
                    or.Potrebne_Rase = staza.Potrebne_Rase;
                    or.Potrebne_Klase = staza.Potrebne_Klase;
                    Entiteti.Tim tims = s.Load<Entiteti.Tim>(tim);
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
                    Entiteti.KljucniPredmet ok = new Entiteti.KljucniPredmet();
                    ok.Naziv = pr.Naziv;
                    ok.Opis = pr.Opis;
                    ok.NadimciLikova = nadimci;
                    Entiteti.Staza st = s.Load<Entiteti.Staza>(staza);
                    ok.NazivStaze = st;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                else if (tipPredmeta == "XP")
                {
                    Entiteti.PredmetXP or = new Entiteti.PredmetXP();
                    or.Naziv = pr.Naziv;
                    or.Opis = pr.Opis;
                    or.BonusUIskustvu = bonisk;
                    or.RasePremdet = rase;
                    Entiteti.Staza st = s.Load<Entiteti.Staza>(staza);
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
                    odInfos.Add(new LikPregled(i.KolicinaZlata,i.Ime,i.Iskustvo,i.StepenZamora,i.NivoZdravstvenogStanja,
                        i.Klasa,i.FCovek,i.FPatuljak,i.FOrk,i.FDemon,i.FVilenjak,i.UmesnostSkrivanja,i.TipOruzja,i.EnergijaZaMagiju.ToString()));
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
                    Entiteti.Lopov ok = new Entiteti.Lopov();
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
                    Entiteti.Igrac st = s.Load<Entiteti.Igrac>(igracID);
                    ok.Igrac = st;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                else if (klasaLika == "SVESTENIK")
                {
                    Entiteti.Svestenik ok = new Entiteti.Svestenik();
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
                    Entiteti.Igrac st = s.Load<Entiteti.Igrac>(igracID);
                    ok.Igrac = st;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                if (klasaLika == "STRELAC")
                {
                    Entiteti.Strelac ok = new Entiteti.Strelac();
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
                    Entiteti.Igrac st = s.Load<Entiteti.Igrac>(igracID);
                    ok.Igrac = st;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                else if (klasaLika == "OKLOPNIK")
                {
                    Entiteti.Oklopnik ok = new Entiteti.Oklopnik();
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
                    Entiteti.Igrac st = s.Load<Entiteti.Igrac>(igracID);
                    ok.Igrac = st;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                if (klasaLika == "BORAC")
                {
                    Entiteti.Borac ok = new Entiteti.Borac();
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
                    Entiteti.Igrac st = s.Load<Entiteti.Igrac>(igracID);
                    ok.Igrac = st;
                    s.Save(ok);

                    s.Flush();

                    s.Close();
                }
                else if (klasaLika == "CAROBNJAK")
                {
                    Entiteti.Carobnjak ok = new Entiteti.Carobnjak();
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
                    Entiteti.Igrac st = s.Load<Entiteti.Igrac>(igracID);
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
        #endregion
    }
}
