using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datacom.Common.Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        /// Checks that an integer has sequential digits. i.e. 1234
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
        /// Checks if an integer has repeating digits i.e. 2222
        /// </summary>
        /// <returns></returns>
        public static bool HasRepeatingDigits(this int helper)
        {
            return helper.ToString().HasRepeatingCharacters();
        }
    }
}
