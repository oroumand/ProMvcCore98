using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Session21.LinqTests.MyLinqTest
{
    public static class MyLinq
    {
        public static int Count(this IEnumerable enumerable)
        {
            int totalCount = 0;
            var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                totalCount++;
            }
            return totalCount;
        }

        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> input,Func<T,bool> expression )
        {
            List<T> result = new List<T>();
            foreach (var item in input)
            {
                if(expression.Invoke(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static IEnumerable<T> MyWhere2<T>(this IEnumerable<T> input, Func<T, bool> expression)
        {
           
            foreach (var item in input)
            {
                if (expression.Invoke(item))
                {
                    yield return item;
                }
            }
          
        }
    }
}
