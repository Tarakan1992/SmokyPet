using System;
using System.Linq;
using System.Linq.Expressions;

namespace Hommy.Specification
{
    public sealed class NotSpecification<T> : Specification<T>
    {
        private readonly Lazy<Expression<Func<T, bool>>> predicate;
        public override Expression<Func<T, bool>> Predicate => predicate.Value;

        private readonly Specification<T> _left;

        private Expression<Func<T, bool>> BuildPredicate()
        {
            return Not(_left.Predicate);
        }

        public NotSpecification(Specification<T> left)
        {
            _left = left ?? throw new ArgumentNullException(nameof(left));

            predicate = new Lazy<Expression<Func<T, bool>>>(() => BuildPredicate());
        }

        private static Expression<Func<T, bool>> Not(Expression<Func<T, bool>> left)
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            var notExpression = Expression.Not(left.Body);
            var lambda = Expression.Lambda<Func<T, bool>>(notExpression, left.Parameters.Single());
            return lambda;
        }
    }
}
