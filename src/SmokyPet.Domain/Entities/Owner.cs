using System;
using System.Collections.Generic;

namespace SmokyPet.Domain.Entities
{
    public class Owner : Entity, IDateTrackingEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        private readonly List<Pet> _pets = new();
        public IReadOnlyCollection<Pet> Pets => _pets;
        public DateTime DateCreated { get; private set; }
        public DateTime DateUpdated { get; private set; }

        public Owner(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void AddPet(Pet pet)
        {
            _pets.Add(pet);
        }

        public void Update(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
