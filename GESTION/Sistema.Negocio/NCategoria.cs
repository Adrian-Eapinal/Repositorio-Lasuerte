using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sistema.Datoss;
using Sistema.Entidades;

namespace Sistema.Negocio
{
    public class NCategoria
    {
        public static DataTable Listar()
        {
            DCategoria Datos = new DCategoria();
            return Datos.Listar();
        }

        public static DataTable Buscar(string valor)
        {
            DCategoria Datos = new DCategoria();
            return Datos.Buscar(valor);
        }
        public static string Insertar(string Nombre,string Descripcion)
        {
            DCategoria Datos = new DCategoria();
            string Existe = Datos.Existe(Nombre);
            if (Existe.Equals("1"))
            {
                return "La categoria ya existe";
            }
            else
            {
                Categoria obj = new Categoria();
                obj.Nombre = Nombre;
                obj.Descripcion = Descripcion;
                return Datos.Insertar(obj);// para enviarle el objeto crado que instancia a la categoria
            }
           
        }
        public static string Actualizar(int Id,string NombreAnt, string Nombre, String Descripcion)
        {
            DCategoria Datos = new DCategoria();
            if (NombreAnt.Equals(Nombre))
            {
                Categoria obj = new Categoria();
                obj.IdCategoria = Id;
                obj.Nombre = Nombre;
                obj.Descripcion = Descripcion;
                return Datos.Actualizar(obj);
            }
            else
            {
                string Existe = Datos.Existe(Nombre);
                if (Existe.Equals("1"))
                {
                    return "La categoria ya existe";
                }
                else
                {
                    Categoria obj = new Categoria();
                    obj.IdCategoria = Id;
                    obj.Nombre = Nombre;
                    obj.Descripcion = Descripcion;
                    return Datos.Actualizar(obj);
                }
            }
           
            

        }
        public static string Eliminar(int Id)
        {
            DCategoria Datos = new DCategoria();
            return Datos.Eliminar(Id);
        }
        public static string Activar(int Id)
        {
            DCategoria Datos = new DCategoria();
            return Datos.Activar(Id);
        }
        public static string Desactivar(int Id)
        {
            DCategoria Datos = new DCategoria();
            return Datos.Desactivar(Id);
        }
    }
}
