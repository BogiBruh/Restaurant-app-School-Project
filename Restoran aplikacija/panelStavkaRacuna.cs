using Restoran_aplikacija.forme.dodavanje;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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
            btnIzmeni.Tag = idStavke;
        }

        private void btnDeleteStavka_Click(object sender, EventArgs e)
        {
            databaza.deleteStavkaRacuna(baza, (int)btnDeleteStavka.Tag);

            this.Parent.Controls.Remove(this);
            this.Dispose();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            addStavkaRacuna editStavka = new addStavkaRacuna(baza, this, int.Parse(btnIzmeni.Tag.ToString()));
            editStavka.ShowDialog();

            try
            {
                baza.openConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;

                cmd.CommandText = "select id_racun from stavka_racuna where id_stavke = @idStavke";
                cmd.Parameters.AddWithValue("@idStavke", int.Parse(btnIzmeni.Tag.ToString()));

                int idRacuna = int.Parse(cmd.ExecuteScalar().ToString());
                cmd.Parameters.Clear();

                cmd.CommandText = "select sum(cenaJelo + cenaPrilog) from stavka_racuna where id_racun = @idRacuna";
                cmd.Parameters.AddWithValue("@idRacuna", idRacuna);
                int ukupnacena = int.Parse(cmd.ExecuteScalar().ToString());

                cmd.Parameters.Clear();

                cmd.CommandText = "update racun " +
                    "set ukupna_cena = @ukupna " +
                    "where id_racun = @idRacuna";
                cmd.Parameters.AddWithValue("@ukupna", ukupnacena);
                cmd.Parameters.AddWithValue("@idRacuna", idRacuna);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in panelStavkaRacuna btnIzmeni_click");
            }
            finally
            {
                baza.closeConnection();
            }
        }
    }
}
