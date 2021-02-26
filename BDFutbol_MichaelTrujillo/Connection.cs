using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Michael Jonay Trujillo Padilla
 * */

namespace exaInmobiliaria_MichaelTrujillo
{
    class Connection
    {
        public Connection() { }

        public SqlConnection Con()
        {
            
            string connectionString = "Data Source=DESKTOP-2IDJVON\\SQLEXPRESS01;Initial Catalog=Inmobiliaria;User ID=sa;Password=michael";

            SqlConnection connection = new SqlConnection(connectionString);
           

            return connection;
        }
    }
}
