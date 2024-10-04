using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class Baglanti
    {
        public static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-08T2I2C;Initial Catalog=musteriDB;Integrated Security=True");

        public static void BaglantiAc(SqlConnection tempConnection)
        {

            if (tempConnection.State == ConnectionState.Closed)
            {
                tempConnection.Open();
            }
            else
            {

            }
        }

    }
}
