using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

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
    }
}
