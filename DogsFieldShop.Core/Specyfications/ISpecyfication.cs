using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DogsFieldShop.Core.Specyfications
{
    public interface ISpecyfication<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
    }
}
