using System;
using System.Linq.Expressions;

namespace Hommy.Specification
{
    public class Specification
    {
        public static Specification<T> Create<T>()
        {
            return new DefaultSpecification<T>();
        }

        private Specification()
        {
        }
    }
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> Predicate { get; }

        private Lazy<Func<T, bool>> _func;

        protected Specification()
        {
            _func = new Lazy<Func<T, bool>>(() => Predicate.Compile());
        }

        public virtual bool IsSatisfiedBy(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return _func.Value(entity);
        }

        public Specification<T> And(Specification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public Specification<T> And(Expression<Func<T, bool>> right)
        {
            return new AndSpecification<T>(this, new ExpressionSpecification<T>(right));
        }

        public Specification<T> Or(Specification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }

        public Specification<T> Or(Expression<Func<T, bool>> right)
        {
            return new OrSpecification<T>(this, new ExpressionSpecification<T>(right));
        }

        public Specification<T> Not()
        {
            return new NotSpecification<T>(this);
        }

        public static bool operator false(Specification<T> spec)
        {
            return false;
        }

        public static bool operator true(Specification<T> spec)
        {
            return false;
        }

        public static Specification<T> operator &(Specification<T> spec1, Specification<T> spec2)
            => spec1.And(spec2);

        public static Specification<T> operator |(Specification<T> spec1, Specification<T> spec2)
            => spec1.Or(spec2);

        public static Specification<T> operator !(Specification<T> spec)
            => spec.Not();

        public static implicit operator Specification<T>(Expression<Func<T, bool>> expression)
        {
            return new ExpressionSpecification<T>(expression);
        }
    }
}
