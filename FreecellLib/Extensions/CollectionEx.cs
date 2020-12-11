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
            //where T : ICard 
        {
            var ret = new List<T[]>();
            foreach(var a in input) {
                var b = a?.ToArray() ?? Array.Empty<T>();
                ret.Add(b);
            }
            return ret.ToArray();
        }
    }
}
