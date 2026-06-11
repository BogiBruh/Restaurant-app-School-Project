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
    public partial class editJelo : Form
    {
        List<jelo> listaJela;
        databaza baza;

        public editJelo()
        {
            InitializeComponent();
        }

        public editJelo(List<jelo> _listaJela, databaza _baza)
        {
            InitializeComponent();
            listaJela = _listaJela;
            baza = _baza;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editJelo_Load(object sender, EventArgs e)
        {
            comboJelo.Items.Clear();
            comboJelo.DataSource = listaJela;
            comboJelo.DisplayMember = "Naziv";
            comboJelo.ValueMember = "IdJela";

            if(listaJela.Count == 0 )
            {
                MessageBox.Show("Morate imati jela da biste mogli da ih menjate!");
                this.Close();
            }
        }

        private void comboJelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            jelo selektovanoJelo = (jelo)comboJelo.SelectedItem;
            tboxNaziv.Text = selektovanoJelo.Naziv;
            tboxCena.Text = selektovanoJelo.Cena.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool valid = false;

            try
            {
                string noviNazivJela;
                int novaCenaJela;
                OleDbCommand cmd = new OleDbCommand();
                baza.openConnection();
                cmd.Connection = baza.Conn;

                if (tboxNaziv.Text.Length > 0)
                {
                    noviNazivJela = tboxNaziv.Text;
                    if (int.TryParse(tboxCena.Text, out novaCenaJela))
                    {
                        jelo izabranoJelo = comboJelo.SelectedItem as jelo;

                        cmd.CommandText = "update jelo " +
                            "set naziv = @nazivJela, cena = @cenaJela " +
                            "where id_jelo = @idJela";
                        cmd.Parameters.AddWithValue("@nazivJela", noviNazivJela);
                        cmd.Parameters.AddWithValue("@cenaJela", novaCenaJela);
                        cmd.Parameters.AddWithValue("@idJela", izabranoJelo.IdJela);

                        cmd.ExecuteNonQuery();
                        valid = true;
                    }
                    else
                    {
                        MessageBox.Show("Morate pravilno uneti novu cenu jela!");
                    }
                }
                else
                {
                    MessageBox.Show("Morate uneti novi naziv jela!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in editJelo.btnOk_Click");
            }
            finally
            {
                baza.closeConnection();

            }

            if (valid) this.Close();
        }
    }
}
