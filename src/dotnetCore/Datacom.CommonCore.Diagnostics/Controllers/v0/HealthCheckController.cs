using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Datacom.CommonCore.Diagnostics.Controllers.v0
{
    [AllowAnonymous]
    [Route("api/v0/healthcheck")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private readonly List<ICheckAvailability> _availabilityCheckers;
        private readonly ILogger _logger;

        public HealthCheckController(List<ICheckAvailability> availabilityCheckers)
        {
            this._availabilityCheckers = availabilityCheckers;
        }

        public HealthCheckController(List<ICheckAvailability> availabilityCheckers, ILogger logger)
        {
            this._availabilityCheckers = availabilityCheckers;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> IsAliveAsync()
        {
            if (!_availabilityCheckers.Any())
            {
                return StatusCode((int)HttpStatusCode.NotImplemented, "No Implementations of ICheckAvailability found. Please check your injection bindings");
            }

            // Kick off tasks in parallel to perform checks
            List<(ICheckAvailability AvailabilityChecker, Task<bool> TaskForResult)> runningTasks = _availabilityCheckers.Select(x => (x, x.CheckAccessAsync())).ToList();
            var isHealthy = true; // Happy, unless proven guilty of unhappiness

            foreach (var itemToCheck in runningTasks)
            {
                try
                {
                    var result = await itemToCheck.TaskForResult;
                    if (!result)
                    {
                        if (_logger != null)
                        {
                            _logger.LogError($"Access Check failed: {itemToCheck.Item1.GetLabel()}");
                        }
                        
                        isHealthy = false;
                    }
                }
                catch (Exception ex)
                {
                    if (_logger != null)
                    {
                        _logger.LogError($"Access Check failed", ex);
                    }
                }
            }

            if (isHealthy)
            {
                return Ok("Johnny Five Alive");
            }

            return BadRequest("There are issues with this application. Check the logs");
        }
    }
}