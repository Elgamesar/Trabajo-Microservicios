using System.ComponentModel.DataAnnotations;

namespace MSProductDomain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required][StringLength(300)]
        public string Name { get; set; }
       
        [StringLength(4000)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio no puede ser menor o igual a cero")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }
    }
}