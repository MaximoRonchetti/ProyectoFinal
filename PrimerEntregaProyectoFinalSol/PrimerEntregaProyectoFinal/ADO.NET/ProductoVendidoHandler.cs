using PrimerEntregaProyectoFinal.Models;
using System.Data.SqlClient;

namespace PrimerEntregaProyectoFinal.ADO.NET
{
    public class ProductoVendidoHandler : DbHandler
    {
        public List<ProductoVendido> TraerProductosVendidos(Usuario pUsuario)
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryTraerProductos = "SELECT ProductoVendido.Id, ProductoVendido.Stock, ProductoVendido.IdProducto, ProductoVendido.IdVenta " +
                    "FROM ProductoVendido INNER JOIN Producto ON ProductoVendido.IdProducto = Producto.Id WHERE Producto.IdUsuario = @vIdProducto";

                SqlParameter parametroIdUsuario = new SqlParameter();
                parametroIdUsuario.ParameterName = "vIdProducto";
                parametroIdUsuario.SqlDbType = System.Data.SqlDbType.Int;
                parametroIdUsuario.Value = pUsuario.Id;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryTraerProductos, sqlConnection))
                {
                    sqlCommand.Parameters.Add(parametroIdUsuario);

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

                                productosVendidos.Add(productoVendido);
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
