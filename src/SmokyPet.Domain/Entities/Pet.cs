using System;
using System.Collections.Generic;

namespace SmokyPet.Domain.Entities
{
    public class Pet : Entity, IDateTrackingEntity
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateUpdated { get; private set; }

        private readonly List<Owner> _owners = new();
        public IReadOnlyCollection<Owner> Owners => _owners;

        public Pet(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        public void Update(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        public void AddOwner(Owner owner)
        {
            _owners.Add(owner);
        }
    }
}
