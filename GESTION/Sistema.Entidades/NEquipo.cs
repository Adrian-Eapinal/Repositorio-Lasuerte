

namespace Sistema.Entidades
{
   public  class NEquipo
    {
        public int IdEquipo { get; set }
        public int IdCategoria { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Serial { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public bool Estado { get; set; }
    }
}
