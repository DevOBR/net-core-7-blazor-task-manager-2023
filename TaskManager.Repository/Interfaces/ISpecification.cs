using System;
using System.Linq.Expressions;

namespace TaskManager.Repository.Interfaces
{
	public interface ISpecification<T>
	{
		Expression<Func<T, bool>>? Criteria { get; }
		List<Expression<Func<T, object>>> Includes { get; }
		Expression<Func<T, object>>? OrderByExpression { get; }
        Expression<Func<T, object>>? OrderByDescExpression { get; }
        List<string> IncludesString { get; }
	}
}

