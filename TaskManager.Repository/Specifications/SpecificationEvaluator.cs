using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data.Entities;
using TaskManager.Repository.Interfaces;

namespace TaskManager.Repository.Specifications
{
	public static class SpecificationEvaluator
	{
		public static IQueryable<TEntity> GetQuery<TEntity>
		(
			IQueryable<TEntity> inputQueryable,
			ISpecification<TEntity> spec
		) where TEntity : EntityBase
		{
			IQueryable<TEntity> queryable = inputQueryable;


			if (spec.Criteria is not null)
			{
                queryable = queryable.Where(spec.Criteria);
			}

            queryable = spec.Includes.Aggregate(queryable,
				(current, include) => current.Include(include));

            queryable = spec.IncludesString.Aggregate(queryable,
                (current, include) => current.Include(include));

			if (spec.OrderByExpression is not null)
			{
				queryable.OrderBy(spec.OrderByExpression);
			}
			else if (spec.OrderByDescExpression is not null)
			{
				queryable.OrderByDescending(spec.OrderByDescExpression);
			}


			return queryable;
        }
	}
}

