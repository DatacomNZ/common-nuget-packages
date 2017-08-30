using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datacom.Common.Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool HasSequentialDigits(this int helper)
        {
            var digits = helper.ToString().ToCharArray().Select(x => (int)x).ToList();
            if (digits.Count() != 1)
            {
                return digits.Zip(digits.Skip(1), (a, b) => (a + 1) == b).All(x => x);
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool HasRepeatingDigits(this int helper)
        {
            return helper.ToString().HasRepeatingCharacters();
        }
    }
}
