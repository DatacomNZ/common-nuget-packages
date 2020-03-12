param (
    [string]$version  = "1.0.1-alpha",
    [string]$outputdirectory = "$(Get-Location)\output"
)
dotnet build -c Release

remove-item $outputdirectory -force -recurse -ErrorAction SilentlyContinue

#.\tools\nuget.exe pack "src/Datacom.Common/Datacom.Common.csproj" -OutputDirectory $outputdirectory -Version $version -properties Configuration=Release
#.\tools\nuget.exe pack "src/Datacom.Common.Collections/Datacom.Common.Collections.csproj" -OutputDirectory $outputdirectory -Version $version -properties Configuration=Release
#.\tools\nuget.exe pack "src/Datacom.Common.Diagnostics/Datacom.Common.Diagnostics.csproj" -OutputDirectory $outputdirectory -Version $version -properties Configuration=Release
#.\tools\nuget.exe pack "src/Datacom.Common.Diagnostics.WebApi/Datacom.Common.Diagnostics.WebApi.csproj" -OutputDirectory $outputdirectory -Version $version -properties Configuration=Release
#.\tools\nuget.exe pack "src/Datacom.Common.Mvc/Datacom.Common.Mvc.csproj" -OutputDirectory $outputdirectory -Version $version -properties Configuration=Release
#.\tools\nuget.exe pack "src/Datacom.Common.SignalR/Datacom.Common.SignalR.csproj" -OutputDirectory $outputdirectory -Version $version -properties Configuration=Release
#.\tools\nuget.exe pack "src/Datacom.Common.WebApi/Datacom.Common.WebApi.csproj" -OutputDirectory $outputdirectory -Version $version -properties Configuration=Release

dotnet pack "./src/dotnetCore/Datacom.CommonCore/Datacom.CommonCore.csproj" -o $outputdirectory -c Release -p:PackageVersion=$version
dotnet pack "./src/dotnetCore/Datacom.CommonCore.Collections/Datacom.CommonCore.Collections.csproj" -o $outputdirectory -c Release -p:PackageVersion=$version
dotnet pack "./src/dotnetCore/Datacom.CommonCore.Diagnostics/Datacom.CommonCore.Diagnostics.csproj" -o $outputdirectory -c Release -p:PackageVersion=$version