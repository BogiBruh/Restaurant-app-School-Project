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

namespace Restoran_aplikacija.forme.editovanje
{
    public partial class disconnectJeloPrilog : Form
    {
        databaza baza;
        List<jelo> listaJela;
        List<prilog> listaPriloga;
        int filterJelo;
        int filterPrilog;
        int obrisanoJeloId = 0;
        int obrisanPrilogId = 0;

        public disconnectJeloPrilog()
        {
            InitializeComponent();
        }

        public disconnectJeloPrilog(databaza _baza)
        {
            InitializeComponent();
            baza = _baza;
            listaJela = new List<jelo>();
            listaPriloga = new List<prilog>();
        }

        private void disconnectJeloPrilog_Load(object sender, EventArgs e)
        {
            filterJelo = 0;
            filterPrilog = 0;
            /* Ovo mora pre loadIntoJeloList, jer inace comboJelo_SelectedIndexChanged moze da odreaguje pre nalazenja 
             * obrisanoJeloId i obrisanPrilogId, i onda se prikazuje i obrisan item
             */
            nadjiObrisanoJeloId(); 
            nadjiObrisanPrilogId();
            listaJela = databaza.loadIntoJeloList(baza);

            if (listaJela.Count == 0)
            {
                MessageBox.Show("Morate imati makar jedno jelo da biste mogli da ga povezete sa prilogom!");
                this.Close();
            }

            comboJelo.DataSource = listaJela;
            comboJelo.ValueMember = "IdJela";
            comboJelo.DisplayMember = "Naziv";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboJelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            jelo izabranoJelo = comboJelo.SelectedItem as jelo;
            if (izabranoJelo == null) return;
            listaPriloga = loadIskorisceniPrilozi(baza, izabranoJelo.IdJela);

            if (listaPriloga.Count == 0)
            {
                MessageBox.Show("Morate imati makar jedan prilog da biste ga povezali sa jelom!");
                this.Close();
            }

            comboPrilog.DataSource = listaPriloga;
            comboPrilog.DisplayMember = "NazivPriloga";
            comboPrilog.ValueMember = "IdPriloga";
        }

        private void btnFilterJelo_Click(object sender, EventArgs e)
        {
            if (tboxFilterJela.Text.Length == 0)
            {
                MessageBox.Show("Morate uneti neki parametar za filtriranje!");
                return;
            }

            bool valid = false;
            List<jelo> filterListaJela = new List<jelo>();

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                baza.openConnection();
                cmd.Connection = baza.Conn;

                switch (filterJelo)
                {
                    case 0:
                        cmd.CommandText = "select * from jelo where naziv like ? and id_jelo <> @idPlaceholder";
                        cmd.Parameters.AddWithValue("@filtertekst", "%" + tboxFilterJela.Text + "%");
                        cmd.Parameters.AddWithValue("@idPlaceholder", obrisanoJeloId);
                        valid = true;
                        break;
                    case 1:
                        int filterCeneVise;
                        if (int.TryParse(tboxFilterJela.Text, out filterCeneVise))
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
                        if (int.TryParse(tboxFilterJela.Text, out filterCeneManje))
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in disconnectJeloPrilog btnFilterJelo_Click");
            }
            finally
            {
                baza.closeConnection();
            }

            if (valid)
            {
                comboJelo.DataSource = filterListaJela;
                comboJelo.DisplayMember = "Naziv";
                comboJelo.ValueMember = "IdJela";
            }
        }

