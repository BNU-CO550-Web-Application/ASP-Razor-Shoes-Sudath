using System.ComponentModel.DataAnnotations;

namespace ASP_Razor_Shoes.Models
{
    public enum Brands
    {
        Adidas, Nike, Reebok, Puma, Salazenger, Karrimor, Skechers
    }
    public enum Styles
    {
        Casual, Running, Walking, Cricket
    }
    public enum Genders
    {
        Mens, Womens
    }

    public class Shoe
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }

        [Required]
        public Brands Brand { get; set; } = Brands.Reebok;
        
        [Required]
        public Styles Style { get; set; } = Styles.Casual;

        [Required]
        public Genders Gender { get; set; } = Genders.Mens;

        [Range(15.99, 100.99), Required]
        public decimal Price { get; set; }


    }
}
