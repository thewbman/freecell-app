using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FreecellLib
{
    public static class CollectionEx
    {
        public static T[][] To2DArray<T>(this IEnumerable<IEnumerable<T>> input) 
        {
            var ret = new List<T[]>();
            foreach(var a in input) {
                var b = a?.ToArray() ?? Array.Empty<T>();
                ret.Add(b);
            }
            return ret.ToArray();
        }
        public static List<List<T>> To2DList<T>(this IEnumerable<IEnumerable<T>> input)
        {
            var ret = new List<List<T>>();
            foreach (var a in input) {
                var b = a?.ToList() ?? Array.Empty<T>().ToList();
                ret.Add(b);
            }
            return ret;
        }
        public static List<List<T>> To2DList<T>(this IEnumerable<T> input)
        {
            var ret = new List<List<T>>();
            foreach (var a in input) {
                var b = Array.Empty<T>().ToList();
                b.Add(a);
                ret.Add(b);
            }
            return ret;
        }
    }
}
