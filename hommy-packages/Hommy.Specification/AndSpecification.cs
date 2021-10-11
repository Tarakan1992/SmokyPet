using System;
using System.Linq;
using System.Linq.Expressions;

namespace Hommy.Specification
{
    public sealed class AndSpecification<T> : CompositeSpecification<T>
    {
        private readonly Lazy<Expression<Func<T, bool>>> predicate;

        public override Expression<Func<T, bool>> Predicate => predicate.Value;

        private Expression<Func<T, bool>> BuildPredicate()
        {
            var firstSpecification = Specifications.First();

            if (Specifications.Length == 1)
            {
                return firstSpecification.Predicate;
            }

            var currentPredicate = firstSpecification.Predicate;

            foreach (var specification in Specifications.Skip(1))
            {
                if (currentPredicate is null)
                {
                    if (specification.Predicate is not null)
                    {
                        currentPredicate = specification.Predicate;
                    }
                }
                else
                {
                    if (specification.Predicate is not null)
                    {
                        currentPredicate = And(currentPredicate, specification.Predicate);
                    }
                }
            }

            return currentPredicate;
        }

        public AndSpecification(params Specification<T>[] specifications) : base(specifications)
        {
            predicate = new Lazy<Expression<Func<T, bool>>>(() => BuildPredicate());
        }

        private Expression<Func<T, bool>> And(Expression<Func<T, bool>> left, Expression<Func<T, bool>> right)
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            var visitor = new SwapVisitor(left.Parameters[0], right.Parameters[0]);
            var binaryExpression = Expression.AndAlso(visitor.Visit(left.Body), right.Body);
            var lambda = Expression.Lambda<Func<T, bool>>(binaryExpression, right.Parameters);
            return lambda;
        }
    }
}
