using System.ComponentModel.DataAnnotations;

namespace food_delevery_google_auth_Final_V.Entity
{
    public class Admin
    {
        [Key]
        public int IdAdmin { get; set; }
        public string NomUtilisateur { get; set; }
        public string MotDePasse { get; set; }
        public string Email { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
