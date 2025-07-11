using System.ComponentModel.DataAnnotations;

namespace APIClientesPeluqueria.Models
{
    public class HairCut
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del corte es requerido")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "El precio es requerio")]
        public required decimal Cost { get; set; }
        public List<CustomerHaircut> Customers { get; set; } = [];

    }
}
