using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NUsuario
    {
        public static string Insertar(string nombre, string apellido, string ci, string correo, string edad, string accesso, string usuario, string estado, string contra)
        {
            DUsuarios Obj = new DUsuarios();
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Ci = ci;
            Obj.Correo = correo;
            Obj.Edad = edad;
            Obj.Acceso = accesso;
            Obj.Usuario = usuario;
            Obj.Contra = contra;
            Obj.Estado = estado;

            return Obj.Insertar(Obj);
        }
        public static string Editar(int idusuario, string nombre, string apellido, string ci, string correo, string edad, string accesso, string usuario, string estado, string contra)
        {
            DUsuarios Obj = new DUsuarios();
            Obj.IdUsuario = idusuario;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Ci = ci;
            Obj.Correo = correo;
            Obj.Edad = edad;
            Obj.Acceso = accesso;
            Obj.Usuario = usuario;
            Obj.Contra = contra;
            Obj.Estado = estado;

            return Obj.Editar(Obj);
        }
        public static string Eliminar(int idusuario)
        {
            DUsuarios Obj = new DUsuarios();
            Obj.IdUsuario = idusuario;

            return Obj.Eliminar(Obj);
        }
        public static DataTable Mostrar()
        {
            return new DUsuarios().Mostrar();
        }
        public static DataTable BuscarApellido(string textbuscar)
        {
            DUsuarios Obj = new DUsuarios();
            Obj.Textobuscar = textbuscar;
            return Obj.BuscarApellido(Obj);
        }

        public static DataTable BuscarNombre(string textbuscar)
        {
            DUsuarios Obj = new DUsuarios();
            Obj.Textobuscar = textbuscar;
            return Obj.BuscarNombre(Obj);
        }
        public static DataTable Login(string usuario, string contra)
        {
            DUsuarios Obj = new DUsuarios();
            Obj.Usuario = usuario;
            Obj.Contra = contra;
            return Obj.Login(Obj);
        }
    }
}
