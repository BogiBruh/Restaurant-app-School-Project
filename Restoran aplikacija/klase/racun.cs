using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_aplikacija.klase
{
    class racun
    {
        private int idRacuna;
        private int ukupnaCena;
        private DateTime datumRacuna;

        public racun(int idRacuna, int ukupnaCena, DateTime datumRacuna)
        {
            this.IdRacuna = idRacuna;
            this.UkupnaCena = ukupnaCena;
            this.DatumRacuna = datumRacuna;
        }

        public int IdRacuna { get => idRacuna; set => idRacuna = value; }
        public int UkupnaCena { get => ukupnaCena; set => ukupnaCena = value; }
        public DateTime DatumRacuna { get => datumRacuna; set => datumRacuna = value; }
    }
}
