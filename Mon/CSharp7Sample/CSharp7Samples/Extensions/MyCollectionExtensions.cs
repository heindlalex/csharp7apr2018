using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp7Samples.Extensions
{
    public static class MyCollectionExtensions
    {
        public static IEnumerable<T> Filter1<T>(this IEnumerable<T> source, Func<T, bool> pred)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (pred == null) throw new ArgumentNullException(nameof(pred));

            foreach (T item in source)
            {
                if (pred(item))
                    yield return item;
            }
        }

        public static IEnumerable<T> Filter2<T>(this IEnumerable<T> source, Func<T, bool> pred)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (pred == null) throw new ArgumentNullException(nameof(pred));

            return Filter2Impl(source, pred);
        }

        private static IEnumerable<T> Filter2Impl<T>(this IEnumerable<T> source, Func<T, bool> pred)
        {
            foreach (T item in source)
            {
                if (pred(item))
                    yield return item;
            }
        }

        public static IEnumerable<T> Filter3<T>(this IEnumerable<T> source, Func<T, bool> pred)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (pred == null) throw new ArgumentNullException(nameof(pred));

            return Filter3Impl();

            IEnumerable<T> Filter3Impl()
            {
                foreach (T item in source)
                {
                    if (pred(item))
                        yield return item;
                }
            }
        }


    }
}
