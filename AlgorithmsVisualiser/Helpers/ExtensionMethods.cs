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

        /// <summary>
        /// Fisher-Yates shuffle
        /// </summary>
        public static void Shuffle(this IList<int> list)
        {
            Random random = new Random();
            int n = list.Count;
            while(n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                int value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
