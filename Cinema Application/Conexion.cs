using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Application
{
    class Conexion
    {

        /*En esta clase vamos a hacer una conexion a mysql y asignar los parametros con los cuales vamos a 
         poder conectarnos a mysql */
        public static MySqlConnection getConexion()
        {
            string servidor = "localhost"; //ruta de mysql
            string puerto = "3306"; //puerto mysql
            string usuario = "root"; //usuario de mysql
            string password = "Agusxnz12"; //contrasenia
            string bd = "sistema_usuarios"; //nombre de la base de datos de mysql

            string cadenaConexion = "server=" + servidor + "; port=" + puerto + "; user id=" + usuario + 
                "; password=" + password + "; database=" + bd;

            // mysqlconnection para generar la conexion a la base de datos
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);

            //por ultimo retornamos conexion
            return conexion;

        }


    }
}
