using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace food_delevery_google_auth_Final_V.Entity
{
    public class Commandef
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCommande { get; set; }

        public string ClientName { get; set; }
        public string telclient { get; set; }

        public string nomlivreur { get; set; }
        public DateTime DateCommande { get; set; }
        public string food { get; set; }
    }
}
