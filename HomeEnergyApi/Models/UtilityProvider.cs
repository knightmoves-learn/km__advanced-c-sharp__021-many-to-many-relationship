using System.ComponentModel.DataAnnotations;

namespace HomeEnergyApi.Models
{
    public class UtilityProvider
    {
        public int Id {get; set;}

        [Required]
        public string Name {get; set;}

        [Required]
        public ICollection<string> ProvidedUtilities {get; set;}
        
        [Required]
        public ICollection<HomeUtilityProvider> HomeUtilityProviders {get; set;}
    }
}
