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
    public partial class addPrilog : Form
    {
        databaza baza;

        public addPrilog()
        {
            InitializeComponent();
        }

        public addPrilog(databaza _baza)
        {
            InitializeComponent();
            baza = _baza;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool valid = false;
            try
            {
                string nazivPriloga;
                int cenaPriloga;
                OleDbCommand cmd = new OleDbCommand();


                baza.openConnection();
                cmd.Connection = baza.Conn;

                if (tboxNaziv.Text.Length > 0)
                {
                    if(tboxNaziv.Text.Length < 255)
                    {
                        nazivPriloga = tboxNaziv.Text;
                        if (int.TryParse(tboxCena.Text, out cenaPriloga))
                        {
                            cmd.CommandText = "insert into prilog(naziv, cena) values(@naziv, @cena)";
                            cmd.Parameters.AddWithValue("naziv", nazivPriloga);
                            cmd.Parameters.AddWithValue("cena", cenaPriloga);
                            cmd.ExecuteNonQuery();
                            valid = true;
                        }
                        else
                        {
                            MessageBox.Show("Morate uneti broj za cenu!");
                        }
                    }
                    else MessageBox.Show("Nema sanse da se tako zove prilog.(mora manje od 255 karaktera)");
                }
                else
                {
                    MessageBox.Show("Norate uneti naziv priloga!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "In addPrilog_Load");
            }
            finally
            {
                baza.closeConnection();
            }

            if (valid) this.Close();
        }
    }
}
