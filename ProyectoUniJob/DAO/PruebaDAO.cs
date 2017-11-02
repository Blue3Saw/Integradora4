using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class PruebaDAO
    {
        ConexionDAO Conex = new ConexionDAO();
        string sentencia;

        public DataTable VerTabla()
        {
            sentencia = "SELECT * FROM Contactos";
            SqlDataAdapter mostar = new SqlDataAdapter(sentencia, Conex.ConectarBD());
            DataTable tablavirtual = new DataTable();
            mostar.Fill(tablavirtual);
            return tablavirtual;
        }
    }
}
