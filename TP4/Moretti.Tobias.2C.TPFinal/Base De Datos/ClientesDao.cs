using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Biblioteca;

namespace BaseDeDatos
{
    public class ClientesDao
    {
        private static string connectionString;
        private SqlConnection connection;
        private SqlCommand command;

        static ClientesDao()
        {
            connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Cliente_DB;Data Source=DESKTOP-C2SN2MS";
        }
        
        public ClientesDao()
        {
            connection = new SqlConnection(ClientesDao.connectionString);
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }

        public void Guardar(Cliente cliente)
        {

            try
            {
                connection.Open();

                string query = "INSERT INTO Cliente (nombre, cuit, idCilindro) VALUES (@nombre, @cuit, @idCilindro)";

                command.CommandText = query;

                command.Parameters.Clear();
                command.Parameters.AddWithValue("nombre", cliente.Nombre);
                command.Parameters.AddWithValue("cuit", cliente.Cuit);
                command.Parameters.AddWithValue("idCilindro", cliente.Cilindro.TipoResistencia);

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

                    Cliente cliente = new Cliente(idCliente,nombre, cuit);

                    switch (idCilindro)
                    {
                        case 0:
                            cliente.Cilindro = new Fisica(random.Next(0,3), Cilindro.ETipoResistencia.Fisica);                           
                            break;
                        case 1:
                            cliente.Cilindro = new Quimica(random.Next(0, 3), Cilindro.ETipoResistencia.Quimica);
                            break;
                        case 2:
                            cliente.Cilindro = new Termica(random.Next(0, 3), Cilindro.ETipoResistencia.Termica);
                            break;
                    }
                    if(cliente.Cilindro.Tamanio == 1)
                    {
                        cliente.Cilindro.Tamanio = 100;
                    }
                    else
                    {
                        cliente.Cilindro.Tamanio = 120;
                    } 
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
