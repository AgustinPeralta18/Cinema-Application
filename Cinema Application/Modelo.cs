
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Application
{
    //en esta clase vamos a crear un metodo que nos va a ayudar a registrar al usuario
    class Modelo
    {

        //es int ya que nos va a retornar si se registro el usuario o cuantas filas se ingreso a nuestra tabla
        public int registro(Usuarios usuario)
        {
            // hacemos esto para que lo podamos usar automaticamente y no estar mandando parametros
            // cada vez que hagamos una transaccion
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            //insercion a mysql
            string sql = "INSERT INTO usuarios (usuario, password, nombre, id_tipo) VALUES(@usuario, @password, @nombre, @id_tipo)";

            //aca se crea un comando para mysql para la consulta con la base de datos

            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", usuario.Usuario);
            comando.Parameters.AddWithValue("@password", usuario.Password);
            comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
            comando.Parameters.AddWithValue("@id_tipo", 1);

            //aca nos va a regresar el numero de filas que se hayan insertado a la tabla
            int resultado = comando.ExecuteNonQuery();
            return resultado;

        }

        //verificacion si existe o no el usuario
        public bool existeUsuario(string usuario)
        {
            //con este mysqldatareader traemos los datos 
            MySqlDataReader reader;

            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            
            string sql = "SELECT id FROM usuarios WHERE usuario LIKE @usuario";

            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", usuario);

            reader = comando.ExecuteReader();

            if (reader.HasRows) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
