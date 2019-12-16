using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWindowsVliegtuig.Util
{
    public static class LinqExtensions
    {
        /// <summary>
        /// Returns the index of the first item that matches the given value. Or -1 if not found.
        /// </summary>
        public static int IndexOf<T>(this IEnumerable<T> list, T value)
            where T : class
        {
            return IndexOf(list, (item) => (item == value));
        }

        /// <summary>
        /// Returns the index of the first item that matches the given value. Or -1 if not found.
        /// </summary>
        public static int IndexOf<T>(this IEnumerable<T> list, Func<T, bool> pred)
        {
            int i = 0;
            foreach (T item in list)
            {
                if (pred(item))
                {
                    return i;
                }

                ++i;
            }

            return -1;
        }
    }
}
