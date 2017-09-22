using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datacom.Common.Exceptions
{
    /// <summary>
    /// Specify the property that has a problem. 
    /// This can be used in conjunction with ModelState exception handling.
    /// </summary>
    public class PropertyException : Exception
    {
        public string Property { get; private set; }
        public PropertyException(string property, string message) : base(message)
        {
            Property = property;
        }
    }
}
