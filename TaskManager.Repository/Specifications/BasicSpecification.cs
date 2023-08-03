using System;
using System.Linq.Expressions;
using TaskManager.Repository.Interfaces;

namespace TaskManager.Repository.Specifications
{
    public class BasicSpecification<T> : ISpecification<T>
    {
        public Expression<Func<T, bool>>? Criteria { get; }

        public List<Expression<Func<T, object>>> Includes => new();

        public List<string> IncludesString => new();

        public Expression<Func<T, object>>? OrderByExpression { get; private set; }

        public Expression<Func<T, object>>? OrderByDescExpression { get; private set; }

        public BasicSpecification(Expression<Func<T, bool>> criteria) => Criteria = criteria;

        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
            => Includes.Add(includeExpression);

        protected virtual void AddIncludeString(string include)
            => IncludesString.Add(include);

        protected virtual void AddOrderBy(Expression<Func<T, object>> orderByExpression)
            => OrderByExpression = orderByExpression;

        protected virtual void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression)
            => OrderByDescExpression = orderByDescExpression;
    }
}

