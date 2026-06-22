using Restoran_aplikacija.forme;
using Restoran_aplikacija.forme.brisanje;
using Restoran_aplikacija.forme.dodavanje;
using Restoran_aplikacija.forme.editovanje;
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
    }
}
