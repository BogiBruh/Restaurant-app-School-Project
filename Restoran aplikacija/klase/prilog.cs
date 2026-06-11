using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_aplikacija.klase
{
    class prilog
    {
        private int idPriloga;
        private int cenaPriloga;
        private string nazivPriloga;

        public prilog(int idPriloga, int cenaPriloga, string nazivPriloga)
        {
            this.IdPriloga = idPriloga;
            this.CenaPriloga = cenaPriloga;
            this.NazivPriloga = nazivPriloga;
        }

        public int IdPriloga { get => idPriloga; set => idPriloga = value; }
        public int CenaPriloga { get => cenaPriloga; set => cenaPriloga = value; }
        public string NazivPriloga { get => nazivPriloga; set => nazivPriloga = value; }
    }
}
