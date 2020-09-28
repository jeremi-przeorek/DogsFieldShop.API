using DogsFieldShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DogsFieldShop.Core.Specyfications
{
    public class BaseSpecyfication<T> : ISpecyfication<T>
    {
        public BaseSpecyfication()
        {
        }

        public BaseSpecyfication(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } 
            = new List<Expression<Func<T, object>>>();

        public void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
    }
}
