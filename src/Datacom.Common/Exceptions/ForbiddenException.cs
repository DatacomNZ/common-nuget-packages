using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datacom.Common.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class ForbiddenException : UnauthorizedAccessException
    {
        public ForbiddenException(string resource = "") : base(message: "User does not have permission")
        {
            Resource = resource;
        }
        public string Resource { get; set; }

    }
}
