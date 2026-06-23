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
        int obrisanoJeloId = 0;
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

            nadjiObrisanoJeloId();
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
                        cmd.CommandText = "select * from jelo where naziv like ? and id_jelo <> @idPlaceholder";
                        cmd.Parameters.AddWithValue("@filtertekst", "%" + tboxFilter.Text + "%");
                        cmd.Parameters.AddWithValue("@idPlaceholder", obrisanoJeloId);
                        valid = true;
                        break;
                    case 1:
                        int filterCeneVise;
                        if(int.TryParse(tboxFilter.Text, out filterCeneVise))
                        {
                            cmd.CommandText = "select * from jelo where cena >= ? and id_jelo <> @idPlaceholder";
                            cmd.Parameters.AddWithValue("@filterCena", filterCeneVise);
                            cmd.Parameters.AddWithValue("@idPlaceholder", obrisanoJeloId);
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
                            cmd.CommandText = "select * from jelo where cena <= ? and id_jelo <> @idPlaceholder";
                            cmd.Parameters.AddWithValue("@filterCena", filterCeneManje);
                            cmd.Parameters.AddWithValue("@idPlaceholder", obrisanoJeloId);
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool valid = false;

            try
            {
                baza.openConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                jelo jeloZaBrisanje = comboJelo.SelectedItem as jelo;

                DialogResult dijalog = MessageBox.Show(
                     $"Da li ste sigurni da zelite da obrisete {jeloZaBrisanje.Naziv}?", "Potvrda Brisanja Jela", MessageBoxButtons.YesNo);

                if (dijalog == DialogResult.Yes)
                {
                    cmd.CommandText = "delete from pripadnost where id_jelo = @idJela";
                    cmd.Parameters.AddWithValue("@idJela", jeloZaBrisanje.IdJela);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.CommandText = "update stavka_racuna " +
                        "set id_jelo = @idObrisanog " +
                        "where id_jelo = @idSelektovanog";
                    cmd.Parameters.AddWithValue("@idObrisanog", obrisanoJeloId);
                    cmd.Parameters.AddWithValue("@idSelektovanog", jeloZaBrisanje.IdJela);
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.CommandText = "delete from jelo where id_jelo = @idJela";
                    cmd.Parameters.AddWithValue("@idJela", jeloZaBrisanje.IdJela);
                    cmd.ExecuteNonQuery();
                    valid = true;
                    MessageBox.Show("Uspesno obrisano jelo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in deleteJelo btnOk_Click");
            }
            finally
            {
                baza.closeConnection();
            }

            if (valid)
            {
                this.Close();
            }
        }

        private void nadjiObrisanoJeloId()
        {
            try
            {
                baza.openConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "select id_jelo from jelo where naziv = '[OBRISANO JELO]'";
                object rezultatPretrage = cmd.ExecuteScalar();
                if (rezultatPretrage != null) obrisanoJeloId = int.Parse(rezultatPretrage.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baza.closeConnection();
            }
        }
    }
}
