using System;
using System.Linq;

namespace Hommy.Specification
{
    public abstract class CompositeSpecification<T> : Specification<T>
    {
        protected readonly Specification<T>[] Specifications;

        protected CompositeSpecification(params Specification<T>[] specifications)
        {
            if (specifications == null || !specifications.Any())
            {
                throw new ArgumentNullException(nameof(specifications));
            }

            Specifications = specifications;
        }
    }
}
