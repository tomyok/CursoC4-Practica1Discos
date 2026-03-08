using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Discos_EF.Models
{
    public class Disco
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public int CantidadCanciones { get; set; }
        public string UrlTapa { get; set; }
        public Estilo? Estilo { get; set; }
        public int? EstiloId { get; set; }
        public TipoEdicion? TipoEdicion { get; set; }
        public int? TipoEdicionId { get; set; }
    }
}
