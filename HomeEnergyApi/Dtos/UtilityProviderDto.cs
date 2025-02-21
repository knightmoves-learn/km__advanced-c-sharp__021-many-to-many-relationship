using System.ComponentModel.DataAnnotations;

namespace HomeEnergyApi.Dtos
{
    public class UtilityProviderDto
    {
        [Required]
        public string Name { get; set;}
        [Required]
        public ICollection<string> ProvidedUtilities { get; set;}
    }
}
