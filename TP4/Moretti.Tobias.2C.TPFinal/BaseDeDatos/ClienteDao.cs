using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
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
        /// Atributo privado con la conexion a sql
        /// </summary>
        private SqlConnection sqlConnection;
        #endregion

        #region Contructores
        /// <summary>
        /// Constructor que establece la connection string
        /// </summary>
        public ClienteDao()
        {
            sqlConnection = new SqlConnection("Server=DESKTOP-C2SN2MS;Database=Cliente_DB;Trusted_Connection=True;");
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
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Cliente (nombre, cuit, idCilindro,tamanioCilindro) VALUES (@nombre, @cuit, @idCilindro, @tamanioCilindro)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("nombre", cliente.Nombre);
                sqlCommand.Parameters.AddWithValue("cuit", cliente.Cuit);
                sqlCommand.Parameters.AddWithValue("idCilindro", cliente.Cilindro.TipoResistencia);
                sqlCommand.Parameters.AddWithValue("tamanioCilindro", cliente.Cilindro.Tamanio);
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
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
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Select * FROM Cliente", sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                StringBuilder stringBuilder = new StringBuilder();

                while (reader.Read())
                {
                    int idCliente = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    string cuit = reader.GetString(2);
                    int idCilindro = reader.GetInt32(3);
                    int tamanioCilindro = reader.GetInt32(4);
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
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
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
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("UPDATE Cliente SET nombre = @nombre, cuit = @cuit WHERE idCliente = @id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("id", id);
                sqlCommand.Parameters.AddWithValue("nombre", cliente.Nombre);
                sqlCommand.Parameters.AddWithValue("cuit", cliente.Cuit);
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
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
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("DELETE FROM Cliente WHERE idCliente = @idBuscado", sqlConnection);
                sqlCommand.Parameters.AddWithValue("idBuscado", id);
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
        #endregion
    }
}
