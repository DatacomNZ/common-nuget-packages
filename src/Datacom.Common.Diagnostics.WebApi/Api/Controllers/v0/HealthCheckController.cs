using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Datacom.Common.Diagnostics.WebApi.Api.Controllers.v0
{
    [AllowAnonymous]
    [RoutePrefix("api/v0/healthcheck")]
    public class HealthCheckController : ApiController
    {
        private readonly List<ICheckAvailability> availabilityCheckers;

        public HealthCheckController(List<ICheckAvailability> availabilityCheckers)
        {
            this.availabilityCheckers = availabilityCheckers;
        }

        [HttpGet]
        [Route("isalive")]
        public async Task<IHttpActionResult> IsAliveAsync()
        {
            if (!availabilityCheckers.Any())
            {
                return Content(HttpStatusCode.NotImplemented, "No Implementations of ICheckAvailability found. Please check your injection bindings");
            }

            // Kick of tasks in parallel to perform checks
            List<(ICheckAvailability AvailabilityChecker, Task<bool> TaskForResult)> runningTasks = availabilityCheckers.Select(x => (x, x.CheckAccessAsync())).ToList();
            var isHealthy = true; // Happy, unless proven guilty of unhappiness

            foreach (var itemToCheck in runningTasks)
            {
                try
                {
                    var result = await itemToCheck.TaskForResult;
                    if (!result)
                    {
                        // Don't jump out early, it'll be nice to know what services are failing. What if two were failing?
                        //log.Error($"Access Check failed for {itemToCheck.Item1.GetLabel()}.");
                        isHealthy = false;
                    }
                }
                catch (Exception ex)
                {
                    //log.Error(ex, $"Failed to complete health check");
                    return InternalServerError(new Exception("Johny Five Segfaulted"));
                }
            }

            if (isHealthy)
            {
                return Ok("Johnny Five Alive");
            }
            return InternalServerError(new Exception("Johny Five Segfaulted"));
        }
    }
}