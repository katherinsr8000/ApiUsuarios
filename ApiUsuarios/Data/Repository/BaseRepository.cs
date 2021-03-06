using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuarios.Data
{
    public class BaseRepository 
    {

        private readonly string cnx;

        public BaseRepository (string cnx)
        {
            this.cnx = cnx;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(cnx);
        }

    }
}
