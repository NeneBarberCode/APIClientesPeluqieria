using APIClientesPeluqueria.Models;
using System.ComponentModel.DataAnnotations;

namespace APIClientesPeluqueria.DTOs
{
    public class HaircutDTO
    {
      
        public required string Name { get; set; }
        public required decimal Cost { get; set; }
        
    }
}
