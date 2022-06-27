using System;
using System.Collections.Generic;

namespace Piekarnia.Common.Extensions
{
    public static class ListExtension
    {
        public static void Shuffle<T>(this IList<T> list){
            Random random = new Random();
            int n = list.Count;
            while(n > 1){
                n--;
                var k = random.Next(n+1);
                var val = list[k];
                list[k] = list[n];
                list[n] = val;
            }
        }
    }
}
