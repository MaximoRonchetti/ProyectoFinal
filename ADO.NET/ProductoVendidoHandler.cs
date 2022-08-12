using PrimerEntregaProyectoFinal.Models;
using System.Data.SqlClient;

namespace PrimerEntregaProyectoFinal.ADO.NET
{
    public class ProductoVendidoHandler : DbHandler
    {
        public List<ProductoVendido> GetProductosVendidos()
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ProductoVendido", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido();

                                productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return productosVendidos;
        }
    }
}
