using PrimerEntregaProyectoFinal.ADO.NET;

namespace PrimerEntregaProyectoFinal
{
    public class ProbarObjetos
    {
        static void Main(string[] args)
        {
            UsuarioHandler usuarioHandler = new UsuarioHandler();

            usuarioHandler.GetUsuarios();

            if (usuarioHandler.IniciarSesion())
            {
                ProductoHandler productoHandler = new ProductoHandler();

                productoHandler.GetProductos();

                ProductoVendidoHandler productoVendidoHandler = new ProductoVendidoHandler();

                productoVendidoHandler.GetProductosVendidos();

                VentaHandler ventaHandler = new VentaHandler();

                ventaHandler.GetVentas();
            }
            

            

        }
    }
}
