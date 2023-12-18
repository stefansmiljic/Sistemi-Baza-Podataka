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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MMORPG.Forme
{
    public partial class DodajLika : Form
    {
        public DodajLika()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void DodajLika_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            List<IgracPregled> t = DTOManager.vratiIgrace();
            foreach (IgracPregled t1 in t)
            {
                comboIgrac.ValueMember = t1.ID;
                comboIgrac.Items.Add(t1.Ime + " " + t1.Prezime);
            }
        }
        public void popuniPodacima()
        {
            likovi.Items.Clear();
            List<LikPregled> pomLista = DTOManager.vratiLikove();
            foreach (LikPregled i in pomLista)
            {
                ListViewItem item = new ListViewItem(new string[] { i.Ime,i.NivoZdravstvenogStanja.ToString(), i.StepenZamora.ToString(), i.Iskustvo.ToString(), i.KolicinaZlata.ToString(), i.FCovek.ToString(), i.UmesnostSkrivanja,i.FPatuljak.ToString(), i.FOrk.ToString(), i.TipOruzja,i.FDemon.ToString(), i.FVilenjak.ToString(), i.EnergijaZaMagiju});
                likovi.Items.Add(item);
            }

            likovi.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboKlasa.Text == "LOPOV")
            {
                LopovBasic o = new LopovBasic();
                o.Ime = textBox1.Text;
                o.NivoZdravstvenogStanja = Convert.ToInt32(textBox2.Text);
                o.StepenZamora = Convert.ToInt32(textBox3.Text);
                o.Iskustvo = Convert.ToInt32(textBox4.Text);
                o.KolicinaZlata = Convert.ToInt32(textBox5.Text);
                o.MaxNivoZamki = Convert.ToInt32(txtZamke.Text);
                o.NivoBuke = Convert.ToInt32(txtNivoBuke.Text);

                if(comboRasa.Text=="COVEK")
                {
                    o.FCovek = '1';
                    o.UmesnostSkrivanja = txtSkrivanje.Text;
                }
                else if (comboRasa.Text == "PATULJAK")
                {
                    o.FPatuljak = '1';
                    o.TipOruzja = txtTipOruzja.Text;
                }
                else if (comboRasa.Text == "ORK")
                {
                    o.FOrk = '1';
                    o.TipOruzja = txtTipOruzja.Text;
                }
                else if (comboRasa.Text == "DEMON")
                {
                    o.FDemon = '1';
                    o.EnergijaZaMagiju = Convert.ToInt32(txtEnergMagija.Text);
                }
                else if (comboRasa.Text == "VILENJAK")
                {
                    o.FVilenjak = '1';
                    o.EnergijaZaMagiju = Convert.ToInt32(txtEnergMagija.Text);
                }

                txtReligija.Text = ""; txtMagije.Text = "";
                txtBlagoslov.Text = ""; comboLecenje.Text = "N"; comboLuk.Text = "N";
                txtOklop.Text = ""; comboObeRuke.Text = "N"; comboStit.Text = "N";

                DTOManager.sacuvajLika(o, comboKlasa.Text, comboRasa.Text, Convert.ToInt32(comboIgrac.ValueMember),Convert.ToInt32(txtZamke.Text),Convert.ToInt32(txtNivoBuke.Text), txtReligija.Text,txtBlagoslov.Text,Convert.ToChar(comboLecenje.Text), Convert.ToChar(comboLuk.Text), Convert.ToInt32(txtOklop.Text), Convert.ToChar(comboObeRuke.Text), Convert.ToChar(comboStit.Text), txtMagije.Text);
                MessageBox.Show("Uspesno ste dodali novog lopova!");
                this.Close();
            }
            else if (comboKlasa.Text == "SVESTENIK")
            {
                SvestenikBasic o = new SvestenikBasic();
                o.Ime = textBox1.Text;
                o.NivoZdravstvenogStanja = Convert.ToInt32(textBox2.Text);
                o.StepenZamora = Convert.ToInt32(textBox3.Text);
                o.Iskustvo = Convert.ToInt32(textBox4.Text);
                o.KolicinaZlata = Convert.ToInt32(textBox5.Text);
                o.TipBlagoslova = txtBlagoslov.Text;
                o.TipReligije = txtReligija.Text;
                o.MogucnostLecenja = Convert.ToChar(comboLecenje.Text);

                if (comboRasa.Text == "COVEK")
                {
                    o.FCovek = '1';
                    o.UmesnostSkrivanja = txtSkrivanje.Text;
                }
                else if (comboRasa.Text == "PATULJAK")
                {
                    o.FPatuljak = '1';
                    o.TipOruzja = txtTipOruzja.Text;
                }
                else if (comboRasa.Text == "ORK")
                {
                    o.FOrk = '1';
                    o.TipOruzja = txtTipOruzja.Text;
                }
                else if (comboRasa.Text == "DEMON")
                {
                    o.FDemon = '1';
                    o.EnergijaZaMagiju = Convert.ToInt32(txtEnergMagija.Text);
                }
                else if (comboRasa.Text == "VILENJAK")
                {
                    o.FVilenjak = '1';
                    o.EnergijaZaMagiju = Convert.ToInt32(txtEnergMagija.Text);
                }

                txtZamke.Text = "0"; txtNivoBuke.Text = "0";
                 comboLuk.Text = "N"; txtMagije.Text = "";
                txtOklop.Text = "0"; comboObeRuke.Text = "N"; comboStit.Text = "N";

                DTOManager.sacuvajLika(o, comboKlasa.Text, comboRasa.Text, Convert.ToInt32(comboIgrac.ValueMember), Convert.ToInt32(txtZamke.Text), Convert.ToInt32(txtNivoBuke.Text), txtReligija.Text, txtBlagoslov.Text, Convert.ToChar(comboLecenje.Text), Convert.ToChar(comboLuk.Text), Convert.ToInt32(txtOklop.Text), Convert.ToChar(comboObeRuke.Text), Convert.ToChar(comboStit.Text), txtMagije.Text);
                MessageBox.Show("Uspesno ste dodali novi XP predmet!");
                this.Close();
            }
            else if (comboKlasa.Text == "STRELAC")
            {
                StrelacBasic o = new StrelacBasic();
                o.Ime = textBox1.Text;
                o.NivoZdravstvenogStanja = Convert.ToInt32(textBox2.Text);
                o.StepenZamora = Convert.ToInt32(textBox3.Text);
                o.Iskustvo = Convert.ToInt32(textBox4.Text);
                o.KolicinaZlata = Convert.ToInt32(textBox5.Text);
                o.LukIliSamostrel = Convert.ToChar(comboLuk.Text);

                if (comboRasa.Text == "COVEK")
                {
                    o.FCovek = '1';
                    o.UmesnostSkrivanja = txtSkrivanje.Text;
                }
                else if (comboRasa.Text == "PATULJAK")
                {
                    o.FPatuljak = '1';
                    o.TipOruzja = txtTipOruzja.Text;
                }
                else if (comboRasa.Text == "ORK")
                {
                    o.FOrk = '1';
                    o.TipOruzja = txtTipOruzja.Text;
                }
                else if (comboRasa.Text == "DEMON")
                {
                    o.FDemon = '1';
                    o.EnergijaZaMagiju = Convert.ToInt32(txtEnergMagija.Text);
                }
                else if (comboRasa.Text == "VILENJAK")
                {
                    o.FVilenjak = '1';
                    o.EnergijaZaMagiju = Convert.ToInt32(txtEnergMagija.Text);
                }

                txtZamke.Text = "0"; txtNivoBuke.Text = "0"; txtReligija.Text = "";
                txtBlagoslov.Text = ""; comboLecenje.Text = "N"; txtMagije.Text = "";
                txtOklop.Text = "0"; comboObeRuke.Text = "N"; comboStit.Text = "N";

                DTOManager.sacuvajLika(o, comboKlasa.Text, comboRasa.Text, Convert.ToInt32(comboIgrac.ValueMember), Convert.ToInt32(txtZamke.Text), Convert.ToInt32(txtNivoBuke.Text), txtReligija.Text, txtBlagoslov.Text, Convert.ToChar(comboLecenje.Text), Convert.ToChar(comboLuk.Text), Convert.ToInt32(txtOklop.Text), Convert.ToChar(comboObeRuke.Text), Convert.ToChar(comboStit.Text), txtMagije.Text);
                MessageBox.Show("Uspesno ste dodali novi XP predmet!");
                this.Close();
            }
            else if (comboKlasa.Text == "OKLOPNIK")
            {
                OklopnikBasic o = new OklopnikBasic();
                o.Ime = textBox1.Text;
                o.NivoZdravstvenogStanja = Convert.ToInt32(textBox2.Text);
                o.StepenZamora = Convert.ToInt32(textBox3.Text);
                o.Iskustvo = Convert.ToInt32(textBox4.Text);
                o.KolicinaZlata = Convert.ToInt32(textBox5.Text);
                o.MaxTezinaOklopa = Convert.ToInt32(txtOklop);

                if (comboRasa.Text == "COVEK")
                {
                    o.FCovek = '1';
                    o.UmesnostSkrivanja = txtSkrivanje.Text;
                }
                else if (comboRasa.Text == "PATULJAK")
                {
                    o.FPatuljak = '1';
                    o.TipOruzja = txtTipOruzja.Text;
                }
                else if (comboRasa.Text == "ORK")
                {
                    o.FOrk = '1';
                    o.TipOruzja = txtTipOruzja.Text;
                }
                else if (comboRasa.Text == "DEMON")
                {
                    o.FDemon = '1';
                    o.EnergijaZaMagiju = Convert.ToInt32(txtEnergMagija.Text);
                }
                else if (comboRasa.Text == "VILENJAK")
                {
                    o.FVilenjak = '1';
                    o.EnergijaZaMagiju = Convert.ToInt32(txtEnergMagija.Text);
                }

                txtZamke.Text = "0"; txtNivoBuke.Text = "0"; txtReligija.Text = "";
                txtBlagoslov.Text = ""; comboLecenje.Text = "N"; comboLuk.Text = "N";
                comboObeRuke.Text = "N"; comboStit.Text = "N"; txtMagije.Text = "";

                DTOManager.sacuvajLika(o, comboKlasa.Text, comboRasa.Text, Convert.ToInt32(comboIgrac.ValueMember), Convert.ToInt32(txtZamke.Text), Convert.ToInt32(txtNivoBuke.Text), txtReligija.Text, txtBlagoslov.Text, Convert.ToChar(comboLecenje.Text), Convert.ToChar(comboLuk.Text), Convert.ToInt32(txtOklop.Text), Convert.ToChar(comboObeRuke.Text), Convert.ToChar(comboStit.Text), txtMagije.Text);
                MessageBox.Show("Uspesno ste dodali novi XP predmet!");
                this.Close();
            }
            else if (comboKlasa.Text == "BORAC")
            {
                BoracBasic o = new BoracBasic();
                o.Ime = textBox1.Text;
                o.NivoZdravstvenogStanja = Convert.ToInt32(textBox2.Text);
                o.StepenZamora = Convert.ToInt32(textBox3.Text);
                o.Iskustvo = Convert.ToInt32(textBox4.Text);
                o.KolicinaZlata = Convert.ToInt32(textBox5.Text);
                o.OruzjeUObeRuke = Convert.ToChar(comboObeRuke.Text);
                o.KoristiStit = Convert.ToChar(comboStit.Text);

                if (comboRasa.Text == "COVEK")
                {
                    o.FCovek = '1';
                    o.UmesnostSkrivanja = txtSkrivanje.Text;
                }
                else if (comboRasa.Text == "PATULJAK")
                {
                    o.FPatuljak = '1';
                    o.TipOruzja = txtTipOruzja.Text;
                }
                else if (comboRasa.Text == "ORK")
                {
                    o.FOrk = '1';
                    o.TipOruzja = txtTipOruzja.Text;
                }
                else if (comboRasa.Text == "DEMON")
                {
                    o.FDemon = '1';
                    o.EnergijaZaMagiju = Convert.ToInt32(txtEnergMagija.Text);
                }
                else if (comboRasa.Text == "VILENJAK")
                {
                    o.FVilenjak = '1';
                    o.EnergijaZaMagiju = Convert.ToInt32(txtEnergMagija.Text);
                }

                txtZamke.Text = "0"; txtNivoBuke.Text = "0"; txtReligija.Text = "";
                txtBlagoslov.Text = ""; comboLecenje.Text = "N"; comboLuk.Text = "N";
                txtOklop.Text = "0"; txtMagije.Text="";

                DTOManager.sacuvajLika(o, comboKlasa.Text, comboRasa.Text, Convert.ToInt32(comboIgrac.ValueMember), Convert.ToInt32(txtZamke.Text), Convert.ToInt32(txtNivoBuke.Text), txtReligija.Text, txtBlagoslov.Text, Convert.ToChar(comboLecenje.Text), Convert.ToChar(comboLuk.Text), Convert.ToInt32(txtOklop.Text), Convert.ToChar(comboObeRuke.Text), Convert.ToChar(comboStit.Text), txtMagije.Text);
                MessageBox.Show("Uspesno ste dodali novi XP predmet!");
                this.Close();
            }
            else if (comboKlasa.Text == "CAROBNJAK")
            {
                CarobnjakBasic o = new CarobnjakBasic();
                o.Ime = textBox1.Text;
                o.NivoZdravstvenogStanja = Convert.ToInt32(textBox2.Text);
                o.StepenZamora = Convert.ToInt32(textBox3.Text);
                o.Iskustvo = Convert.ToInt32(textBox4.Text);
                o.KolicinaZlata = Convert.ToInt32(textBox5.Text);
                o.SpisakMagija = txtMagije.Text;

                if (comboRasa.Text == "COVEK")
                {
                    o.FCovek = '1';
                    o.UmesnostSkrivanja = txtSkrivanje.Text;
                }
                else if (comboRasa.Text == "PATULJAK")
                {
                    o.FPatuljak = '1';
                    o.TipOruzja = txtTipOruzja.Text;
                }
                else if (comboRasa.Text == "ORK")
                {
                    o.FOrk = '1';
                    o.TipOruzja = txtTipOruzja.Text;
                }
                else if (comboRasa.Text == "DEMON")
                {
                    o.FDemon = '1';
                    o.EnergijaZaMagiju = Convert.ToInt32(txtEnergMagija.Text);
                }
                else if (comboRasa.Text == "VILENJAK")
                {
                    o.FVilenjak = '1';
                    o.EnergijaZaMagiju = Convert.ToInt32(txtEnergMagija.Text);
                }

                txtZamke.Text = "0"; txtNivoBuke.Text = "0"; txtReligija.Text = "";
                txtBlagoslov.Text = ""; comboLecenje.Text = "N"; comboLuk.Text = "N";
                txtOklop.Text = "0"; comboObeRuke.Text = "N"; comboStit.Text = "N";

                DTOManager.sacuvajLika(o, comboKlasa.Text, comboRasa.Text, Convert.ToInt32(comboIgrac.ValueMember), Convert.ToInt32(txtZamke.Text), Convert.ToInt32(txtNivoBuke.Text), txtReligija.Text, txtBlagoslov.Text, Convert.ToChar(comboLecenje.Text), Convert.ToChar(comboLuk.Text), Convert.ToInt32(txtOklop.Text), Convert.ToChar(comboObeRuke.Text), Convert.ToChar(comboStit.Text), txtMagije.Text);
                MessageBox.Show("Uspesno ste dodali novi XP predmet!");
                this.Close();
            }
        }

        private void comboRasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboRasa.Text == "COVEK")
            {
                txtSkrivanje.Enabled = true;
                txtTipOruzja.Enabled = false;
                txtEnergMagija.Enabled = false;
            }
            else if (comboRasa.Text == "PATULJAK")
            {
                txtSkrivanje.Enabled = false;
                txtTipOruzja.Enabled = true;
                txtEnergMagija.Enabled = false;
            }
            else if (comboRasa.Text == "ORK")
            {
                txtSkrivanje.Enabled = false;
                txtTipOruzja.Enabled = true;
                txtEnergMagija.Enabled = false;
            }
            else if (comboRasa.Text == "DEMON")
            {
                txtSkrivanje.Enabled = false;
                txtTipOruzja.Enabled = false;
                txtEnergMagija.Enabled = true;
            }
            else if (comboRasa.Text == "VILENJAK")
            {
                txtSkrivanje.Enabled = false;
                txtTipOruzja.Enabled = false;
                txtEnergMagija.Enabled = true;
            }
        }

        private void comboKlasa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboKlasa.Text == "LOPOV")
            {
                txtZamke.Enabled = true;
                txtNivoBuke.Enabled = true;
                txtReligija.Enabled = false;
                txtBlagoslov.Enabled = false;
                comboLecenje.Enabled = false;
                comboLuk.Enabled = false;
                txtOklop.Enabled = false;
                comboObeRuke.Enabled = false;
                comboStit.Enabled = false;
                txtMagije.Enabled = false;
            }
            else if (comboKlasa.Text == "SVESTENIK")
            {
                txtZamke.Enabled = false;
                txtNivoBuke.Enabled = false;
                txtReligija.Enabled = true;
                txtBlagoslov.Enabled = true;
                comboLecenje.Enabled = true;
                comboLuk.Enabled = false;
                txtOklop.Enabled = false;
                comboObeRuke.Enabled = false;
                comboStit.Enabled = false;
                txtMagije.Enabled = false;
            }
            else if (comboKlasa.Text == "STRELAC")
            {
                txtZamke.Enabled = false;
                txtNivoBuke.Enabled = false;
                txtReligija.Enabled = false;
                txtBlagoslov.Enabled = false;
                comboLecenje.Enabled = false;
                comboLuk.Enabled = true;
                txtOklop.Enabled = false;
                comboObeRuke.Enabled = false;
                comboStit.Enabled = false;
                txtMagije.Enabled = false;
            }
            else if (comboKlasa.Text == "OKLOPNIK")
            {
                txtZamke.Enabled = false;
                txtNivoBuke.Enabled = false;
                txtReligija.Enabled = false;
                txtBlagoslov.Enabled = false;
                comboLecenje.Enabled = false;
                comboLuk.Enabled = false;
                txtOklop.Enabled = true;
                comboObeRuke.Enabled = false;
                comboStit.Enabled = false;
                txtMagije.Enabled = false;
            }
            else if (comboKlasa.Text == "BORAC")
            {
                txtZamke.Enabled = false;
                txtNivoBuke.Enabled = false;
                txtReligija.Enabled = false;
                txtBlagoslov.Enabled = false;
                comboLecenje.Enabled = false;
                comboLuk.Enabled = false;
                txtOklop.Enabled = false;
                comboObeRuke.Enabled = true;
                comboStit.Enabled = true;
                txtMagije.Enabled = false;
            }
            else if (comboKlasa.Text == "CAROBNJAK")
            {
                txtZamke.Enabled = false;
                txtNivoBuke.Enabled = false;
                txtReligija.Enabled = false;
                txtBlagoslov.Enabled = false;
                comboLecenje.Enabled = false;
                comboLuk.Enabled = false;
                txtOklop.Enabled = false;
                comboObeRuke.Enabled = false;
                comboStit.Enabled = false;
                txtMagije.Enabled = true;
            }
        }
    }
}
