using PrimerEntregaProyectoFinal.ADO.NET;

namespace PrimerEntregaProyectoFinal
{
    public class ProbarObjetos
    {
        static void Main(string[] args)
        {
            ProductoHandler productoHandler = new ProductoHandler();

            productoHandler.GetProductos();

            UsuarioHandler usuarioHandler = new UsuarioHandler();

            usuarioHandler.GetUsuarios();

            ProductoVendidoHandler productoVendidoHandler = new ProductoVendidoHandler();

            productoVendidoHandler.GetProductosVendidos();

            VentaHandler ventaHandler = new VentaHandler();

            ventaHandler.GetVentas();

        }
    }
}
