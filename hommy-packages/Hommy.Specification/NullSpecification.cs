using System;
using System.Linq.Expressions;

namespace Hommy.Specification
{
    public sealed class NullSpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> Predicate { get; }
    }
}
