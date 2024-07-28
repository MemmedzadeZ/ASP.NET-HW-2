using System.ComponentModel.DataAnnotations;

namespace ASP.NET_HW2.Entities
{
    public class Products
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Description is required")]
        public string Description { get; set; }
        [Range(100,2000,ErrorMessage = "Should be between 100-2000")]
        public double Price { get; set; }
        [Range(0, 100, ErrorMessage = "Should be between 0%-100%")]
        public double Discount { get; set; }

    }
}
