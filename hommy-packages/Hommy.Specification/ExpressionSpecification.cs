using System;
using System.Linq.Expressions;

namespace Hommy.Specification
{
    public class ExpressionSpecification<T> : Specification<T>
    {
        public override Expression<Func<T, bool>> Predicate { get; }

        public ExpressionSpecification(Expression<Func<T, bool>> predicate)
        {
            Predicate = predicate;
        }
    }
 }
