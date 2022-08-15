using PrimerEntregaProyectoFinal.Models;
using System.Data.SqlClient;

namespace PrimerEntregaProyectoFinal.ADO.NET
{
    public class UsuarioHandler : DbHandler
    {
        public Usuario TraerUsuario(string pNombreUsuario)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string queryTraerUsuario = "SELECT * FROM Usuario WHERE NombreUsuario = @vNombreUsuario";

                SqlParameter parametroNombreUsuario = new SqlParameter();
                parametroNombreUsuario.ParameterName = "vNombreUsuario";
                parametroNombreUsuario.SqlDbType = System.Data.SqlDbType.VarChar;
                parametroNombreUsuario.Value = pNombreUsuario;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryTraerUsuario, sqlConnection))
                {
                    sqlCommand.Parameters.Add(parametroNombreUsuario);

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            Usuario usuario = new Usuario();

                            usuario.Id = Convert.ToInt32(dataReader["Id"]);
                            usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                            usuario.Nombre = dataReader["Nombre"].ToString();
                            usuario.Apellido = dataReader["Apellido"].ToString();
                            usuario.Contraseña = dataReader["Contraseña"].ToString();
                            usuario.Mail = dataReader["Mail"].ToString();

                            return usuario;
                        }
                        return null;
                    }
                    sqlConnection.Close();
                }
            }
        }

        internal Usuario IniciarSesion(string pNombreUsuario, string pConstraseña)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                string querySelectLogin = "SELECT NombreUsuario, Contraseña FROM Usuario WHERE NombreUsuario = @vNombreUsuario" +
                  " AND Contraseña = @vContraseña";

                SqlParameter parametroNombreUsuario = new SqlParameter();
                parametroNombreUsuario.ParameterName = "vNombreUsuario";
                parametroNombreUsuario.SqlDbType = System.Data.SqlDbType.VarChar;
                parametroNombreUsuario.Value = pNombreUsuario;

                SqlParameter parametroConstraseña = new SqlParameter();
                parametroConstraseña.ParameterName = "vContraseña";
                parametroConstraseña.SqlDbType = System.Data.SqlDbType.VarChar;
                parametroConstraseña.Value = pConstraseña;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(querySelectLogin, sqlConnection))
                {
                    sqlCommand.Parameters.Add(parametroNombreUsuario);
                    sqlCommand.Parameters.Add(parametroConstraseña);

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            Usuario usuario = new Usuario();

                            usuario.Id = Convert.ToInt32(dataReader["Id"]);
                            usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                            usuario.Nombre = dataReader["Nombre"].ToString();
                            usuario.Apellido = dataReader["Apellido"].ToString();
                            usuario.Contraseña = dataReader["Contraseña"].ToString();
                            usuario.Mail = dataReader["Mail"].ToString();

                            return usuario;
                        }
                        else
                        {
                            Usuario usuario = new Usuario();

                            usuario.Id = 0;
                            usuario.NombreUsuario = String.Empty;
                            usuario.Nombre = String.Empty;
                            usuario.Apellido = String.Empty;
                            usuario.Contraseña = String.Empty;
                            usuario.Mail = String.Empty;

                            return usuario;
                        }
                        sqlConnection.Close();
                    }
                }
            }
        }

    }

}

