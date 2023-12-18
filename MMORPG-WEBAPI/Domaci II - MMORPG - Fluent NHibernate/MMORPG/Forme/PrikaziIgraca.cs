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
    public partial class PrikaziIgraca : Form
    {
        public PrikaziIgraca()
        {
            InitializeComponent();
        }
        public void popuniPodacima()
        {
            igraci.Items.Clear();
            List<IgracPregled> igraciLista = DTOManager.vratiIgrace();
            foreach(IgracPregled i in igraciLista)
            {
                ListViewItem item = new ListViewItem(new string[] {i.Ime, i.Prezime, i.Nadimak, i.Uzrast.ToString(),i.ID});
                igraci.Items.Add(item);
            }

            igraci.Refresh();
        }

        private void PrikaziIgraca_Load(object sender, EventArgs e)
        {
            this.Text = "IGRACI";
            popuniPodacima();
            List<TimPregled> t = DTOManager.vratiTimove();
            foreach(TimPregled t1 in t)
            {
                comboTimovi.Items.Add(t1.Naziv);
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IgracBasic o = new IgracBasic();
            o.Ime = textBox1.Text;
            o.Prezime = textBox2.Text;
            o.Nadimak = textBox3.Text;
            o.Uzrast = (int)uzrastNum.Value;
            o.Lozinka = textBox4.Text;
            if (radioMuski.Checked == true)
                o.Pol = 'M';
            else
                o.Pol = 'Z';
            //o.Tim = DTOManager.vratiTim(comboTimovi.Text);
            DTOManager.sacuvajIgraca(o, comboTimovi.Text);
            MessageBox.Show("Uspesno ste dodali novog igraca!");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (igraci.SelectedItems.Count == 0)
            {
                MessageBox.Show("Izaberite igraca kog zelite da obrisete!");
                return;
            }

            int idOdeljenja = Int32.Parse(igraci.SelectedItems[0].SubItems[4].Text);
            string poruka = "Da li zelite da obrisete izabrang igraca?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                DTOManager.obrisiIgraca(idOdeljenja);
                MessageBox.Show("Brisanje igraca je uspesno obavljeno!");
                this.popuniPodacima();
            }
            else
            {

            }
        }
    }
}
