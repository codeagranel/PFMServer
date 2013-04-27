using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PFMServer
{
    public static class StringArrayExtensions
    {
        public static int[] ToIntArray(this string[] stringArray)
        {
            var intArray = new int[stringArray.Length];

            for (int i = 0; i < stringArray.Length; i++)
			{
                int.TryParse(stringArray[i], out intArray[i]);
			}

            return intArray;
        }
    }
}