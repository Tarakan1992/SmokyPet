using SmokyPet.Applicaiton.Common.Mapping;
using SmokyPet.Domain.Entities;

namespace SmokyPet.Applicaiton.Features.Pets.Models
{
    public class PetShortModel : IMapFrom<Pet>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
