using System;
using System.Collections.Generic;

namespace MapMaker.Data.Extensions
{
    public static class ListExtensions
    {
        public static IEnumerable<List<T>> SplitList<T>(this List<T> list, int chunkSize = 25)
        {
            for (int i = 0; i < list.Count; i += chunkSize)
            {
                yield return list.GetRange(i, Math.Min(chunkSize, list.Count - i));
            }
        }
    }
}