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

namespace Restoran_aplikacija.forme.brisanje
{
    public partial class deleteJelo : Form
    {
        databaza baza;
        List<jelo> listaJela;
        int filter = 0;
        public deleteJelo()
        {
            InitializeComponent();
        }

        public deleteJelo(List<jelo> _listaJela, databaza _baza)
        {
            InitializeComponent();
            listaJela = _listaJela;
            baza = _baza;  
        }

        private void deleteJelo_Load(object sender, EventArgs e)
        {
            comboFilter.SelectedIndex = 0;
            comboJelo.Items.Clear();
            comboJelo.DataSource = listaJela;
            comboJelo.DisplayMember = "Naziv";
            comboJelo.ValueMember = "IdJela";

            if (listaJela.Count == 0)
            {
                MessageBox.Show("Morate imati makar jedno jelo da biste brisali jela!");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboFilter.SelectedIndex)
            {
                case 0: // nazivi
                    filter = 0;
                    break;
                case 1: // cena vise od
                    filter = 1;
                    break;
                case 2: // cena manje od
                    filter = 2;
                    break;
                default: break;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if(tboxFilter.Text.Length == 0)
            {
                MessageBox.Show("Morate uneti neki parametar za filtriranje!");
                return;
            }

            bool valid = false;

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                baza.openConnection();
                cmd.Connection = baza.Conn;
                List<jelo> filterListaJela = new List<jelo>();

                switch (filter)
                {
                    case 0:
                        cmd.CommandText = "select * from jelo where naziv like @filtertekst";
                        cmd.Parameters.AddWithValue("@filtertekst", "*" + tboxFilter.Text + "*");
                        valid = true;
                        break;
                    case 1:
                        int filterCeneVise;
                        if(int.TryParse(tboxFilter.Text, out filterCeneVise))
                        {
                            cmd.CommandText = "select * from jelo where cena >= @filterCena";
                            cmd.Parameters.AddWithValue("@filterCena", filterCeneVise);
                            valid = true;
                        }
                        else
                        {
                            MessageBox.Show("Morate uneti validan broj za filter cene!");
                        }
                        break;
                    case 2:
                        int filterCeneManje;
                        if (int.TryParse(tboxFilter.Text, out filterCeneManje))
                        {
                            cmd.CommandText = "select * from jelo where cena <= @filterCena";
                            cmd.Parameters.AddWithValue("@filterCena", filterCeneManje);
                            valid= true;
                        }
                        else
                        {
                            MessageBox.Show("Morate uneti validan broj za filter cene!");
                        }
                        break;
                    default: break;
                }

                if (valid)
                {
                    OleDbDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        jelo jeloZaDodati = new jelo();
                        jeloZaDodati.IdJela = int.Parse(rd["id_jelo"].ToString());
                        jeloZaDodati.Cena = int.Parse(rd["cena"].ToString());
                        jeloZaDodati.Naziv = rd["naziv"].ToString();
                        filterListaJela.Add(jeloZaDodati);
                    }

                    comboJelo.DataSource = filterListaJela;
                    comboJelo.DisplayMember = "Naziv";
                    comboJelo.ValueMember = "IdJela";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in deleteJelo btnFilter_Click");
            }
            finally
            {
                baza.closeConnection();
            }
        }
    }
}
