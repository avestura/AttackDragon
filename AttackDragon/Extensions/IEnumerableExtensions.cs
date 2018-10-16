using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackDragon.Extensions
{
    public static class IEnumerableExtensions
    {
        public static int Multiply<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            return (int)source.Select(selector).Aggregate((i1, i2) => i1 * i2);
        }

    }
}
