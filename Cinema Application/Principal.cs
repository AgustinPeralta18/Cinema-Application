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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            personalizarDiseño();
        }


        //con este metodo personalizamos el disenio el submenu
        private void personalizarDiseño ()
        {
            panelSubMenuReserva.Visible = false;
        }

        //aca ocultamos el submenu
        private void ocultarSubMenu()
        {
            if (panelSubMenuReserva.Visible == true)
            {
                panelSubMenuReserva.Visible = false;
            }
        }

        private void mostrarSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false)
            {
                ocultarSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubMenuReserva);
        }

        //esta funcion lo que hace es abrir el formularioPeliculas
        private void abrirPanelHijo(object formHija)
        {
            //En este if lo que hace es preguntar si existe algun control en el interior del panel, de ser verdadero se elimina.
            if (this.panelHijo.Controls.Count > 0)
            {
                this.panelHijo.Controls.RemoveAt(0);
                Form hija = formHija as Form; //En esta linea fue creado un formulario con nombre "hija" y decimos que sea igual al objeto
                //que recibe la funcion y a este objeto lo convertimos a un formulario con la palabra "as".

                hija.TopLevel = false; //con esto cambiamos las propiedades del formulario y haciendolo falso decimos que no es un formulario
                //con nivel superior y es secundario.

                hija.Dock = DockStyle.Fill;//Esto hace acoplar todo el panel contenedor

                //por ultimo se agrega al panel
                this.panelHijo.Controls.Add(hija);

                //y establecemos la instancia como contenedor de datos de nuestro panel.
                this.panelHijo.Tag = hija;

                //lo mostramos
                hija.Show();

            }
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            abrirPanelHijo(new FormularioPeliculas());
            
        }

        
    }
}
