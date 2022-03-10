using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Rol
    {
        public List<Rol> Listar()
        {
            var lista = new List<Rol>();

            using (SqlConnection conexion = new SqlConnection(ConexionDB.cadenaConexion))
            {
                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT IdRol,Descripcion FROM ROL");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            lista.Add(new Rol()
                            {
                                
                                IdRol = Convert.ToInt32(reader["IdRol"]),
                                Descripcion = reader["Descripcion"].ToString(),

                            });
                        }

                    }
                }
                catch (Exception ex)
                {

                    lista = new List<Rol>();
                }
            }

            return lista;
        }
    }
}