using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Datacom.CommonCore.Exceptions
{
    /// <summary>
    /// Allows the developer to specify the resource that no longer has permission.
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
