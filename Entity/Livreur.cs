using System.ComponentModel.DataAnnotations;

namespace food_delevery_google_auth_Final_V.Entity
{
    public class Livreur
    {
        [Key]
        public int IdLivreur { get; set; }
        public string Nom { get; set; }
        public string Vehicule { get; set; }
        public string ZoneLivraison { get; set; }
        public bool Disponibilite { get; set; }
    }
}
