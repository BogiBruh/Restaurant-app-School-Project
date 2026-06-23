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

namespace Restoran_aplikacija.forme.izvestaji
{
    public partial class izvestajRacuna : Form
    {
        databaza baza;
        public izvestajRacuna()
        {
            InitializeComponent();
        }

        public izvestajRacuna(databaza _baza)
        {
            InitializeComponent();
            baza = _baza;
        }

        private void izvestajRacuna_Load(object sender, EventArgs e)
        {
            ucitajRacune();
            dpickerOd.Value = DateTime.Now.Date.AddDays(-1); // juce
            dgridRacun.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgridRacun.MultiSelect = false;
            dgridRacun.AllowUserToAddRows = false;
            dgridRacun.ReadOnly = true;
            dgridRacun.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ucitajRacune()
        {
            try
            {
                baza.openConnection();
                OleDbCommand cmd = new OleDbCommand();
                DataTable dt = new DataTable();
                cmd.Connection = baza.Conn;

                cmd.CommandText = "select r.id_racun as \"ID Racuna\", " +
                    "count(sr.id_racun) as \"Broj Stavki\", " +
                    "r.ukupna_cena as Cena, " +
                    "r.datum as Datum " +
                    "from racun r " +
                    "left join stavka_racuna sr on r.id_racun = sr.id_racun " +
                    "group by r.id_racun, r.ukupna_cena, r.datum " +
                    "having count(sr.id_racun) <> 0 " +
                    "order by r.datum desc, r.id_racun desc";
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dt);
                dgridRacun.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in izvestajRacuna ucitajRacune");
            }
            finally
            {
                baza.closeConnection();
            }
        }

        private void btnOtvoriRacun_Click(object sender, EventArgs e)
        {
            if (dgridRacun.CurrentRow == null) return;
            try
            {
                int idRacuna = int.Parse(dgridRacun.SelectedRows[0].Cells["\"ID Racuna\""].Value.ToString());
                baza.openConnection();
                OleDbCommand cmd = new OleDbCommand();
                DataTable dt = new DataTable();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "select jelo.naziv as nazivJela, sr.cenaJelo as cenaJela, " +
                    "prilog.naziv as nazivPriloga, sr.cenaPrilog as cenaPriloga, racun.datum as datum " +
                    "from ((stavka_racuna as sr " +
                    "left join jelo on sr.id_jelo = jelo.id_jelo) " +
                    "left join prilog on sr.id_prilog = prilog.id_prilog) " +
                    "left join racun on sr.id_racun = racun.id_racun " +
                    "where sr.id_racun = @idRacuna";
                cmd.Parameters.AddWithValue("@idRacuna", idRacuna);

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dt);

                string racunTekst = "FISKALNI RACUN\n" +
                    //$"DATUM: {}\n" +
                    $"BROJ RACUNA: {idRacuna}\n" +
                    "-------------------------------------\n" +
                    "-STAVKE------------------CENA--\n";
                foreach(DataRow dr in dt.Rows)
                {
                    racunTekst += $"{dr["nazivJela"].ToString(), -20}{dr["cenaJela"].ToString(), 5}din\n" +
                        $"{dr["nazivPriloga"].ToString(), -20}{dr["cenaPriloga"].ToString(), 5}din\n\n";
                }
                adapter.Dispose();
                racunTekst += "-------------------------------------\n";

                cmd.Parameters.Clear();
                cmd.CommandText = "select ukupna_cena from racun where id_racun = @idRacuna";
                cmd.Parameters.AddWithValue("@idRacuna", idRacuna);

                int cenaRacuna = int.Parse(cmd.ExecuteScalar().ToString());
                racunTekst += $"UKUPNA CENA              {cenaRacuna}din";

                MessageBox.Show(racunTekst);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in izvestajRacuna btnOtvoriRacun_Click");
            }
            finally
            {
                baza.closeConnection();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime datumOd = dpickerOd.Value;
            DateTime datumDo = dpickerDo.Value;
            int uporedjivanje = DateTime.Compare(datumOd, datumDo);
            if(uporedjivanje > 0)
            {
                MessageBox.Show("Molim vas, izaberite datume da imaju smisla.");
                return;
            }

            try
            {
                baza.openConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                DataTable dt = new DataTable();

                cmd.CommandText = "select r.id_racun as \"ID Racuna\", " +
                   "count(sr.id_racun) as \"Broj Stavki\", " +
                   "r.ukupna_cena as Cena, " +
                   "r.datum as Datum " +
                   "from racun r " +
                   "left join stavka_racuna sr on r.id_racun = sr.id_racun " +
                   "where r.datum >= @datumOd and r.datum <= @datumDo " +
                   "group by r.id_racun, r.ukupna_cena, r.datum " +
                   "having count(sr.id_racun) <> 0 " +
                   "order by r.datum desc, r.id_racun desc";
                cmd.Parameters.AddWithValue("@datumOd", datumOd.Date);
                cmd.Parameters.AddWithValue("@datumDo", datumDo.Date);

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dt);
                dgridRacun.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in izvestajRacuna btnFilter_Click");
            }
            finally
            {
                baza.closeConnection();
            }
        }
    }
}
