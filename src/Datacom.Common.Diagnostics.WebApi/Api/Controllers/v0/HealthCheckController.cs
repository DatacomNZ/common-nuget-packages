using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Datacom.Common.Diagnostics.WebApi.Api.Controllers.v0
{
    [AllowAnonymous]
    [RoutePrefix("api/healthcheck")]
    public class HealthCheckController : ApiController
    {
        private readonly List<ICheckAvailability> servicesToCheck;

        public HealthCheckController(List<ICheckAvailability> servicesToCheck)
        {
            this.servicesToCheck = servicesToCheck;
        }

        [HttpGet]
        [Route("isalive")]
        public async Task<IHttpActionResult> IsAliveAsync()
        {

            var checksAndTasks = new List<(ICheckAvailability, Task<bool>)>(servicesToCheck.Count);

            // Kick of tasks in parallel to perform checks
            foreach (var serviceToCheck in servicesToCheck)
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
                        // TODO, uncomment, and provide any details
                        //log.Error($"Access Check failed for {itemToCheck.Item1.GetLabel()}.");
                        isHealthy = false;
                    }
                }
                catch (Exception ex)
                {
                    // TODO - Uncomment, and provide details
                    //log.Error(ex, $"");
                    return InternalServerError(new Exception("Johny Five DIED"));
                }

            }

            if (isHealthy)
            {
                return Ok("She'll be right");
            }
            return InternalServerError(new Exception("Johny Five DIED"));
        }
    }
}