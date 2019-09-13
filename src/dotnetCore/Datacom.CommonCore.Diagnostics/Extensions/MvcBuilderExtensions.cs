using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Datacom.CommonCore.Diagnostics.Extensions
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddDiagnosticControllers(this IMvcBuilder app)
        {
            var assembly = typeof(Controllers.v0.HealthCheckController).GetTypeInfo().Assembly;
            return app.AddApplicationPart(assembly).AddControllersAsServices();
        }
    }
}
