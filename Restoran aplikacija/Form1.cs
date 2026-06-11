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
            
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            baza = new databaza(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\database\\Restoran.accdb");
            listaJela = new List<jelo>();
            listaJela = databaza.loadIntoJeloList(baza);
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
                cmd.Parameters.AddWithValue("cena", 300);
                int rows = cmd.ExecuteNonQuery();
                //MessageBox.Show("Rows inserted: " + rows); // debugovanje, nesto mi ne radi
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baza.closeConnection();
                listaJela.Clear();
                listaJela = databaza.loadIntoJeloList(baza);
            }
        }

        
    }
}
