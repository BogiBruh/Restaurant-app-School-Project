using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_aplikacija.klase
{
    public class stavkaRacuna
    {
        private int idRacuna;
        private int idJela;
        private int idPriloga;
        private int cenaJela;
        private int cenaPriloga;

        public stavkaRacuna(int idRacuna, int idJela, int idPriloga, int cenaJela, int cenaPriloga)
        {
            this.IdRacuna = idRacuna;
            this.IdJela = idJela;
            this.IdPriloga = idPriloga;
            this.CenaJela = cenaJela;
            this.CenaPriloga = cenaPriloga;
        }

        public stavkaRacuna()
        {
            this.idRacuna = 0;
            this.idJela = 0;
            this.idPriloga = 0;
            this.cenaPriloga= 0;
            this.cenaJela= 0;
        }

        public int IdRacuna { get => idRacuna; set => idRacuna = value; }
        public int IdJela { get => idJela; set => idJela = value; }
        public int IdPriloga { get => idPriloga; set => idPriloga = value; }
        public int CenaJela { get => cenaJela; set => cenaJela = value; }
        public int CenaPriloga { get => cenaPriloga; set => cenaPriloga = value; }
    }
}
