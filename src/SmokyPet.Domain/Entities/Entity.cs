namespace SmokyPet.Domain.Entities
{
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; }
    }

    public abstract class Entity : Entity<int>, IEntity
    {
    }
}
