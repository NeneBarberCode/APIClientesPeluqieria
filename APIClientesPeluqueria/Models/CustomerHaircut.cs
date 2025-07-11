using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace APIClientesPeluqueria.Models
{
    [PrimaryKey (nameof(CurtomerId),nameof(HairCutId))]
    public class CustomerHaircut
    {
        public int CurtomerId { get; set; }
        public int HairCutId { get; set; }

        public Customer? Customer { get; set; }
        public HairCut? hairCut { get; set; }

        
    }
}
