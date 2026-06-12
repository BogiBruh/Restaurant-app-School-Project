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
    public partial class connectJeloPrilog : Form
    {
        databaza baza;
        List<jelo> listaJela;
        List<prilog> listaPriloga;
        int filterJelo;
        int filterPrilog;

        public connectJeloPrilog()
        {
            InitializeComponent();
        }
        public connectJeloPrilog(databaza _baza)
        {
            InitializeComponent();
            baza = _baza;
            listaJela = new List<jelo>();
            listaPriloga = new List<prilog>();
        }

        private void connectJeloPrilog_Load(object sender, EventArgs e)
        {
            filterJelo = 0;
            filterPrilog = 0;
            listaJela = databaza.loadIntoJeloList(baza);

            if(listaJela.Count == 0)
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
            listaPriloga = loadNeiskorisceniPrilozi(baza, izabranoJelo.IdJela);

            if(listaPriloga.Count == 0)
            {
                MessageBox.Show("Morate imati makar jedan prilog da biste ga povezali sa jelom!");
                this.Close();
            }

            comboPrilog.DataSource = listaPriloga;
            comboPrilog.DisplayMember = "NazivPriloga";
            comboPrilog.ValueMember = "IdPriloga";
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
                        cmd.CommandText = "select * from jelo where naziv like ?";
                        cmd.Parameters.AddWithValue("@filtertekst", "%" + tboxFilterJela.Text + "%");
                        valid = true;
                        break;
                    case 1:
                        int filterCeneVise;
                        if (int.TryParse(tboxFilterJela.Text, out filterCeneVise))
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
                        if (int.TryParse(tboxFilterJela.Text, out filterCeneManje))
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in connectJeloPrilog btnFilterJelo_Click");
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

                switch (filterPrilog)
                {
                    case 0:
                        cmd.CommandText = "select * from prilog where naziv like ?";
                        cmd.Parameters.AddWithValue("@filtertekst", "%" + tboxFilterPrilog.Text + "%");
                        valid = true;
                        break;
                    case 1:
                        int filterCeneVise;
                        if (int.TryParse(tboxFilterPrilog.Text, out filterCeneVise))
                        {
                            cmd.CommandText = "select * from prilog where cena >= ?";
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
                        if (int.TryParse(tboxFilterPrilog.Text, out filterCeneManje))
                        {
                            cmd.CommandText = "select * from prilog where cena <= ?";
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
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in connectJeloPrilog btnFilterPrilog_Click");
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

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private List<prilog> loadNeiskorisceniPrilozi(databaza baza, int idJelaZaProveru)
        {
            List<prilog> returnList = new List<prilog>();

            try
            {
                baza.openConnection();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "select * " +
                    "from prilog " +
                    "where id_prilog not in " +
                    "(select id_prilog " +
                    "from pripadnost " +
                    "where id_jelo = @idJela)";

                cmd.Parameters.AddWithValue("@idJela", idJelaZaProveru);

                OleDbDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    prilog prilogZaDodati = new prilog();

                    prilogZaDodati.IdPriloga = int.Parse(rd["id_prilog"].ToString());
                    prilogZaDodati.NazivPriloga = rd["naziv"].ToString();
                    prilogZaDodati.CenaPriloga = int.Parse(rd["cena"].ToString());

                    returnList.Add(prilogZaDodati);
                }

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
    }
}
