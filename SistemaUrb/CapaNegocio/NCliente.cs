using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NCliente
    {
        public static string Insertar(string ci,string nombre,string apellido,int edad,int celular,string correo,string genero)
        {
            DClientes Obj = new DClientes();
            Obj.Ci = ci;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Edad = edad;
            Obj.Celular = celular;
            Obj.Correo = correo;
            Obj.Genero = genero;

            return Obj.Insertar(Obj);
        }
        public static string Editar(int idcliente, string ci, string nombre, string apellido, int edad, int celular, string correo, string genero)
        {
            DClientes Obj = new DClientes();
            Obj.IdCliente = idcliente;
            Obj.Ci = ci;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Edad = edad;
            Obj.Celular = celular;
            Obj.Correo = correo;
            Obj.Genero = genero;

            return Obj.Editar(Obj);
        }
        public static string Eliminar(int idcliente)
        {
            DClientes Obj = new DClientes();
            Obj.IdCliente = idcliente;

            return Obj.Eliminar(Obj);
        }
        public static DataTable Mostrar()
        {
            return new DClientes().Mostrar();
        }
        public static DataTable BuscarApellido(string textbuscar)
        {
            DClientes Obj = new DClientes();
            Obj.Textobuscar = textbuscar;
            return Obj.BuscarApellido(Obj);
        }

        public static DataTable BuscarNombre(string textbuscar)
        {
            DClientes Obj = new DClientes();
            Obj.Textobuscar = textbuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
