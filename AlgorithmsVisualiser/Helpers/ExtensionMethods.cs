using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsVisualiser.Helpers
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Converts the string so that the first letter is in uppercase while
        /// the other letters are in lowercase
        /// </summary>
        public static string InitCap(this string s)
        {
            char[] c = s.ToCharArray();
            if(c[0] >= 'a' && c[0] <= 'z')
            {
                c[0] = (char)(c[0] - 'a' + 'A');
            }

            for(int i = 1; i < c.Length; i++)
            {
                if(c[i] >= 'A' && c[i] < 'Z')
                {
                    c[i] = (char)(c[i] - 'A' + 'a');
                }
            }

            StringBuilder sb = new StringBuilder(c.Length);
            for(int i = 0; i < c.Length; i++)
            {
                sb.Append(c[i]);
            }
            return sb.ToString();
        }
    }
}
