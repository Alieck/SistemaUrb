using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DUsuarios
    {
        private int _IdUsuario;
        private string _Nombre;
        private string _Apellido;
        private string _Ci;
        private string _Correo;
        private string _Edad;
        private string _Acceso;
        private string _Usuario;
        private string _Contra;
        private string _Estado;
        private string _Textobuscar;

        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Ci { get => _Ci; set => _Ci = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string Edad { get => _Edad; set => _Edad = value; }
        public string Acceso { get => _Acceso; set => _Acceso = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Contra { get => _Contra; set => _Contra = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public string Textobuscar { get => _Textobuscar; set => _Textobuscar = value; }

        public DUsuarios()
        {

        }
        public DUsuarios(int idusuario, string nombre, string apellido, string ci, string correo, string edad, string acceso, string usuario, string contra, string estado, string textobuscar)
        {
            this.IdUsuario = idusuario;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Ci = ci;
            this.Correo = correo;
            this.Edad = edad;
            this.Acceso = acceso;
            this.Usuario = usuario;
            this.Contra = contra;
            this.Estado = estado;
            this.Textobuscar = textobuscar;
        }
        public string Insertar(DUsuarios Usuarios)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_insertar_usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdtrabajador = new SqlParameter();
                ParIdtrabajador.ParameterName = "@idusuario";
                ParIdtrabajador.SqlDbType = SqlDbType.Int;
                ParIdtrabajador.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdtrabajador);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 20;
                ParNombre.Value = Usuarios.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 20;
                ParApellido.Value = Usuarios.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                SqlParameter ParCi = new SqlParameter();
                ParCi.ParameterName = "@ci";
                ParCi.SqlDbType = SqlDbType.VarChar;
                ParCi.Size = 20;
                ParCi.Value = Usuarios.Ci;
                SqlCmd.Parameters.Add(ParCi);

                SqlParameter ParCorreo = new SqlParameter();
                ParCorreo.ParameterName = "@correo";
                ParCorreo.SqlDbType = SqlDbType.VarChar;
                ParCorreo.Size = 20;
                ParCorreo.Value = Usuarios.Correo;
                SqlCmd.Parameters.Add(ParCorreo);

                SqlParameter ParEdad = new SqlParameter();
                ParEdad.ParameterName = "@edad";
                ParEdad.SqlDbType = SqlDbType.VarChar;
                ParEdad.Size = 20;
                ParEdad.Value = Usuarios.Edad;
                SqlCmd.Parameters.Add(ParEdad);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 20;
                ParAcceso.Value = Usuarios.Acceso;
                SqlCmd.Parameters.Add(ParAcceso);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Usuarios.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParContra = new SqlParameter();
                ParContra.ParameterName = "@contra";
                ParContra.SqlDbType = SqlDbType.VarChar;
                ParContra.Size = 20;
                ParContra.Value = Usuarios.Contra;
                SqlCmd.Parameters.Add(ParContra);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Usuarios.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se puedo Registrar";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        public string Editar(DUsuarios Usuarios)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_editar_usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdtrabajador = new SqlParameter();
                ParIdtrabajador.ParameterName = "@idusuario";
                ParIdtrabajador.SqlDbType = SqlDbType.Int;
                ParIdtrabajador.Value = Usuarios.IdUsuario;
                SqlCmd.Parameters.Add(ParIdtrabajador);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 20;
                ParNombre.Value = Usuarios.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 20;
                ParApellido.Value = Usuarios.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                SqlParameter ParCi = new SqlParameter();
                ParCi.ParameterName = "@ci";
                ParCi.SqlDbType = SqlDbType.VarChar;
                ParCi.Size = 20;
                ParCi.Value = Usuarios.Ci;
                SqlCmd.Parameters.Add(ParCi);

                SqlParameter ParCorreo = new SqlParameter();
                ParCorreo.ParameterName = "@correo";
                ParCorreo.SqlDbType = SqlDbType.VarChar;
                ParCorreo.Size = 20;
                ParCorreo.Value = Usuarios.Correo;
                SqlCmd.Parameters.Add(ParCorreo);

                SqlParameter ParEdad = new SqlParameter();
                ParEdad.ParameterName = "@edad";
                ParEdad.SqlDbType = SqlDbType.VarChar;
                ParEdad.Size = 20;
                ParEdad.Value = Usuarios.Edad;
                SqlCmd.Parameters.Add(ParEdad);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 20;
                ParAcceso.Value = Usuarios.Acceso;
                SqlCmd.Parameters.Add(ParAcceso);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Usuarios.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParContra = new SqlParameter();
                ParContra.ParameterName = "@contra";
                ParContra.SqlDbType = SqlDbType.VarChar;
                ParContra.Size = 20;
                ParContra.Value = Usuarios.Contra;
                SqlCmd.Parameters.Add(ParContra);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 20;
                ParEstado.Value = Usuarios.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se puedo Actualizar";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }
        public string Eliminar(DUsuarios Usuarios)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_eliminar_usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdtrabajador = new SqlParameter();
                ParIdtrabajador.ParameterName = "@idusuario";
                ParIdtrabajador.SqlDbType = SqlDbType.Int;
                ParIdtrabajador.Value = Usuarios.IdUsuario;
                SqlCmd.Parameters.Add(ParIdtrabajador);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se pudo Eliminar";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("usuario");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_mostrar_usuarios";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
        public DataTable BuscarApellido(DUsuarios Usuarios)
        {
            DataTable DtResultado = new DataTable("usuario");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_buscar_usuario_apellido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Usuarios.Textobuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
        public DataTable BuscarNombre(DUsuarios Usuarios)
        {
            DataTable DtResultado = new DataTable("usuario");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_buscar_usuario_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Usuarios.Textobuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public DataTable Login(DUsuarios Usuarios)
        {
            DataTable DtResultado = new DataTable("usuario");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "SLogin";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Usuarios.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParContra = new SqlParameter();
                ParContra.ParameterName = "@contra";
                ParContra.SqlDbType = SqlDbType.VarChar;
                ParContra.Size = 20;
                ParContra.Value = Usuarios.Contra;
                SqlCmd.Parameters.Add(ParContra);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {

                DtResultado = null;
            }
            return DtResultado;
        }


    }

}
