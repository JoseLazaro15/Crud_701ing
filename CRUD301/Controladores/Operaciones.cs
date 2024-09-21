using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Crud_701ing.Controladores
{
    public class Operaciones
    {
        SqlConnection conn = new SqlConnection(@"server=DESKTOP-L5CNPHK; database=UTRNGAlumnos; user id=Gomix; password=123456;Integrated Security=True");

        public string insertar(string matricula, string nombrec, string telefono, string correoe)
        {
            int result = 0;
            string mensaje;
            string myInsertQuery1 = "INSERT INTO alumnos Values(@matricula, @nombrec, @telefono, @correoe)";
            SqlCommand myCommand1 = new SqlCommand(myInsertQuery1, conn);
            myCommand1.Parameters.Add("@matricula", SqlDbType.Int).Value = matricula;
            myCommand1.Parameters.Add("@nombrec", SqlDbType.VarChar).Value = nombrec;
            myCommand1.Parameters.Add("@telefono", SqlDbType.VarChar).Value = telefono;
            myCommand1.Parameters.Add("@correoe", SqlDbType.VarChar).Value = correoe;

            conn.Open();

            try
            {
                result = myCommand1.ExecuteNonQuery();
            }
            catch (Exception)
            {
                mensaje = "Ha ocurrido un error, verifique los datos";
            }

            if (result != 0)
            {
                 mensaje = "Se insertarón los datos";
            }
            else
            {
                 mensaje = "No se inserto el registro, verifique los datos";
            }
            conn.Close();
            return mensaje;
        }

        public string [] mostrar(string matricula)
        {
            string[] datos = new string[4];
            int result = 0;
            SqlCommand cmd5 = new SqlCommand("SELECT matricula,nombrec, telefono,correoe FROM alumnos WHERE matricula = @matricula ", conn);
            cmd5.Parameters.Add("@matricula", SqlDbType.Int).Value = matricula;
            conn.Open();
            try
            {
                SqlDataReader myreader5 = cmd5.ExecuteReader();
                while (myreader5.Read())

                    {
                    datos[0] = myreader5[0].ToString();
                    datos[1] = myreader5[1].ToString();
                    datos[2] = myreader5[2].ToString();
                    datos[3] = myreader5[3].ToString();
                    result = 1;

                }
                myreader5.Close();
                


            }
            catch (Exception)
            {
                datos = new string[] { "Error", "Ha ocurrido un error", "", "" };
            }

            finally
            {
                conn.Close();
            }

            if (result == 0)
            {
                datos = new string[] { "No encontrado", "No se encontraron los datos", "", "" };
            }

            return datos;

        }

        public string eliminar(string matricula)
        {
            int result = 0;
            string mensaje;
            SqlCommand cmd5 = new SqlCommand("DELETE FROM alumnos WHERE matricula = @matricula ", conn);
            cmd5.Parameters.Add("@matricula", SqlDbType.Int).Value = matricula;
            conn.Open();
            try
            {
                result = cmd5.ExecuteNonQuery();
            }
            catch (Exception)
            {
                mensaje = "Ha ocurrido un error, verifique los datos";
            }
            if (result != 0)
            {
                mensaje = "Se borrarón los datos";
            }
            else
            {
                mensaje = "No se borró el registro, verifique los datos";
            }
            conn.Close();
            return mensaje;
        }

        public string actualizar(string matricula, string nombrec, string telefono, string correoe)
        {
            int result = 0;
            string mensaje;
            string myQuery = "UPDATE alumnos SET matricula=@matricula,nombrec=@nombrec, telefono=@telefono, correoe=@correoe  WHERE matricula = @matricula ";
            SqlCommand myCommand = new SqlCommand(myQuery, conn);
            myCommand.Parameters.Add("@matricula", SqlDbType.Int).Value = matricula;
            myCommand.Parameters.Add("@nombrec", SqlDbType.VarChar).Value = nombrec;
            myCommand.Parameters.Add("@telefono", SqlDbType.VarChar).Value = telefono;
            myCommand.Parameters.Add("@correoe", SqlDbType.VarChar).Value = correoe;
            conn.Open();
            try
            {
                result = myCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
               mensaje = "Ha ocurrido un error, verifique los datos";
            }
            if (result != 0)
            {
                mensaje = "Se actualizarón los datos";
            }
            else
            {
                mensaje = "No se actualizarón el registro, verifique los datos";
            }
            conn.Close();
            return mensaje;
        }
    }
}