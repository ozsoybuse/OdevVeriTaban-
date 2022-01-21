using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Odev
{
    class OracleBaglanti
    {
        public OracleConnection Baglanti()
        {
            OracleConnection baglan = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));User Id=SYSTEM;Password=1234;");         // bağlantımı sağladım


            baglan.Open();  // baglantı açıldı
            return baglan;  // dönderdi


        }







    


    }
}
