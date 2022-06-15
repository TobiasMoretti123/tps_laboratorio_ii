using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Biblioteca;


namespace BaseDeDatos
{
    public class ClienteDao
    {
        private static string connectionString;
        private SqlConnection connection;
        private SqlCommand command;

        static ClienteDao()
        {
            connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Cliente_DB;Data Source=DESKTOP-C2SN2MS";
        }

        public ClienteDao()
        {
            connection = new SqlConnection(ClienteDao.connectionString);
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }

        public void Guardar(Cliente cliente)
        {

            try
            {
                connection.Open();

                string query = "INSERT INTO Cliente (nombre, cuit, idCilindro,tamanioCilindro) VALUES (@nombre, @cuit, @idCilindro, @tamanioCilindro)";

                command.CommandText = query;

                command.Parameters.Clear();
                command.Parameters.AddWithValue("nombre", cliente.Nombre);
                command.Parameters.AddWithValue("cuit", cliente.Cuit);
                command.Parameters.AddWithValue("idCilindro", cliente.Cilindro.TipoResistencia);
                command.Parameters.AddWithValue("tamanioCilindro", cliente.Cilindro.Tamanio);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection is not null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public List<Cliente> Leer()
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                string query = "Select * FROM Cliente";
                Random random = new Random();
                connection.Open();
                command.CommandText = query;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    int idCliente = dataReader.GetInt32(0);
                    string nombre = dataReader.GetString(1);
                    string cuit = dataReader.GetString(2);
                    int idCilindro = dataReader.GetInt32(3);
                    int tamanioCilindro = dataReader.GetInt32(4);

                    Cliente cliente = new Cliente(idCliente, nombre, cuit);

                    switch (idCilindro)
                    {
                        case 0:
                            cliente.Cilindro = new Fisica();
                            cliente.Cilindro.TipoResistencia = Cilindro.ETipoResistencia.Fisica;
                            break;
                        case 1:
                            cliente.Cilindro = new Quimica();
                            cliente.Cilindro.TipoResistencia = Cilindro.ETipoResistencia.Quimica;
                            break;
                        case 2:
                            cliente.Cilindro = new Termica();
                            cliente.Cilindro.TipoResistencia = Cilindro.ETipoResistencia.Termica;
                            break;
                    }
                    cliente.Cilindro.Tamanio = tamanioCilindro;
                    lista.Add(cliente);
                }
                return lista;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (connection is not null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void Modificar(int id, Cliente cliente)
        {
            try
            {
                string query = "UPDATE Cliente SET nombre = @nombre, cuit = @cuit WHERE idCliente = @id";

                connection.Open();

                command.CommandText = query;

                command.Parameters.Clear();
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("nombre", cliente.Nombre);
                command.Parameters.AddWithValue("cuit", cliente.Cuit);

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (connection is not null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                string query = "DELETE FROM Cliente WHERE idCliente = @idBuscado";

                connection.Open();

                command.CommandText = query;

                command.Parameters.Clear();
                command.Parameters.AddWithValue("idBuscado", id);

                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (connection is not null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
