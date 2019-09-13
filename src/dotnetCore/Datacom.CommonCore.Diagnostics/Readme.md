# Datacom.CommonCore.Diagnostics

This nuget library implements datacom diagnostics such as a 
check to see if application services are running correctly.

# Installation
Install nuget package on your dotnet Core Api project.

There are 2 steps:

    1. Implement the ICheckAvailability interface in your project.
    2. In the startup.cs file update the addMvc() line in ConfigureService function to:
        services.AddMvc().AddDiagnosticControllers();
        (Add Datacom.CommonCore.Diagnostics.Extensions to usings)