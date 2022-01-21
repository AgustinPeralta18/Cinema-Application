using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Application
{
    public partial class frmRegistro : Form
    {
        public frmRegistro()
        {
            InitializeComponent();
        }

        private void txtUser_Click(object sender, EventArgs e)
        {
                
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //creo una instancia de la clase usuario, les estamos asignando los valores de las cajas de texto
            
            Usuarios usuario = new Usuarios();
            usuario.Usuario = txtUsuario.Text;
            usuario.Password = txtPassword.Text;
            usuario.Nombre = txtNombre.Text;
            usuario.ConPassword = txtConPassword.Text;

            
            //try para verificar errores
            try {

                //este objeto va a llevar los valores de los campos de usuario, password, etc. Asi validamos que todo este
                //correcto
                Control control = new Control();
                string respuesta = control.ctrlRegistro(usuario);

                //validacion de problemas 
                if(respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Usuario registrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //Esto es para que aparezca el Iniciar sesion si es que ya tenemos cuenta
            new Login().Show();
            this.Hide();
        }
    }
}
