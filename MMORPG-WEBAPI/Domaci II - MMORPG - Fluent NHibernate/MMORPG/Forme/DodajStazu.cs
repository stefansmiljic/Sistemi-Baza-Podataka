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

namespace MMORPG.Forme
{
    public partial class DodajStazu : Form
    {
        public DodajStazu()
        {
            InitializeComponent();
        }
        public void popuniPodacima()
        {
            staze.Items.Clear();
            List<StazaPregled> pomLista = DTOManager.vratiStaze();
            foreach (StazaPregled i in pomLista)
            {
                
                ListViewItem item = new ListViewItem(new string[] { i.Naziv, i.BonusPoeni.ToString(), i.Potrebne_Rase, i.Potreble_Klase });
                staze.Items.Add(item);
            }

            staze.Refresh();
        }

        private void DodajStazu_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            List<IgracPregled> t = DTOManager.vratiIgrace();
            foreach (IgracPregled igrac in t)
            {
                comboIgrac.ValueMember = igrac.ID;
                comboIgrac.Items.Add(igrac.Ime + " " + igrac.Prezime);
            }
            List<TimPregled> t1 = DTOManager.vratiTimove();
            foreach (TimPregled tim in t1)
            {
                comboTim.Items.Add(tim.Naziv);
            }
        }

        private void comboIgrac_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Igrac")
            {
                textBox6.Enabled = true;
                textBox5.Enabled = true;
                comboTim.Enabled = false;
                comboIgrac.Enabled = true;
            }
            else if (comboBox1.Text == "Tim")
            {
                textBox6.Enabled = false;
                textBox5.Enabled = false;
                comboTim.Enabled = true;
                comboIgrac.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Igrac")
            {
                StazaZaIgracaBasic o = new StazaZaIgracaBasic();
                o.Naziv = textBox1.Text;
                o.BonusPoeni = Convert.ToInt32(textBox2.Text);
                o.Potrebne_Rase = textBox3.Text;
                o.Potrebne_Klase = textBox4.Text;
                comboTim.Text = "";
                //o.BrIgranjaStaze = Convert.ToInt32(textBox5.Text);
                //o.BrUbijenihNeprijatelja = Convert.ToInt32(textBox6.Text);
                DTOManager.sacuvajStazu(o, comboBox1.Text, Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text), Convert.ToInt32(comboIgrac.ValueMember), comboTim.Text);
                MessageBox.Show("Uspesno ste dodali novu stazu za igraca!");
                this.Close();
            }
            else if (comboBox1.Text == "Tim")
            {
                StazaZaTimBasic o = new StazaZaTimBasic();
                o.Naziv = textBox1.Text;
                o.BonusPoeni = Convert.ToInt32(textBox2.Text);
                o.Potrebne_Rase = textBox3.Text;
                o.Potrebne_Klase = textBox4.Text;
                textBox5.Text = "0";
                textBox6.Text = "0";
                comboIgrac.ValueMember = "0";
                DTOManager.sacuvajStazu(o,comboBox1.Text, Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text), Convert.ToInt32(comboIgrac.ValueMember), comboTim.Text);
                MessageBox.Show("Uspesno ste dodali novu stazu za tim!");
                this.Close();
            }
        }
    }
}
