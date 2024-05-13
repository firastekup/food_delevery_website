using System.ComponentModel.DataAnnotations;

namespace food_delevery_google_auth_Final_V.Entity
{
    public class foodss
    {
        [Key]
        public int IdAliment { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public string Categorie { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
