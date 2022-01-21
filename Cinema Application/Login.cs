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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            try
            {
                Control ctrl = new Control();
                string respuesta = ctrl.ctrlLogin(usuario, password);
                //if para verificar si mi respuesta es mayor a 0, o sea, si el metodo me arroja un dato en la respuesta
                if(respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //Si esta todo correcto mostramos la pagina principal
                    Principal frm = new Principal();
                    frm.Visible = true;
                    //con este this hacemos que la ventana de ingresar se oculte
                    this.Visible = false;
                }


            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            //Esto es para que aparezca el registro cuando tocamos registrarnos
            new frmRegistro().Show();
            this.Hide();
        }
    }
}
