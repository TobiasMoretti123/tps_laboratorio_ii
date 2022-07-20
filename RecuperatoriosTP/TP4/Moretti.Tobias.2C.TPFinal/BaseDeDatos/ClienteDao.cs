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
            sqlConnection = new SqlConnection("Server=DESKTOP-C2SN2MS;Database=ClienteCilindroDB;Trusted_Connection=True;");
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda el cliente en la base de datos utilizando una query
        /// una vez guardado cierra la base de datos
        /// </summary>
        /// <param name="cliente">El cliente a guardar en la base de datos</param>
        public void GuardarCliente(Cliente cliente)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO Clientes (nombre,direccion,nacionalidad,cuit,contacto,telefono,mail,mailFacturaElectronica) VALUES (@nombre, @direccion, @nacionalidad, @cuit, @contacto, @telefono, @mail,@mailFacturaElectronica)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("nombre", cliente.RazonSocial);
                sqlCommand.Parameters.AddWithValue("direccion", cliente.Direccion);
                sqlCommand.Parameters.AddWithValue("nacionalidad", cliente.Nacionalidad);
                sqlCommand.Parameters.AddWithValue("cuit", cliente.Cuit);
                sqlCommand.Parameters.AddWithValue("contacto", cliente.Contacto);
                sqlCommand.Parameters.AddWithValue("telefono", cliente.Telefono);
                sqlCommand.Parameters.AddWithValue("mail", cliente.Mail);
                sqlCommand.Parameters.AddWithValue("mailFacturaElectronica", cliente.MailFacturaElectronico);
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
        public List<Cliente> LeerCliente()
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Select * FROM Clientes", sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                StringBuilder stringBuilder = new StringBuilder();

                while (reader.Read())
                {
                    int idCliente = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    string direccion = reader.GetString(2);
                    int nacionalidad = reader.GetInt32(3);
                    string cuit = reader.GetString(4);
                    string contacto = reader.GetString(5);
                    string telefono = reader.GetString(6);
                    string mail = reader.GetString(7);
                    string mailFacturaElectronica = reader.GetString(8);
                    Cliente cliente = new Cliente(idCliente,nombre,direccion,(Cliente.ENacionalidad)nacionalidad,cuit,contacto,telefono,mail,mailFacturaElectronica);

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
        public void ModificarCliente(int id, Cliente cliente)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("UPDATE Clientes SET nombre = @nombre,direccion = @direccion,nacionalidad = @nacionalidad,cuit = @cuit,contacto = @contacto,telefono = @telefono,mail = @mail,mailFacturaElectronica = @mailFacturaElectronica WHERE idCliente = @id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("id", id);
                sqlCommand.Parameters.AddWithValue("nombre", cliente.RazonSocial);
                sqlCommand.Parameters.AddWithValue("direccion", cliente.Direccion);
                sqlCommand.Parameters.AddWithValue("nacionalidad", cliente.Nacionalidad);
                sqlCommand.Parameters.AddWithValue("cuit", cliente.Cuit);
                sqlCommand.Parameters.AddWithValue("contacto", cliente.Contacto);
                sqlCommand.Parameters.AddWithValue("telefono", cliente.Telefono);
                sqlCommand.Parameters.AddWithValue("mail", cliente.Mail);
                sqlCommand.Parameters.AddWithValue("mailFacturaElectronica", cliente.MailFacturaElectronico);
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
        public void EliminarCliente(int id)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("DELETE FROM Clientes WHERE idCliente = @idBuscado", sqlConnection);
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
        /// <summary>
        /// Lee la base de datos del cilindro utilizando una query y establece cada dato que lee de ella en un cilindro
        /// luego lo agrega a una lista de cilindros. Al terminar de leer y agregar cierra la conexion
        /// </summary>
        /// <returns>La lista de los cilindros leidos</returns>
        public List<Cilindro> LeerCilindro()
        {
            List<Cilindro> lista = new List<Cilindro>();
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Select * FROM Cilindros", sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                StringBuilder stringBuilder = new StringBuilder();

                while (reader.Read())
                {
                    int idCilindro = reader.GetInt32(0);
                    int tamanioCilindro = reader.GetInt32(1);
                    int tipoCilindro = reader.GetInt32(2);
                    Cilindro cilindro = new Fisica();
                    Cilindro.ETipoResistencia resistencia = (Cilindro.ETipoResistencia)tipoCilindro;
                    switch (tipoCilindro)
                    {
                        case 0:
                            cilindro = new Fisica(idCilindro,tamanioCilindro, resistencia);
                            break;
                        case 1:
                            cilindro = new Quimica(idCilindro,tamanioCilindro, resistencia);
                            break;
                        case 2:
                            cilindro = new Termica(idCilindro,tamanioCilindro, resistencia);
                            break;
                    }

                    lista.Add(cilindro);
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
        #endregion
    }
}
