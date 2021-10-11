using System;

namespace SmokyPet.Domain.Entities
{
    public interface IDateCreatedTrackingEntity
    {
        DateTime DateCreated { get; }
    }
}
