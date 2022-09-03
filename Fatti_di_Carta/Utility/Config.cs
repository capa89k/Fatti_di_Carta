using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Fatti_di_Carta.Utility
{
    class Config
    {
        private const string csName = "Fatti_di_Carta.Properties.Settings.databaseConnectionString";

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[csName].ConnectionString;
        }
    }
}
