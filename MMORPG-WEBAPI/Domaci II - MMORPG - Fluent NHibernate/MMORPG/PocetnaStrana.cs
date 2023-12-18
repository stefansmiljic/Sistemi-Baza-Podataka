using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MMORPG.Forme;

namespace MMORPG
{
    public partial class PocetnaStrana : Form
    {
        public PocetnaStrana()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrikaziIgraca forma = new PrikaziIgraca();
            forma.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DodajPomocnika forma = new DodajPomocnika();
            forma.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KreirajProizvod forma = new KreirajProizvod();
            forma.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DodajTim forma = new DodajTim();
            forma.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DodajStazu forma = new DodajStazu();
            forma.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DodajPredmet forma = new DodajPredmet();
            forma.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DodajLika forma = new DodajLika();
            forma.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
