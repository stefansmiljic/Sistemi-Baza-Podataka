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
    public partial class DodajPomocnika : Form
    {
        public DodajPomocnika()
        {
            InitializeComponent();
        }
        public void popuniPodacima()
        {
            pomocnici.Items.Clear();
            List<PomocnikPregled> pomLista = DTOManager.vratiPomocnike();
            foreach (PomocnikPregled i in pomLista)
            {
                ListViewItem item = new ListViewItem(new string[] { i.Ime, i.Rasa, i.Klasa, i.BonusUZastiti.ToString(), i.ImeI });
                pomocnici.Items.Add(item);
            }

            pomocnici.Refresh();
        }

        private void DodajPomocnika_Load(object sender, EventArgs e)
        {
            popuniPodacima();
            List<IgracPregled> t = DTOManager.vratiIgrace();
            foreach (IgracPregled t1 in t)
            {
                comboBox1.ValueMember= t1.ID;
                comboBox1.Items.Add(t1.Ime + " " + t1.Prezime);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PomocnikBasic o = new PomocnikBasic();
            o.Ime = textBox1.Text;
            o.Rasa = textBox2.Text;
            o.Klasa = textBox3.Text;
            o.BonusUZastiti = (int)numericUpDown1.Value;
            //o.Tim = DTOManager.vratiTim(comboTimovi.Text);
            DTOManager.sacuvajPomocnika(o, comboBox1.ValueMember);
            MessageBox.Show("Uspesno ste dodali novog pomocnika!");
            this.Close();
        }
    }
}
