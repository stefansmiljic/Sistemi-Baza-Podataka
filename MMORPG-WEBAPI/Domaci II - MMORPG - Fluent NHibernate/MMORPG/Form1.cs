using MMORPG.Entiteti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHibernate;

namespace MMORPG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdPodaciOIgracu_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                Igrac p = s.Load<Igrac>(1);

                MessageBox.Show(p.Lozinka);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdDodajTim_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();


                Entiteti.Tim p = new Entiteti.Tim();

                //p = s.Load<Entiteti.Prodavnica>(81);

                p.Naziv = "Tim5";
                p.Plasman = 5;
                p.BonusPoeni = 204;
                p.Max = 5;
                p.Min = 1;


                //s.Save(p);
                s.SaveOrUpdate(p);

                s.Flush();
                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdManyToOne_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                Igrac o = s.Load<Igrac>(3);

                MessageBox.Show(o.Lozinka);
                MessageBox.Show(o.Tim.Naziv);

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdOneToMany_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici sa zadatim brojem
                MMORPG.Entiteti.Tim p = s.Load<MMORPG.Entiteti.Tim>("Tim1");

                foreach (Igrac o in p.Igraci)
                {
                    MessageBox.Show(o.Lozinka + " " + o.Uzrast);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdKreirajIgraca_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Tim p = new Entiteti.Tim()
                {
                    Naziv = "Dragons",
                    Plasman = 2,
                    BonusPoeni = 220,
                    Max = 5,
                    Min = 1
                };

                Igrac o = new Igrac()
                {
                    Ime = "Stefan",
                    Prezime = "Miladinovic",
                    Pol = 'M',
                    Nadimak = "Stefi",
                    Lozinka = "stefi998",
                    Uzrast = 22
                };

                Igrac o1 = new Igrac()
                {
                    Ime = "Uros",
                    Prezime = "Zivkovic",
                    Pol = 'M',
                    Nadimak = "Urke",
                    Lozinka = "uros996",
                    Uzrast = 23
                };




                o.Tim = p;

                o1.Tim = p;

                p.Igraci.Add(o);
                p.Igraci.Add(o1);

                s.Save(p);

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void cmdManyToMany_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Igrac i1 = s.Load<Igrac>(1);

                foreach (Entiteti.Proizvod p1 in i1.Proizvodi)
                {
                    MessageBox.Show(p1.Naziv);
                }


                Entiteti.Proizvod p2 = s.Load<Entiteti.Proizvod>("Gvozdeni oklop");

                foreach (Igrac i2 in p2.Igraci)
                {
                    MessageBox.Show(i2.Ime + " " + i2.Prezime);
                }

                s.Close();
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void svestenikBtn_Click(object sender, EventArgs e)
        {
            /*try
            {
                ISession s = DataLayer.GetSession();

                //Ucitavaju se podaci o prodavnici za zadatim brojem
                Lik l = s.Load<Lik>(1);

                MessageBox.Show(l.KolicinaZlata.ToString());
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }*/
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Igrac i = s.Load<MMORPG.Entiteti.Igrac>(1);

                Oruzje o = new Oruzje()
                {
                    Naziv = "Mac",
                    Opis = "Efektan je za borbu izbliza",
                    Klase = "CAROBNJAK, BORAC, OKLOPNIK, SVESTENIK, LOPOV",
                    Rase = "COVEK, PATULJAK, ORK, VILENJAK, DEMON",
                    PoeniZaNapad = 99
                };

                o.Igraci.Add(i);
                i.Proizvodi.Add(o);
                s.Save(o);

                s.Flush();
                s.Close();



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Tim tim = s.Load<MMORPG.Entiteti.Tim>("Eagles");
                //Entiteti.Igrac i = s.Load<MMORPG.Entiteti.Igrac>(1);

                StazaZaTim st = new StazaZaTim();

                st.Naziv = "Mountain";
                st.BonusPoeni = 33;
                st.Potrebne_Klase = "STRELAC, BORAC, CAROBNJAK";
                st.Potrebne_Rase = "COVEK, VILENJAK, PATULJAK";
                //st.BrIgranjaStaze = 3;
                //st.BrUbijenihNeprijatelja = 31;
                st.Tim = tim;
                

                s.Save(st);
                s.Flush();
                s.Close();

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void createSesija_Click(object sender, EventArgs e)
        {
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Igrac p = s.Load<Entiteti.Igrac>(1);

                Sesija s1 = new Sesija();
                s1.ZaradjeniGold = 20;
                s1.ZaradjeniXPpoeni = 25;
                s1.VremePovezivanjaNaServer = DateTime.Now;
                s1.VremeUcestvovanja = DateTime.Now;
                s1.Igrac = p;

                s.Save(s1);

                s.Flush();
                s.Close();



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
        }

        private void btnTimVsTim_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                ISession s = DataLayer.GetSession();

                Entiteti.Tim t1 = s.Load<Entiteti.Tim>("Tim1");
                Entiteti.Tim t2 = s.Load<Entiteti.Tim>("Eagles");

                TimVsTim mec = new TimVsTim();

                mec.ID.PrviTim= t1;
                mec.ID.DrugiTim = t2;
                mec.Pobednik = t1;
                mec.VremeOdrzavanja = DateTime.Now;

                s.Save(mec);

                s.Flush();
                s.Close();



            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
