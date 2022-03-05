using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
namespace CapaDatos
{
    public class CD_Permiso
    {

        public List<Permiso> Listar(int idUsuario)
        {
            var lista = new List<Permiso>();

            using (SqlConnection conexion = new SqlConnection(ConexionDB.cadenaConexion))
            {
                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT p.IdRol,p.NombreMenu from PERMISO p");
                    query.AppendLine("inner join ROL r on r.IdRol = p.IdRol ");
                    query.AppendLine("inner join USUARIO u on u.IdRol = r.IdRol");
                    query.AppendLine("where u.IdUsuario = @IdUsuario");
                   

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            lista.Add(new Permiso()
                            {

                                Rol = new Rol() {IdRol = Convert.ToInt32(reader["IdRol"])},
                                NombreMenu = reader["NombreMenu"].ToString(),
                                


                            });
                        }

                    }
                }
                catch (Exception ex)
                {

                    lista = new List<Permiso>();
                }
            }

            return lista;
        }

    }
}
