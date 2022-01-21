using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Application
{
    //En la clase control hacemos validaciones para verificar que los datos que este ingresando el usuario sean correcto
    class Control
    {
        //conexion entre formulario y el modelo
        //control de errores
        public string ctrlRegistro(Usuarios usuario)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";

            //control de que todos los campos esten llenos
            if (string.IsNullOrEmpty(usuario.Usuario) || string.IsNullOrEmpty(usuario.Password) ||
                string.IsNullOrEmpty(usuario.Nombre) || string.IsNullOrEmpty(usuario.ConPassword))
            {
                respuesta = "Complete todos los campos";
            }
            else
            {
                //control de las contrasenias
                if (usuario.Password == usuario.ConPassword)
                {
                    if (modelo.existeUsuario(usuario.Usuario))
                    {
                        respuesta = "El usuario ya existe";
                    }
                    else
                    {
                        usuario.Password = generarSHA1(usuario.Password);
                        modelo.registro(usuario);
                    }
                }
                else
                {
                    respuesta = "Las contraseñas no coinciden";
                }
            }

            return respuesta;

        }

        public string ctrlLogin(string usuario, string password)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";
            Usuarios datosUsuario = null;

            if(string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                respuesta = "Debe llenar todos los campos";
            }
            else
            {
                datosUsuario = modelo.porUsuario(usuario);
                
                //este if es para verificar si el usuario esta registrado en la base de datos
                if(datosUsuario == null)
                {
                    respuesta = "El usuario no existe";
                }
                else
                {
                    //En este if verificamos si la contraseña es correcta pero como está cifrada la contraseña en la base
                    //de datos tenemos que hacer la conversion llamando al metodo SHA1
                    if(datosUsuario.Password != generarSHA1(password))
                    {
                        respuesta = "El usuario y/o contraseña no coinciden";
                    }
                }
            }
            return respuesta;
        }

        private string generarSHA1(string cadena)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            result = sha.ComputeHash(data);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }

            return sb.ToString();


        }
    }
}
