using Restoran_aplikacija.klase;
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
    public partial class deletePrilog : Form
    {
        databaza baza;
        List<prilog> listaPriloga;
        int filter = 0;
        int obrisanPrilogId = 0;

        public deletePrilog()
        {
            InitializeComponent();
        }

        public deletePrilog(List<prilog> _listaPriloga, databaza _baza)
        {
            InitializeComponent();
            baza = _baza;
            listaPriloga = _listaPriloga;
        }

        private void deletePrilog_Load(object sender, EventArgs e)
        {
            comboFilter.SelectedIndex = 0;
            comboPrilog.DataSource = listaPriloga;
            comboPrilog.DisplayMember = "NazivPriloga";
            comboPrilog.ValueMember = "IdPriloga";

            if (listaPriloga.Count == 0)
            {
                MessageBox.Show("Morate imati makar neki prilog da biste ga izbrisali!");
                this.Close();
            }

            nadjiObrisanPrilogId();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
                List<prilog> filterListaPriloga = new List<prilog>();

                switch (filter)
                {
                    case 0:
                        cmd.CommandText = "select * from prilog where naziv like ? and id_prilog <> @idPlaceholder";
                        cmd.Parameters.AddWithValue("@filtertekst", "%" + tboxFilter.Text + "%");
                        cmd.Parameters.AddWithValue("@idPlaceholder", obrisanPrilogId);
                        valid = true;
                        break;
                    case 1:
                        int filterCeneVise;
                        if (int.TryParse(tboxFilter.Text, out filterCeneVise))
                        {
                            cmd.CommandText = "select * from prilog where cena >= ? and id_prilog <> @idPlaceholder";
                            cmd.Parameters.AddWithValue("@filterCena", filterCeneVise);
                            cmd.Parameters.AddWithValue("@idPlaceholder", obrisanPrilogId);
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
                            cmd.CommandText = "select * from prilog where cena <= ? and id_prilog <> @idPlaceholder";
                            cmd.Parameters.AddWithValue("@filterCena", filterCeneManje);
                            cmd.Parameters.AddWithValue("@idPlaceholder", obrisanPrilogId);
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
                        prilog prilogZaDodati = new prilog();
                        prilogZaDodati.IdPriloga = int.Parse(rd["id_prilog"].ToString());
                        prilogZaDodati.CenaPriloga = int.Parse(rd["cena"].ToString());
                        prilogZaDodati.NazivPriloga = rd["naziv"].ToString();
                        filterListaPriloga.Add(prilogZaDodati);
                    }

                    comboPrilog.DataSource = filterListaPriloga;
                    comboPrilog.DisplayMember = "Naziv";
                    comboPrilog.ValueMember = "IdPriloga";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in editPrilog btnFilter_Click");
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool valid = false;

            try
            {
                baza.openConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                prilog prilogZaBrisanje = comboPrilog.SelectedItem as prilog;

                cmd.CommandText = "delete from jelo where id_jelo = @idJela";
                cmd.Parameters.AddWithValue("@idJela", prilogZaBrisanje.IdPriloga);
                cmd.ExecuteNonQuery();
                valid = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in deletePrilog btnOk_Click");
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

        private void nadjiObrisanPrilogId()
        {
            try
            {
                baza.openConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "select id_jelo from jelo where naziv = '[OBRISANO JELO]'";
                object rezultatPretrage = cmd.ExecuteScalar();
                if (rezultatPretrage != null) obrisanPrilogId = int.Parse(rezultatPretrage.ToString());
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
