using System.ComponentModel.DataAnnotations;

namespace APIClientesPeluqueria.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public required string Name { get; set; }
        [Phone]
        public string? Phone { get; set; }

        public List<int> Cutsid {  get; set; }= new List<int>();
    }
}
