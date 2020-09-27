using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entidades
{
   public class Categoria
    {
        //propiedades de los campos de la tabla categoria
        public int IdCategoria { get; set; }// el metodo get me va a permitir obtener los valores almacenados en la propiedad
        public string Nombre { get; set; }// El metodo set me va a permitir almacenar valores en las propiedades 
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

    }
}
