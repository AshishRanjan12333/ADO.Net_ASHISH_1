using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace ADO.Net_ASHISH_1.Models
{
    public class DbConnetcion
         
    {
        public SqlConnection Connection;
        public DbConnetcion()
        {
            Connection = new SqlConnection(DbConfig.ConnectionStr);
        }
    }
}
