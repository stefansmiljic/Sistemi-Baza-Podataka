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
    public partial class KreirajProizvod : Form
    {
        public KreirajProizvod()
        {
            InitializeComponent();
            popuniPodacima();
        }
        public void popuniPodacima()
        {
            proizvodi.Items.Clear();
            List<ProizvodPregled> pomLista = DTOManager.vratiProizvode();
            foreach (ProizvodPregled i in pomLista)
            {
                ListViewItem item = new ListViewItem(new string[] { i.Naziv, i.Opis,i.Rase, i.Klase });
                proizvodi.Items.Add(item);
            }

            proizvodi.Refresh();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Oklop")
            {
                OklopBasic o = new OklopBasic();
                o.Naziv = textBox1.Text;
                o.Opis = textBox2.Text;
                o.Rase = textBox3.Text;
                o.Klase = textBox4.Text;
                DTOManager.sacuvajProizvod(o, comboBox1.Text, Convert.ToInt32(textBox6.Text));
                MessageBox.Show("Uspesno ste dodali novi proizvod!");
                this.Close();
            }
            else if(comboBox1.Text == "Oruzje")
            {
                OruzjeBasic o = new OruzjeBasic();
                o.Naziv = textBox1.Text;
                o.Opis = textBox2.Text;
                o.Rase = textBox3.Text;
                o.Klase = textBox4.Text;
                DTOManager.sacuvajProizvod(o, comboBox1.Text, Convert.ToInt32(textBox5.Text));
                MessageBox.Show("Uspesno ste dodali novi proizvod!");
                this.Close();
            }
           
            //o.Tim = DTOManager.vratiTim(comboTimovi.Text);
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text=="Oklop")
            {
                textBox6.Enabled = true;
                textBox5.Enabled = false;
            }
            else if(comboBox1.Text == "Oruzje")
            {
                textBox6.Enabled = false;
                textBox5.Enabled = true;
            }
        }

        private void KreirajProizvod_Load(object sender, EventArgs e)
        {

        }
    }
}
