using SmokyPet.Applicaiton.Common.Mapping;
using SmokyPet.Applicaiton.Features.Owners.Models;
using SmokyPet.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SmokyPet.Applicaiton.Features.Pets.Models
{
    public class PetModel : IMapFrom<Pet>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public List<OwnerShortModel> Owners { get; set; }
    }
}
