using SmokyPet.Applicaiton.Common.Mapping;
using SmokyPet.Applicaiton.Features.Pets.Models;
using SmokyPet.Domain.Entities;
using System.Collections.Generic;

namespace SmokyPet.Applicaiton.Features.Owners.Models
{
    public class OwnerModel : IMapFrom<Owner>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<PetShortModel> Pets { get; set; }
    }
}
