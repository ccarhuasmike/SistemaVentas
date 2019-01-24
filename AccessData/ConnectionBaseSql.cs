using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessData
{
    public static class ConnectionBaseSql
    {
        public static string ConexionBDSQL()
        {
            var strCadena = ConfigurationManager.ConnectionStrings["ConeccionSql"].ConnectionString.ToString();
            return strCadena;
        }
    }
}
