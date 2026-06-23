using Restoran_aplikacija.forme;
using Restoran_aplikacija.forme.brisanje;
using Restoran_aplikacija.forme.dodavanje;
using Restoran_aplikacija.forme.editovanje;
using Restoran_aplikacija.forme.izvestaji;
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

namespace Restoran_aplikacija
{
    public partial class MainForm : Form
    {
        // ### DEKLARISANJE GLOBALNIH PROMENLJIVIHJ ###
        databaza baza;
        List<jelo> listaJela;
        List<prilog> listaPriloga;
        int[] racuniZaStolovima;
        Button[] dugmadStolova;
        // ### DEKLARISANJE GOTOVO###
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            baza = new databaza(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\database\\Restoran.accdb");
            listaJela = new List<jelo>();
            listaJela = databaza.loadIntoJeloList(baza);
            listaPriloga = new List<prilog>();
            listaPriloga = databaza.loadIntoPrilogList(baza);
            racuniZaStolovima = new int[6];

            // Dodaj placeholdere ako ih nema
            databaza.addPlaceholderDeletedPrilog(baza);
            databaza.addPlaceholderDeletedJelo(baza);

            // panelRacun positioning and mainform size setup
            panelRacun.Location = new Point(5, 30);
            panelRacun.Visible = false;
            this.Size = new Size(1280, 755);

            // podesavanje dugmadStolova niza
            dugmadStolova = new Button[]
            {
                btnFirstTable, btnSecondTable, btnThirdTable, btnFourthTable, btnFifthTable, btnSixthTable
            };
        }

        private void dodajJeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addJelo formaZaDodavanjeJela = new addJelo(baza);
            formaZaDodavanjeJela.ShowDialog();
            listaJela.Clear();
            listaJela = databaza.loadIntoJeloList(baza);
        }

