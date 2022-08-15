using PrimerEntregaProyectoFinal.ADO.NET;
using PrimerEntregaProyectoFinal.Models;

namespace PrimerEntregaProyectoFinal
{
    public class ProbarObjetos
    {
        static void Main(string[] args)
        {
            UsuarioHandler usuarioHandler = new UsuarioHandler();

            Usuario tobias = usuarioHandler.TraerUsuario("tcasazza");

            usuarioHandler.IniciarSesion("tcasazza", "holasoyTobias");

            ProductoHandler productoHandler = new ProductoHandler();

            productoHandler.TraerProductos(tobias);

            productoHandler.TraerProductosVendidos(tobias);

            VentaHandler ventaHandler = new VentaHandler();

            ventaHandler.TraerVentas(tobias);

        }
    }
}
