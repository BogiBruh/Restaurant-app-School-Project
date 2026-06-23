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
                    CommandText = "select * from jelo where naziv <> \"[OBRISANO JELO]\""
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
                    CommandText = "select * from prilog where naziv <> \"[OBRISAN PRILOG]\""
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

        public static void addPlaceholderDeletedJelo(databaza baza)
        {
            try
            {
                baza.openConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;

                // Provera da li placeholder postoji
                cmd.CommandText = "select count(*) from jelo where naziv = @nazivJela";
                cmd.Parameters.AddWithValue("@nazivJela", "[OBRISANO JELO]");

                int broj = int.Parse(cmd.ExecuteScalar().ToString());

                if (broj == 0) // ako ne, kreiraj placeholder
                {
                    cmd.Parameters.Clear();

                    cmd.CommandText = "insert into jelo(naziv, cena) values(@nazivJela, @cenaJela)";
                    cmd.Parameters.AddWithValue("@nazivJela", "[OBRISANO JELO]");
                    cmd.Parameters.AddWithValue("@cenaJela", 0);

                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in databaza.cs, addPlaceholderDeletedJelo");
            }
            finally
            {
                baza.closeConnection();
            }
        }

        public static void addPlaceholderDeletedPrilog(databaza baza)
        {
            try
            {
                baza.openConnection();

                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;

                cmd.CommandText = "select count(*) from prilog where naziv = @nazivPriloga";
                cmd.Parameters.AddWithValue("@nazivPriloga", "[OBRISAN PRILOG]");

                int broj = int.Parse(cmd.ExecuteScalar().ToString());

                if (broj == 0)
                {
                    cmd.Parameters.Clear();

                    cmd.CommandText = "insert into prilog(naziv, cena) values(@nazivPriloga, @cenaPriloga)";
                    cmd.Parameters.AddWithValue("@nazivPriloga", "[OBRISAN PRILOG]");
                    cmd.Parameters.AddWithValue("@cenaPriloga", 0);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in databaza.cs, addPlaceholderDeletedPrilog");
            }
            finally
            {
                baza.closeConnection();
            }
        }

        public static void deleteStavkaRacuna(databaza baza, int idStavke)
        {
            try
            {
                baza.openConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;

                cmd.CommandText = "select cenaJelo + cenaPrilog as ukupna_cena, id_racun from stavka_racuna where id_stavke = @idStavke";
                cmd.Parameters.AddWithValue("@idStavke", idStavke);
                int cena = 0;
                int idRacuna = 0;

                OleDbDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    idRacuna = int.Parse(reader["id_racun"].ToString());
                    cena = int.Parse(reader["ukupna_cena"].ToString());
                }
                reader.Close();

                cmd.Parameters.Clear();

                cmd.CommandText = "update racun " +
                    "set ukupna_cena = ukupna_cena - @cenaObroka " +
                    "where id_racun = @idRacuna";
                cmd.Parameters.AddWithValue("@cenaObroka", cena);
                cmd.Parameters.AddWithValue("@idRacuna", idRacuna);
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();

                cmd.CommandText = "delete from stavka_racuna where id_stavke = @idStavke";
                cmd.Parameters.AddWithValue("@idStavke", idStavke);
                int affected = cmd.ExecuteNonQuery();
                Console.Write($"Deleted {affected} rows\n");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in databaza delete");
            }
            finally
            {
                baza.closeConnection();
            }
        }
    }
}