        private void dodajPrilogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addPrilog formaZaDodavanjePriloga = new addPrilog(baza);
            formaZaDodavanjePriloga.ShowDialog();
            listaPriloga.Clear();
            listaPriloga = databaza.loadIntoPrilogList(baza);
        }

        private void izmeniJeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editJelo formaZaIzmenuJela = new editJelo(listaJela, baza);
            formaZaIzmenuJela.ShowDialog();
            listaJela.Clear();
            listaJela = databaza.loadIntoJeloList(baza);
        }

        private void izmeniPrilogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editPrilog formaZaIzmenuPriloga = new editPrilog(listaPriloga, baza);
            formaZaIzmenuPriloga.ShowDialog();
            listaPriloga.Clear();
            listaPriloga = databaza.loadIntoPrilogList(baza);
        }

        private void izbrisiJeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteJelo formaZaBrisanjeJela = new deleteJelo(listaJela, baza);
            formaZaBrisanjeJela.ShowDialog();
            listaJela.Clear();
            listaJela = databaza.loadIntoJeloList(baza);
        }

        private void izbrisiPrilogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deletePrilog formaZaBrisanjePriloga = new deletePrilog(listaPriloga, baza);
            formaZaBrisanjePriloga.ShowDialog();
            listaPriloga.Clear();
            listaPriloga = databaza.loadIntoPrilogList(baza);
        }

        private void poveziPrilogZaJeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connectJeloPrilog formaZaPovezivanje = new connectJeloPrilog(baza);
            formaZaPovezivanje.ShowDialog();
            //listaPripadnosti reloadovanje ako budem to pravio, mislim da cu samo proveravati po potrebi doduse bez nove promenljive
        }

        private void odveziPrilogOdJelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disconnectJeloPrilog formaZaOdvezivanje = new disconnectJeloPrilog(baza);
            formaZaOdvezivanje.ShowDialog();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int indeksStola;
            if (btn == null || btn.Tag == null)
            {
                return;
            }
            else indeksStola = int.Parse(btn.Tag.ToString());
            int idRacuna = racuniZaStolovima[indeksStola];

            if(idRacuna == 0)
            {
                lblBrStola.Text = "Sto " + (indeksStola + 1).ToString();
                racuniZaStolovima[indeksStola] = kreirajRacun();

                // debug lol
                Console.WriteLine($"Sada je matrica racuniZaStolovima vrednosti [{racuniZaStolovima[0]},{racuniZaStolovima[1]}," +
                    $"{racuniZaStolovima[2]},{racuniZaStolovima[3]},{racuniZaStolovima[4]},{racuniZaStolovima[5]}]\n");

                btn.Text = "Otvori racun";
            }
            else
            {
                lblBrStola.Text = "Sto " + (indeksStola + 1).ToString();
                procitajRacun(idRacuna);
            }
            panelRacun.Visible = true;
        }

        private int kreirajRacun()
        {
            int idKreiranogRacuna = 0;
            bool valid = false;
            try
            {
                baza.openConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "insert into racun(ukupna_cena, datum) values(@cena, @datum)";
                cmd.Parameters.AddWithValue("@cena", 0);
                cmd.Parameters.AddWithValue("@datum", DateTime.Now.Date);

                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();

                cmd.CommandText = "select @@identity";
                idKreiranogRacuna = int.Parse(cmd.ExecuteScalar().ToString());
                valid = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in mainForm kreirajRacun");
                return idKreiranogRacuna;
            }
            finally
            {
                baza.closeConnection();
            }

            if (valid)
            {
                return idKreiranogRacuna;
            }
            else return 0;
        }

        private void procitajRacun(int idRacuna)
        {
            try
            {
                int cenaRacuna = 0;
                List<stavkaRacuna> stavkeRacunaLista = new List<stavkaRacuna>();
                baza.openConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "select * from stavka_racuna where id_racun = @idRacuna";
                cmd.Parameters.AddWithValue("@idRacuna", idRacuna);

                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    stavkaRacuna novaStavka = new stavkaRacuna();
                    novaStavka.IdStavke = int.Parse(reader["id_stavke"].ToString());
                    novaStavka.IdRacuna = idRacuna;
                    novaStavka.IdJela = int.Parse(reader["id_jelo"].ToString());
                    novaStavka.IdPriloga = int.Parse(reader["id_prilog"].ToString());
                    novaStavka.CenaJela = int.Parse(reader["cenaJelo"].ToString());
                    novaStavka.CenaPriloga = int.Parse(reader["cenaPrilog"].ToString());

                    cenaRacuna += novaStavka.CenaJela + novaStavka.CenaPriloga;

                    stavkeRacunaLista.Add(novaStavka);
                }
                reader.Close();
                lblCena.Text = cenaRacuna.ToString() + " din";

                for(int i = 0; i < stavkeRacunaLista.Count; i++)
                {
                    panelStavkaRacuna noviPanel = new panelStavkaRacuna(baza);
                    cmd.Parameters.Clear();
                    cmd.CommandText = "select naziv from jelo where id_jelo = @idJela";
                    cmd.Parameters.AddWithValue("@idJela", stavkeRacunaLista[i].IdJela);
                    string nazivJela = cmd.ExecuteScalar() as string;
                    noviPanel.podesiJelo(nazivJela, stavkeRacunaLista[i].CenaJela);

                    cmd.Parameters.Clear();
                    cmd.CommandText = "select naziv from prilog where id_prilog = @idPriloga";
                    cmd.Parameters.AddWithValue("@idPriloga", stavkeRacunaLista[i].IdPriloga);
                    string nazivPriloga = cmd.ExecuteScalar() as string;
                    noviPanel.podesiPrilog(nazivPriloga, stavkeRacunaLista[i].CenaPriloga);
                    noviPanel.dodajIdStavke(stavkeRacunaLista[i].IdStavke);
                    noviPanel.BorderStyle = BorderStyle.FixedSingle;

                    flowStavke.Controls.Add(noviPanel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in mainForm procitajRacun");
            }
            finally
            {
                baza.closeConnection();
            }
        }

        private void btnDodajStavku_Click(object sender, EventArgs e)
        {
            int indeksStola = int.Parse(lblBrStola.Text[lblBrStola.Text.Length - 1].ToString()) - 1;
            int idRacuna = racuniZaStolovima[indeksStola];
            addStavkaRacuna dodajStavku = new addStavkaRacuna(baza, flowStavke, idRacuna);
            dodajStavku.ShowDialog();

            try
            {
                int cena;
                baza.openConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "select ukupna_cena " +
                    "from racun " +
                    "where id_racun = @idRacuna";
                cmd.Parameters.AddWithValue("@idRacuna", idRacuna);
                cena = int.Parse(cmd.ExecuteScalar().ToString());

                lblCena.Text = cena.ToString() + " din";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "Error in mainForm brnDodajStavku_Click");
            }
            finally
            {
                baza.closeConnection();
            }
        }

        private void btnHidePanel_Click(object sender, EventArgs e)
        {
            flowStavke.Controls.Clear();
            panelRacun.Visible = false;
        }

        private void btnPlatiRacun_Click(object sender, EventArgs e)
        {
            DialogResult rezultat = MessageBox.Show($"Da li ste sigurni da hocete da platite racun? Cena je {lblCena.Text}",
                "Placanje racuna",MessageBoxButtons.YesNo);
            
            if(rezultat == DialogResult.Yes)
            {
                int brStola = lblBrStola.Text[lblBrStola.Text.Length - 1] - '0';
                /* ovo gore vraca ascii vrednost broja stola. Da bismo dobili sam broj, bez konverzije, mozemo oduzeti ascii
                 * vrednost '0', i da dobijemo sam broj. Kako samo volim uredjenost ascii tabele koja ovo dozvoljava.
                 * Takodje, dole oduzimamo 1 da bismo dobili indeks. citljivije je tako nego samo gore to uraditi
                 * */
                racuniZaStolovima[brStola - 1] = 0;
                MessageBox.Show("Uspesno placen racun!");
                btnHidePanel_Click(sender, e);
                dugmadStolova[brStola - 1].Text = "Kreiraj racun";
            }
        }

        private void racuniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            izvestajRacuna izvestajForma = new izvestajRacuna(baza);
            izvestajForma.ShowDialog();
        }
    }
}
