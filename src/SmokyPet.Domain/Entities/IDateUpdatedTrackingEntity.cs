using System;

namespace SmokyPet.Domain.Entities
{
    public interface IDateUpdatedTrackingEntity
    {
        DateTime DateUpdated { get; }
    }
}
