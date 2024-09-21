using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using Crud_701ing.Controladores;
using System.Web.UI.WebControls;

namespace Crud_701ing
{
    public partial class Alumnos : System.Web.UI.Page
    {
        Operaciones metodos = new Operaciones();  
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string matricula = TextBox1.Text;
            string[] datos = metodos.mostrar(matricula);

            if (datos[0] == "Error")
            {
                Label5.Text = datos[1]; // Mostrar mensaje de error
            }

            else if (datos[0] == "No encontrado")
            {
                Label5.Text = datos[1]; // Mostrar mensaje de no encontrado
            }
            else
            {
                // Asignar los datos a los TextBox
                TextBox1.Text = datos[0]; // Matricula
                TextBox2.Text = datos[1]; // Nombre
                TextBox3.Text = datos[2]; // Telefono
                TextBox4.Text = datos[3]; // Correo

                // Limpiar Label5 en caso de éxito
                Label5.Text = "";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Label5.Text = metodos.insertar(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text);

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Label5.Text = metodos.eliminar(TextBox1.Text);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Label5.Text = metodos.actualizar(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text);

        }
    }
}