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
    public partial class DodajPredmet : Form
    {
        public DodajPredmet()
        {
            InitializeComponent();
            popuniPodacima();
            List<StazaPregled> t = DTOManager.vratiStaze();
            foreach (StazaPregled t1 in t)
            {
                comboBox1.Items.Add(t1.Naziv);
            }
        }
        public void popuniPodacima()
        {
            predmeti.Items.Clear();
            List<PredmetPregled> pomLista = DTOManager.vratiPredmete();
            foreach (PredmetPregled i in pomLista)
            {
                ListViewItem item = new ListViewItem(new string[] { i.Naziv, i.Opis,i.Staza });
                predmeti.Items.Add(item);
            }

            predmeti.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Kljucni")
            {
                KljucniPredmetBasic o = new KljucniPredmetBasic();
                o.Naziv = textBox1.Text;
                o.Opis = textBox2.Text;
                textBox5.Text = "0";
                textBox6.Text = "";
                DTOManager.sacuvajPredmet(o, comboBox2.Text, textBox4.Text, Convert.ToInt32(textBox5.Text), textBox6.Text, comboBox1.Text);
                MessageBox.Show("Uspesno ste dodali novi kljucni predmet!");
                this.Close();
            }
            else if (comboBox2.Text == "XP")
            {
                PredmetXPBasic o = new PredmetXPBasic();
                o.Naziv = textBox1.Text;
                o.Opis = textBox2.Text;
                textBox4.Text = "";
                DTOManager.sacuvajPredmet(o, comboBox2.Text, textBox4.Text, Convert.ToInt32(textBox5.Text), textBox6.Text, comboBox1.Text);
                MessageBox.Show("Uspesno ste dodali novi XP predmet!");
                this.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Kljucni")
            {
                textBox6.Enabled = false;
                textBox5.Enabled = false;
                textBox4.Enabled = true;
            }
            else if (comboBox2.Text == "XP")
            {
                textBox6.Enabled = true;
                textBox5.Enabled = true;
                textBox4.Enabled = false;
            }
        }
    }
}
