using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tournament.Library;
using Tournament.Library.Data;
using Tournament.Library.Models;

namespace Tournament.Library
{
    public static class GlobalConfiguration 
    {
        public static   List<IDataConnection>  Connection1 { get;private set; } = new List<IDataConnection>();

        public static IDataConnection Connection { get; set; }

        public static void InitializeConnection(DatabaseType database)
        {
            if (database == DatabaseType.SQL)
            {
               //TODO - nastavit sql connector spravne
               SqlConnector sql = new SqlConnector();
                Connection = sql;

            }
            if (database == DatabaseType.TEXT)
            {
                //TODO - vytvorit textove spojeni
                TextConnector text = new TextConnector();
                Connection = text;
            }
        }

        public static string CnnValue(string val)
        {
            return ConfigurationManager.ConnectionStrings[val].ConnectionString;
        }

        public static void Init(bool data, bool text)
        {
            List<IDataConnection> connect = new List<IDataConnection>();
            if (data)
            {
                SqlConnector sql  = new SqlConnector();
               connect.Add(sql);
            }
            if (text)
            {
                TextConnector textor = new TextConnector();
                connect.Add(textor);
            }
        }
    }
    
}
