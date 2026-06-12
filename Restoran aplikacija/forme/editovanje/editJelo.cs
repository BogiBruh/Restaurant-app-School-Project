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

namespace Restoran_aplikacija.forme.editovanje
{
    public partial class editJelo : Form
    {
        List<jelo> listaJela;
        databaza baza;
        int filter = 0;

        public editJelo()
        {
            InitializeComponent();
        }

        public editJelo(List<jelo> _listaJela, databaza _baza)
        {
            InitializeComponent();
            listaJela = _listaJela;
            baza = _baza;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editJelo_Load(object sender, EventArgs e)
        {
            comboJelo.Items.Clear();
            comboJelo.DataSource = listaJela;
            comboJelo.DisplayMember = "Naziv";
            comboJelo.ValueMember = "IdJela";
            comboFilter.SelectedIndex = 0;

            if(listaJela.Count == 0 )
            {
                MessageBox.Show("Morate imati jela da biste mogli da ih menjate!");
                this.Close();
            }
        }

        private void comboJelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            jelo selektovanoJelo = (jelo)comboJelo.SelectedItem;
            tboxNaziv.Text = selektovanoJelo.Naziv;
            tboxCena.Text = selektovanoJelo.Cena.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool valid = false;

            try
            {
                string noviNazivJela;
                int novaCenaJela;
                OleDbCommand cmd = new OleDbCommand();
                baza.openConnection();
                cmd.Connection = baza.Conn;

                if (tboxNaziv.Text.Length > 0)
                {
                    noviNazivJela = tboxNaziv.Text;
                    if (int.TryParse(tboxCena.Text, out novaCenaJela))
                    {
                        jelo izabranoJelo = comboJelo.SelectedItem as jelo;

                        cmd.CommandText = "update jelo " +
                            "set naziv = @nazivJela, cena = @cenaJela " +
                            "where id_jelo = @idJela";
                        cmd.Parameters.AddWithValue("@nazivJela", noviNazivJela);
                        cmd.Parameters.AddWithValue("@cenaJela", novaCenaJela);
                        cmd.Parameters.AddWithValue("@idJela", izabranoJelo.IdJela);

                        cmd.ExecuteNonQuery();
                        valid = true;
                    }
                    else
                    {
                        MessageBox.Show("Morate pravilno uneti novu cenu jela!");
                    }
                }
                else
                {
                    MessageBox.Show("Morate uneti novi naziv jela!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in editJelo.btnOk_Click");
            }
            finally
            {
                baza.closeConnection();

            }

            if (valid) this.Close();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (tboxFilter.Text.Length == 0)
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
                        cmd.CommandText = "select * from jelo where naziv like ?";
                        cmd.Parameters.AddWithValue("@filtertekst", "%" + tboxFilter.Text + "%");
                        valid = true;
                        break;
                    case 1:
                        int filterCeneVise;
                        if (int.TryParse(tboxFilter.Text, out filterCeneVise))
                        {
                            cmd.CommandText = "select * from jelo where cena >= ?";
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
                            cmd.CommandText = "select * from jelo where cena <= ?";
                            cmd.Parameters.AddWithValue("@filterCena", filterCeneManje);
                            valid = true;
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
                    rd.Close();

                    comboJelo.DataSource = filterListaJela;
                    comboJelo.DisplayMember = "Naziv";
                    comboJelo.ValueMember = "IdJela";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in editJelo btnFilter_Click");
            }
            finally
            {
                baza.closeConnection();
            }
        }

        private void comboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboFilter.SelectedIndex)
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
    }
}
