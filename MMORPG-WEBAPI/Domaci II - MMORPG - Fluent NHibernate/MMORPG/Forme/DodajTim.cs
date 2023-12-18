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
    public partial class DodajTim : Form
    {
        public DodajTim()
        {
            InitializeComponent();
        }
        public void popuniPodacima()
        {
            timovi.Items.Clear();
            List<TimPregled> pomLista = DTOManager.vratiTimove();
            foreach (TimPregled i in pomLista)
            {
                ListViewItem item = new ListViewItem(new string[] { i.Naziv,i.Plasman.ToString(), i.Min.ToString(), i.Max.ToString(), i.BonusPoeni.ToString() });
                timovi.Items.Add(item);
            }

            timovi.Refresh();
        }
        private void DodajTim_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimBasic o = new TimBasic();
            o.Naziv = textBox1.Text;
            o.Plasman = Convert.ToInt32(textBox5.Text);
            o.Min = Convert.ToInt32(textBox2.Text);
            o.Max = Convert.ToInt32(textBox3.Text);
            o.BonusPoeni = Convert.ToInt32(textBox4.Text);
            //o.Tim = DTOManager.vratiTim(comboTimovi.Text);
            DTOManager.sacuvajTim(o);
            MessageBox.Show("Uspesno ste dodali novi tim!");
            this.Close();
        }
    }
}