        private void btnFilterPrilog_Click(object sender, EventArgs e)
        {
            if (tboxFilterPrilog.Text.Length == 0)
            {
                MessageBox.Show("Morate uneti neki parametar za filtriranje!");
                return;
            }

            bool valid = false;
            List<prilog> filterListaPriloga = new List<prilog>();

            try
            {
                OleDbCommand cmd = new OleDbCommand();
                baza.openConnection();
                cmd.Connection = baza.Conn;
                jelo selektovanoJelo = comboJelo.SelectedItem as jelo;
                if (selektovanoJelo == null)
                {
                    MessageBox.Show("Jelo mora biti selektovano da biste primenili filter na priloge!");
                    return;
                }

                switch (filterPrilog)
                {
                    case 0:
                        cmd.CommandText = "select * " +
                            "from prilog " +
                            "where naziv like @filtertekst " +
                            "and id_prilog <> @idPlaceholder " +
                            "and id_prilog in (select id_prilog from pripadnost " +
                            "where id_jelo = @idJela)";
                        cmd.Parameters.AddWithValue("@filtertekst", "%" + tboxFilterPrilog.Text + "%");
                        cmd.Parameters.AddWithValue("@idPlaceholder", obrisanPrilogId);
                        cmd.Parameters.AddWithValue("@idJela", selektovanoJelo.IdJela);
                        valid = true;
                        break;
                    case 1:
                        int filterCeneVise;
                        if (int.TryParse(tboxFilterPrilog.Text, out filterCeneVise))
                        {
                            cmd.CommandText = "select * " +
                                "from prilog " +
                                "where cena >= @filterCena " +
                                "and id_prilog <> @idPlaceholder " +
                                "and id_prilog in(select id_prilog from pripadnost " +
                                "where id_jelo = @idJela)";
                            cmd.Parameters.AddWithValue("@filterCena", filterCeneVise);
                            cmd.Parameters.AddWithValue("@idPlaceholder", obrisanPrilogId);
                            cmd.Parameters.AddWithValue("@idJela", selektovanoJelo.IdJela);
                            valid = true;
                        }
                        else
                        {
                            MessageBox.Show("Morate uneti validan broj za filter cene!");
                        }
                        break;
                    case 2:
                        int filterCeneManje;
                        if (int.TryParse(tboxFilterPrilog.Text, out filterCeneManje))
                        {
                            cmd.CommandText = "select * " +
                                "from prilog " +
                                "where cena <= @filterCena " +
                                "and id_prilog <> @idPlaceholder " +
                                "and id_prilog in(select id_prilog from pripadnost " +
                                "where id_jelo = @idJela)";
                            cmd.Parameters.AddWithValue("@filterCena", filterCeneManje);
                            cmd.Parameters.AddWithValue("@idPlaceholder", obrisanPrilogId);
                            cmd.Parameters.AddWithValue("@idJela", selektovanoJelo.IdJela);
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
                    rd.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in disconnectJeloPrilog btnFilterPrilog_Click");
            }
            finally
            {
                baza.closeConnection();
            }

            if (valid)
            {
                comboPrilog.DataSource = filterListaPriloga;
                comboPrilog.DisplayMember = "NazivPriloga";
                comboPrilog.ValueMember = "IdPriloga";
            }
        }

        private void comboFilterJelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboFilterJelo.SelectedIndex)
            {
                case 0: // nazivi
                    filterJelo = 0;
                    break;
                case 1: // cena vise od
                    filterJelo = 1;
                    break;
                case 2: // cena manje od
                    filterJelo = 2;
                    break;
                default: break;
            }
        }

        private void comboFilterPrilog_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboFilterPrilog.SelectedIndex)
            {
                case 0: // nazivi
                    filterPrilog = 0;
                    break;
                case 1: // cena vise od
                    filterPrilog = 1;
                    break;
                case 2: // cena manje od
                    filterPrilog = 2;
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
            if (comboJelo.SelectedItem == null) return;
            if (comboPrilog.SelectedItem == null) return;

            jelo selektovanoJelo = comboJelo.SelectedItem as jelo;
            prilog selektovanPrilog = comboPrilog.SelectedItem as prilog;
            bool valid = false;

            try
            {
                baza.openConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;

                cmd.CommandText = "delete from pripadnost where id_jelo = @idJela and id_prilog = @idPriloga";
                cmd.Parameters.AddWithValue("@idJela", selektovanoJelo.IdJela);
                cmd.Parameters.AddWithValue("@idPriloga", selektovanPrilog.IdPriloga);
                cmd.ExecuteNonQuery();
                valid = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in disconnectJeloPrilog btnOk_Click");
            }
            finally
            {
                baza.closeConnection();
            }

            if (valid) this.Close();
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
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in loadIskorisceniPrilozi");
                return returnList;
            }
            finally
            {
                baza.closeConnection();
            }
        }
    }
}
