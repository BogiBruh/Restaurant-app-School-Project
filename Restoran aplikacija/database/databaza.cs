using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;
using Restoran_aplikacija.klase;

namespace Restoran_aplikacija
{
    public class databaza
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
                MessageBox.Show(ex.Message + Environment.NewLine + "loadIntoJeloList");

                return returnList;
            }
            finally
            {
                baza.closeConnection();
            }
        }
        public static List<prilog> loadIntoPrilogList(databaza baza)
        {
            List<prilog> returnList = new List<prilog>();
            try
            {
                baza.openConnection();
                OleDbCommand cmd = new OleDbCommand
                {
                    Connection = baza.Conn,
                    CommandText = "select * from prilog"
                };
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
                MessageBox.Show(ex.Message + Environment.NewLine + "loadIntoPrilogList");

                return returnList;
            }
            finally
            {
                baza.closeConnection();
            }
        }
    }
}
