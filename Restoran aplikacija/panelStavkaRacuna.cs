using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restoran_aplikacija
{
    public partial class panelStavkaRacuna : UserControl
    {
        databaza baza;
        public panelStavkaRacuna()
        {
            InitializeComponent();
        }

        public panelStavkaRacuna(databaza _baza)
        {
            InitializeComponent();
            baza = _baza;
        }

        private void panelStavkaRacuna_Load(object sender, EventArgs e)
        {

        }

        public void podesiJelo(string nazivJela, int cenaJela)
        {
            lblNazivJela.Text = nazivJela;
            lblCenaJela.Text = cenaJela.ToString() + " din";
        }

        public void podesiPrilog(string nazivPriloga, int cenaPriloga)
        {
            lblNazivPriloga.Text = nazivPriloga;
            lblCenaPriloga.Text = cenaPriloga.ToString() + " din";
        }

        public void nemaPriloga()
        {
            lblNazivPriloga.Visible = false;
            lblCenaPriloga.Visible = false;
        }

        public void dodajIdStavke(int idStavke)
        {
            btnDeleteStavka.Tag = idStavke;
        }

        private void btnDeleteStavka_Click(object sender, EventArgs e)
        {
            databaza.deleteStavkaRacuna(baza, (int)btnDeleteStavka.Tag);

            this.Parent.Controls.Remove(this);
            this.Dispose();
        }
    }
}
