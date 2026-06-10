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
        private double cena;

        public jelo(int idJela, string naziv, double cena)
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
        public double Cena { get => cena; set => cena = value; }
    }
}
