using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Datacom.Common.Diagnostics.WebApi.Api.Controllers.v0
{
    [AllowAnonymous]
    [RoutePrefix("api/v0/healthcheck")]
    public class HealthCheckController : ApiController
    {
        private readonly ICheckAvailability[] availabilityCheckers;

        public HealthCheckController(ICheckAvailability[] availabilityCheckers)
        {
            this.availabilityCheckers = availabilityCheckers;
        }

        [HttpGet]
        [Route("isalive")]
        public async Task<IHttpActionResult> IsAliveAsync()
        {
            var checksAndTasks = new List<(ICheckAvailability, Task<bool>)>(availabilityCheckers.Length);

            // Kick of tasks in parallel to perform checks
            foreach (var serviceToCheck in availabilityCheckers)
            {
                var task = serviceToCheck.CheckAccessAsync();
                checksAndTasks.Add((serviceToCheck, task));
            }

            var isHealthy = true; // Happy, unless proven otherwise
            foreach (var itemToCheck in checksAndTasks)
            {
                try
                {
                    var result = await itemToCheck.Item2;
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