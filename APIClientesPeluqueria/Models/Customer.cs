using System.ComponentModel.DataAnnotations;

namespace APIClientesPeluqueria.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public required string Name { get; set; }
        [Phone]
        public string? Phone { get; set; }
        public List<CustomerHaircut> haircuts { get; set; } = [];



    }
}
