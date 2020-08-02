using System;
using System.Configuration;
using System.Web.Configuration;

namespace SampleCqrs.Infra.Data.Helpers
{
    public static class ConnectionHelper
    {
        public static string GetConnectiosString()
        {
            string connectionString = "";

            foreach (ConnectionStringSettings connectionStringResult in WebConfigurationManager.ConnectionStrings)
                if (connectionStringResult.Name.Equals("SampleCqrsDbContext", StringComparison.InvariantCultureIgnoreCase))
                    connectionString = connectionStringResult.ConnectionString;

            return connectionString;
        }
    }
}