using SmokyPet.Applicaiton.Common.Mapping;
using SmokyPet.Domain.Entities;

namespace SmokyPet.Applicaiton.Features.Owners.Models
{
    public class OwnerShortModel : IMapFrom<Owner>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
