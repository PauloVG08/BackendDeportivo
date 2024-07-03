namespace ExamenAPI.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }

        public string Nombre { get; set; }

        public string Categoria { get; set; }

        public double Precio { get; set; }

        public string Imagen {  get; set; }

        public string Descripcion { get; set; }
    }
}
