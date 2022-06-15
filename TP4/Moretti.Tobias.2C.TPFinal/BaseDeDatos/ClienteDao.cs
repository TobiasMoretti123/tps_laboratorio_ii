using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Biblioteca;


namespace BaseDeDatos
{
    /// <summary>
    /// Clase encargada de manejar la base de datos
    /// </summary>
    public class ClienteDao
    {
        #region Atributos
        /// <summary>
        /// Atributo privado de la connection string de la base de datos
        /// </summary>
        private static string connectionString;
        /// <summary>
        /// Atributo privado de la conexion de la base de datos
        /// </summary>
        private SqlConnection connection;
        /// <summary>
        /// Atributo privado del comando de la base de datos
        /// </summary>
        private SqlCommand command;
        #endregion

        #region Contructores
        /// <summary>
        /// Constructor estatico que establece la connection string
        /// </summary>
        static ClienteDao()
        {
            connectionString = @"Server=DESKTOP-C2SN2MS;Database=TP4_DB;Trusted_Connection=True;";
        }
        /// <summary>
        /// Constructor sin parametros que inicializa la conexcion los comandos y setea la base de datos
        /// </summary>
        public ClienteDao()
        {
            connection = new SqlConnection(ClienteDao.connectionString);
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda el cliente en la base de datos utilizando una query
        /// una vez guardado cierra la base de datos
        /// </summary>
        /// <param name="cliente">El cliente a guardar en la base de datos</param>
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
        /// <summary>
        /// Lee la base de datos de cliente utilizando una query y establece cada dato que lee de ella en un cliente
        /// luego lo agrega a una lista de clientes. Al terminar de leer y agregar cierra la conexion
        /// </summary>
        /// <returns>La lista de los clientes leidos</returns>
        public List<Cliente> Leer()
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                string query = "Select * FROM Cliente";
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
        /// <summary>
        /// Modifica a un cliente de la base de datos en base a su id utilizando una query
        /// Cuando termina cierra la conexion
        /// </summary>
        /// <param name="id">El id del cliente a modificar</param>
        /// <param name="cliente">El cliente a modificar</param>
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
        /// <summary>
        /// Elimina un cliente de la base de datos en base a su id utilizando una query
        /// al finalizar cierra la conexion
        /// </summary>
        /// <param name="id">El id a eliminar</param>
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
        #endregion
    }
}
