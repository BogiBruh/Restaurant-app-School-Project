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
    public partial class mainForm : Form
    {
        databaza baza;
        List<jelo> listaJela;
        public mainForm()
        {
            InitializeComponent();
            baza = new databaza(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\database\\Restoran.accdb");
            listaJela = new List<jelo>();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            loadIntoJeloList();
        }

        private void dodajJeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                baza.openConnection();
                OleDbCommand cmd = new OleDbCommand
                {
                    Connection = baza.Conn,
                    CommandText = "insert into jelo(naziv, cena) values(@naziv, @cena)",
                };

                cmd.Parameters.AddWithValue("naziv", "Ruska salata");
                cmd.Parameters.AddWithValue("cena", 299.99);
                int rows = cmd.ExecuteNonQuery();
                MessageBox.Show("Rows inserted: " + rows);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baza.closeConnection();
                loadIntoJeloList();
            }
        }

        private void loadIntoJeloList()
        {
            try
            {
                baza.openConnection();
                OleDbCommand cmd = new OleDbCommand
                {
                    Connection = baza.Conn,
                    CommandText = "select * from jelo"
                };
                OleDbDataReader rd = cmd.ExecuteReader();
                listaJela.Clear();
                while(rd.Read())
                {
                    jelo jeloZaDodati = new jelo();
                    jeloZaDodati.IdJela = int.Parse(rd["id_jelo"].ToString());
                    jeloZaDodati.Naziv = rd["naziv"].ToString();
                    jeloZaDodati.Cena = double.Parse(rd["cena"].ToString());

                    listaJela.Add(jeloZaDodati);
                }
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
