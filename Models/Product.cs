using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkPagination.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName ="money")]
        public decimal Price { get; set; }  
    }
}
