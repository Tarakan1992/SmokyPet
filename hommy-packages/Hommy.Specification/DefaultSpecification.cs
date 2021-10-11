using System;
using System.Linq.Expressions;

namespace Hommy.Specification
{
    public class DefaultSpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> Predicate => e => true;
    }
}
