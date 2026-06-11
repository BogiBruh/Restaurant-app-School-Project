using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Restoran_aplikacija
{
    class databaza
    {
        OleDbConnection conn;

        public databaza(string konekcioniString)
        {
            conn = new OleDbConnection(konekcioniString);
        }

        public OleDbConnection Conn { get => conn; set => conn = value; }

        public void openConnection()
        {
            conn.Open();
        }

        public void closeConnection()
        {
            conn.Close();
        }

        public static List<jelo> loadIntoJeloList(databaza baza)
        {
            List <jelo> returnList = new List<jelo>();
            try
            {
                baza.openConnection();
                OleDbCommand cmd = new OleDbCommand
                {
                    Connection = baza.Conn,
                    CommandText = "select * from jelo"
                };
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    jelo jeloZaDodati = new jelo();
                    jeloZaDodati.IdJela = int.Parse(rd["id_jelo"].ToString());
                    jeloZaDodati.Naziv = rd["naziv"].ToString();
                    jeloZaDodati.Cena = int.Parse(rd["cena"].ToString());

                    returnList.Add(jeloZaDodati);
                }
                
                return returnList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return returnList;
            }
            finally
            {
                baza.closeConnection();
            }
        }
    }
}
