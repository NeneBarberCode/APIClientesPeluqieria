namespace APIClientesPeluqueria.DTOs
{
    public class CustomersWithHaircutsDTO
    {

        public string Name { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public List<string> Cuts { get; set; } = [];
    }
}
