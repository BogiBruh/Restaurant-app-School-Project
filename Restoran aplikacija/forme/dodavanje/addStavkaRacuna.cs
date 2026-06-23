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

namespace Restoran_aplikacija.forme.dodavanje
{
    public partial class addStavkaRacuna : Form
    {
        databaza baza;
        int idRacuna;
        FlowLayoutPanel flowStavke;
        int filter = 0;
        private int obrisanoJeloId = 0;
        private int obrisanPrilogId = 0;
        List<jelo> listaJela;
        List<prilog> listaPriloga;
        jelo odabranoJelo;
        prilog odabranPrilog;

        public addStavkaRacuna()
        {
            InitializeComponent();
        }

        public addStavkaRacuna(databaza _baza, FlowLayoutPanel _flowStavke, int _idRacuna)
        {
            InitializeComponent();
            baza = _baza;
            flowStavke = _flowStavke;
            idRacuna = _idRacuna;
        }

        private void addStavkaRacuna_Load(object sender, EventArgs e)
        {
            listaJela = new List<jelo>();
            listaPriloga = new List<prilog>();
            listaJela = databaza.loadIntoJeloList(baza);
            comboJelo.DataSource = listaJela;
            comboJelo.DisplayMember = "Naziv";
            comboJelo.ValueMember = "IdJela";
            if (listaJela.Count == 0)
            {
                MessageBox.Show("Morate imati jela da biste mogli da ih menjate!");
                this.Close();
            }

            nadjiObrisanPrilogId();
            nadjiObrisanoJeloId();
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
                        if (int.TryParse(tboxFilter.Text, out filterCeneVise))
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
                    rd.Close();

                    comboJelo.DataSource = filterListaJela;
                    comboJelo.DisplayMember = "Naziv";
                    comboJelo.ValueMember = "IdJela";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in addStavkaRacuna btnFilter_Click");
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

        private void nadjiObrisanPrilogId()
        {
            try
            {
                baza.openConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "select id_prilog from prilog where naziv = '[OBRISAN PRILOG]'";
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (comboJelo.SelectedItem != null)
            {
                odabranoJelo = comboJelo.SelectedItem as jelo;
                label4.Text = "Izaberite prilog";
                comboJelo.SelectedIndex = 0;
                tboxFilter.Text = null;
                btnOk.Text = "Dodajte stavku";
                btnOk.Click -= btnOk_Click;
                btnOk.Click += odaberiPrilog;      

                if (odabranoJelo == null) return;
                listaPriloga = loadIskorisceniPrilozi(baza, odabranoJelo.IdJela);

                if (listaPriloga.Count == 0)
                {
                    MessageBox.Show("Morate imati makar jedan prilog da biste ga povezali sa jelom!");
                    this.Close();
                }

                comboJelo.DataSource = listaPriloga;
                comboJelo.DisplayMember = "NazivPriloga";
                comboJelo.ValueMember = "IdPriloga";
                MessageBox.Show("Izabrano jelo: " + odabranoJelo.Naziv);
            }
            else return;
        }

        private List<prilog> loadIskorisceniPrilozi(databaza baza, int idJelaZaProveru)
        {
            List<prilog> returnList = new List<prilog>();

            try
            {
                baza.openConnection();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "select * " +
                    "from prilog " +
                    "where id_prilog in " +
                    "(select id_prilog " +
                    "from pripadnost " +
                    "where id_jelo = @idJela) " +
                    "and id_prilog <> @idPlaceholder";

                cmd.Parameters.AddWithValue("@idJela", idJelaZaProveru);
                cmd.Parameters.AddWithValue("@idPlaceholder", obrisanPrilogId);

                OleDbDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    prilog prilogZaDodati = new prilog();

                    prilogZaDodati.IdPriloga = int.Parse(rd["id_prilog"].ToString());
                    prilogZaDodati.NazivPriloga = rd["naziv"].ToString();
                    prilogZaDodati.CenaPriloga = int.Parse(rd["cena"].ToString());

                    returnList.Add(prilogZaDodati);
                }
                rd.Close();

                return returnList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in loadNeiskorisceniPrilozi");
                return returnList;
            }
            finally
            {
                baza.closeConnection();
            }
        }

        private void odaberiPrilog(object sender, EventArgs e)
        {
            if (comboJelo.SelectedItem != null)
            {
                odabranPrilog = comboJelo.SelectedItem as prilog;
                try
                {
                    baza.openConnection();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baza.Conn;

                    cmd.CommandText = "insert into stavka_racuna(id_racun, id_jelo, id_prilog, cenaJelo, cenaPrilog) " +
                        "values(@idRacuna, @idJela, @idPriloga, @cenaJela, @cenaPriloga)";
                    cmd.Parameters.AddWithValue("@idRacuna", idRacuna);
                    cmd.Parameters.AddWithValue("@idJela", odabranoJelo.IdJela);
                    cmd.Parameters.AddWithValue("@idPriloga", odabranPrilog.IdPriloga);
                    cmd.Parameters.AddWithValue("@cenaJela", odabranoJelo.Cena);
                    cmd.Parameters.AddWithValue("@cenaPriloga", odabranPrilog.CenaPriloga);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();

                    cmd.CommandText = "select @@identity";
                    int idStavke = int.Parse(cmd.ExecuteScalar().ToString());

                    panelStavkaRacuna panelStavka = new panelStavkaRacuna(baza);
                    panelStavka.podesiJelo(odabranoJelo.Naziv, odabranoJelo.Cena);
                    panelStavka.podesiPrilog(odabranPrilog.NazivPriloga, odabranPrilog.CenaPriloga);
                    panelStavka.dodajIdStavke(idStavke);
                    panelStavka.BorderStyle = BorderStyle.FixedSingle;
                    flowStavke.Controls.Add(panelStavka);

                    cmd.CommandText = "update racun " +
                        "set ukupna_cena = ukupna_cena + @cenaStavke " +
                        "where id_racun = @idRacuna";
                    cmd.Parameters.AddWithValue("@cenaStavke", odabranoJelo.Cena + odabranPrilog.CenaPriloga);
                    cmd.Parameters.AddWithValue("@idRacuna", idRacuna);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Uspesno dodato jelo!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + Environment.NewLine + "Error in addStavkaRacuna odaberiPrilog");
                }
                finally
                {
                    baza.closeConnection();
                }
            }
            else return;
        }

       /* public int vratiCenu()
        {
            int cenaStavke
        }*/
    }
}
