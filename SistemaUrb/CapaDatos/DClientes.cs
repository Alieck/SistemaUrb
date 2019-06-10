using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DClientes
    {
        private int _IdCliente;
        private string _Ci;
        private string _Nombre;
        private string _Apellido;
        private int _Edad;
        private int _Celular;
        private string _Correo;
        private string _Genero;
        private string _Textobuscar;

        public int IdCliente { get => _IdCliente; set => _IdCliente = value; }
        public string Ci { get => _Ci; set => _Ci = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public int Edad { get => _Edad; set => _Edad = value; }
        public int Celular { get => _Celular; set => _Celular = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public string Genero { get => _Genero; set => _Genero = value; }
        public string Textobuscar { get => _Textobuscar; set => _Textobuscar = value; }

        public DClientes() { }
        public DClientes(int idcliente,string ci,string nombre,string apellido,int edad,int celular,string correo,string genero,string textobuscar)
        {
            this.IdCliente = idcliente;
            this.Ci = ci;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
            this.Celular = celular;
            this.Correo = correo;
            this.Genero = genero;
            this.Textobuscar = textobuscar;
        }
        public string Insertar(DClientes Clientes)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_insertar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdtrabajador = new SqlParameter();
                ParIdtrabajador.ParameterName = "@idcliente";
                ParIdtrabajador.SqlDbType = SqlDbType.Int;
                ParIdtrabajador.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdtrabajador);

                SqlParameter ParCi = new SqlParameter();
                ParCi.ParameterName = "@ci";
                ParCi.SqlDbType = SqlDbType.Int;
                ParCi.Value = Clientes.Ci;
                SqlCmd.Parameters.Add(ParCi);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 30;
                ParNombre.Value = Clientes.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 30;
                ParApellido.Value = Clientes.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                SqlParameter ParEdad = new SqlParameter();
                ParEdad.ParameterName = "@edad";
                ParEdad.SqlDbType = SqlDbType.Int;
                ParEdad.Value = Clientes.Ci;
                SqlCmd.Parameters.Add(ParEdad);

                SqlParameter ParCelular = new SqlParameter();
                ParCelular.ParameterName = "@celular";
                ParCelular.SqlDbType = SqlDbType.VarChar;
                ParCelular.Value = Clientes.Celular;
                SqlCmd.Parameters.Add(ParCelular);

                SqlParameter ParCorreo = new SqlParameter();
                ParCorreo.ParameterName = "@correo";
                ParCorreo.SqlDbType = SqlDbType.VarChar;
                ParCorreo.Size = 30;
                ParCorreo.Value = Clientes.Correo;
                SqlCmd.Parameters.Add(ParCorreo);

                SqlParameter ParGenero = new SqlParameter();
                ParGenero.ParameterName = "@genero";
                ParGenero.SqlDbType = SqlDbType.VarChar;
                ParGenero.Size = 30;
                ParGenero.Value = Clientes.Genero;
                SqlCmd.Parameters.Add(ParGenero);

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
        public string Editar(DClientes Clientes)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_editar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdtrabajador = new SqlParameter();
                ParIdtrabajador.ParameterName = "@idcliente";
                ParIdtrabajador.SqlDbType = SqlDbType.Int;
                ParIdtrabajador.Value = Clientes.IdCliente;
                SqlCmd.Parameters.Add(ParIdtrabajador);

                SqlParameter ParCi = new SqlParameter();
                ParCi.ParameterName = "@ci";
                ParCi.SqlDbType = SqlDbType.Int;
                ParCi.Value = Clientes.Ci;
                SqlCmd.Parameters.Add(ParCi);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 30;
                ParNombre.Value = Clientes.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellido = new SqlParameter();
                ParApellido.ParameterName = "@apellido";
                ParApellido.SqlDbType = SqlDbType.VarChar;
                ParApellido.Size = 30;
                ParApellido.Value = Clientes.Apellido;
                SqlCmd.Parameters.Add(ParApellido);

                SqlParameter ParEdad = new SqlParameter();
                ParEdad.ParameterName = "@edad";
                ParEdad.SqlDbType = SqlDbType.Int;
                ParEdad.Value = Clientes.Ci;
                SqlCmd.Parameters.Add(ParEdad);

                SqlParameter ParCelular = new SqlParameter();
                ParCelular.ParameterName = "@celular";
                ParCelular.SqlDbType = SqlDbType.VarChar;
                ParCelular.Value = Clientes.Celular;
                SqlCmd.Parameters.Add(ParCelular);

                SqlParameter ParCorreo = new SqlParameter();
                ParCorreo.ParameterName = "@correo";
                ParCorreo.SqlDbType = SqlDbType.VarChar;
                ParCorreo.Size = 30;
                ParCorreo.Value = Clientes.Correo;
                SqlCmd.Parameters.Add(ParCorreo);

                SqlParameter ParGenero = new SqlParameter();
                ParGenero.ParameterName = "@genero";
                ParGenero.SqlDbType = SqlDbType.VarChar;
                ParGenero.Size = 30;
                ParGenero.Value = Clientes.Genero;
                SqlCmd.Parameters.Add(ParGenero);

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
        public string Eliminar(DClientes Clientes)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_eliminar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdtrabajador = new SqlParameter();
                ParIdtrabajador.ParameterName = "@idcliente";
                ParIdtrabajador.SqlDbType = SqlDbType.Int;
                ParIdtrabajador.Value = Clientes.IdCliente;
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
            DataTable DtResultado = new DataTable("cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_mostrar_cliente";
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
        public DataTable BuscarApellido(DClientes Clientes)
        {
            DataTable DtResultado = new DataTable("cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_buscar_cliente_apellido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Clientes.Textobuscar;
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
        public DataTable BuscarNombre(DClientes Clientes)
        {
            DataTable DtResultado = new DataTable("cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_buscar_cliente_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Clientes.Textobuscar;
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
    }
}
