using System.ComponentModel.DataAnnotations;

namespace APIClientesPeluqueria.DTOs
{
    public class HaircutsWithCustomers
    {
        public required string Name { get; set; }
        public required decimal Cost { get; set; }
        public List<string> Customers { get; set; }
    }
}
