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
    public partial class editPrilog : Form
    {
        databaza baza;
        List<prilog> listaPriloga;

        public editPrilog()
        {
            InitializeComponent();
        }

        public editPrilog(List<prilog> _listaPriloga, databaza _baza)
        {
            InitializeComponent();
            listaPriloga = _listaPriloga;
            baza = _baza;
        }

        private void editPrilog_Load(object sender, EventArgs e)
        {
            comboPrilog.Items.Clear();
            comboPrilog.DataSource = listaPriloga;
            comboPrilog.DisplayMember = "NazivPriloga";
            comboPrilog.ValueMember = "IdPriloga";

            if (listaPriloga.Count == 0)
            {
                MessageBox.Show("Morate imati priloge da biste ih izmenjivali!");
                this.Close();
            }
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
                string noviNazivPriloga;
                int novaCenaPriloga;
                OleDbCommand cmd = new OleDbCommand();
                baza.openConnection();
                cmd.Connection = baza.Conn;

                if (tboxNaziv.Text.Length > 0)
                {
                    noviNazivPriloga = tboxNaziv.Text;
                    if (int.TryParse(tboxCena.Text, out novaCenaPriloga))
                    {
                        prilog izabranPrilog = comboPrilog.SelectedItem as prilog;

                        cmd.CommandText = "update prilog " +
                            "set naziv = @nazivPriloga, cena = @cenaPriloga " +
                            "where id_prilog = @idPriloga";
                        cmd.Parameters.AddWithValue("@nazivPriloga", noviNazivPriloga);
                        cmd.Parameters.AddWithValue("@cenaPriloga", novaCenaPriloga);
                        cmd.Parameters.AddWithValue("@idPriloga", izabranPrilog.IdPriloga);

                        cmd.ExecuteNonQuery();
                        valid = true;
                    }
                    else
                    {
                        MessageBox.Show("Morate pravilno uneti novu cenu priloga!");
                    }
                }
                else
                {
                    MessageBox.Show("Morate uneti novi naziv priloga!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in editPrilog.btnOk_Click");
            }
            finally
            {
                baza.closeConnection();

            }

            if (valid) this.Close();
        }

        private void comboPrilog_SelectedIndexChanged(object sender, EventArgs e)
        {
            prilog selektovanoJelo = comboPrilog.SelectedItem as prilog;
            tboxNaziv.Text = selektovanoJelo.NazivPriloga;
            tboxCena.Text = selektovanoJelo.CenaPriloga.ToString();
        }
    }
}
