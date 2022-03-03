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
    public class CD_Usuario
    {

        public List<Usuario> Listar()
        {
            var lista = new List<Usuario>();

            using (SqlConnection conexion = new SqlConnection(ConexionDB.cadenaConexion))
            {
                try
                {
                    string query = "SELECT IdUsuario,Documento,NombreCompleto,Correo,Clave,Estado FROM Usuario";

                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read()) 
                        {
                            lista.Add(new Usuario() 
                            { 
                            
                                IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                                Documento = reader["Documento"].ToString(),
                                NombreCompleto = reader["NombreCompleto"].ToString(),
                                Correo = reader["Correo"].ToString(),
                                Clave = reader["Clave"].ToString(),
                                Estado = Convert.ToBoolean(reader["Estado"])


                            });
                        }

                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

            return lista;
        }

    }
}
