param (
    [string]$nugetApiKey = "",
    [string]$version = "1.0.1-alpha",
    [string]$outputdirectory = "$(Get-Location)\output"
)

.\Package.ps1 -version $version -outputdirectory $outputdirectory

dotnet nuget push "$outputdirectory\*.nupkg" -k $nugetApiKey -s https://api.nuget.org/v3/index.json