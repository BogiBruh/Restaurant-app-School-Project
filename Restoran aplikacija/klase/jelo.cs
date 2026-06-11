using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_aplikacija
{
    class jelo
    {
        private int idJela;
        private string naziv;
        private int cena;

        public jelo(int idJela, string naziv, int cena)
        {
            this.IdJela = idJela;
            this.Naziv = naziv;
            this.Cena = cena;
        }

        public jelo()
        {
            //nista, sorry
        }

        public int IdJela { get => idJela; set => idJela = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public int Cena { get => cena; set => cena = value; }
    }
}
