using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datacom.CommonCore.Extensions
{
    public static class StringExtensions
    {
        const char semiColon = ';';
        /// <summary>
        /// sets a string to lowercase and splits it by semi-colon.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static List<string> SplitBySemiColon(this string s)
        {
            var e = new List<string>();
            if (!string.IsNullOrEmpty(s))
            {
                if (s.Contains(semiColon))
                {
                    e.AddRange(s.ToLower().Split(semiColon));
                }
                e.Add(s.ToLower().Replace(semiColon.ToString(), ""));
            }
            return e;
        }

        /// <summary>
        /// Check if all characters are the same i.e. 2222
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static bool HasRepeatingCharacters(this string helper)
        {
            if (!string.IsNullOrEmpty(helper))
            {
                var characters = helper.ToCharArray();
                if (characters.Count() != 1)
                {
                    return characters.All(y => y == characters.First());
                }
            }
            return false;
        }

        /// <summary>
        /// Check if string is number.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNumber(this string s)
        {
            double num;
            return double.TryParse(s, out num);
        }
    }
}
