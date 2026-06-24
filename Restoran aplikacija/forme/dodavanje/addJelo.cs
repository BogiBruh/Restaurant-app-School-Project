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

namespace Restoran_aplikacija.forme
{
    public partial class addJelo : Form
    {
        databaza baza;
        public addJelo()
        {
            InitializeComponent();
        }

        public addJelo(databaza _baza)
        {
            InitializeComponent();
            baza = _baza;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool valid = false;
            try
            {
                string nazivJela;
                int cenaJela;
                OleDbCommand cmd = new OleDbCommand();
                

                baza.openConnection();
                cmd.Connection = baza.Conn;

                if (tboxNaziv.Text.Length > 0)
                {                    
                    if(tboxNaziv.Text.Length < 255)
                    {
                        nazivJela = tboxNaziv.Text;
                        if (int.TryParse(tboxCena.Text, out cenaJela))
                        {
                            cmd.CommandText = "insert into jelo(naziv, cena) values(@naziv, @cena)";
                            cmd.Parameters.AddWithValue("naziv", nazivJela);
                            cmd.Parameters.AddWithValue("cena", cenaJela);
                            cmd.ExecuteNonQuery();
                            valid = true;
                        }
                        else
                        {
                            MessageBox.Show("Morate uneti broj za cenu!");
                        }
                    }
                    else MessageBox.Show("Nema sanse da se stvarno tako zove jelo.(mora manje od 255 karaktera)");
                }
                else
                {
                    MessageBox.Show("Norate uneti naziv jela!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "In addJelo_Load");
            }
            finally
            {
                baza.closeConnection();
            }

            if (valid) this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
