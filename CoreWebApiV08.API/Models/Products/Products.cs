using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreWebApiV08.API.Models.Products
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int id { get; set; }

        public string? Name { get; set; }

        public string? Category { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}
