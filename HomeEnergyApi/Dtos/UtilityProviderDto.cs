using System.ComponentModel.DataAnnotations;

namespace HomeEnergyApi.Dtos
{
    public class UtilityProviderDto
    {
        public required string Name { get; set;}
        public required ICollection<string> ProvidedUtilities { get; set;}
    }
}
