#addin "Cake.Npm"
#addin "Cake.Docker"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var solutionPath = "CPMS.sln";
var artifactsPath = "./artifacts/";

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
.Does(() =>
{
    var cleanSettings = new DotNetCoreCleanSettings {
        Configuration = configuration
    };

    DotNetCoreClean(solutionPath, cleanSettings);
    CleanDirectory(artifactsPath);
});

Task("RestoreNuGetPackages")
.IsDependentOn("Clean")
.Does(() =>
{
    DotNetCoreRestore(solutionPath);
});

Task("DotNetBuild")
.IsDependentOn("RestoreNuGetPackages")
.Does(() =>
{
    var buildSettings = new DotNetCoreBuildSettings {
        Configuration = configuration,
        NoRestore = true,
        ArgumentCustomization = arg => arg.AppendSwitch("/p:DebugType","=","Full")
    };

    DotNetCoreBuild(solutionPath, buildSettings);
});

Task("NpmInstall")
.IsDependentOn("Clean")
.Does(() => {
        var settings = new NpmInstallSettings
        {
            LogLevel = NpmLogLevel.Info,
            WorkingDirectory = "./CPMS.Web"
        };

        NpmInstall(settings);
});

Task("NpmBuild")
.IsDependentOn("NpmInstall")
.Does(() => {
        var settings = new NpmRunScriptSettings
        {
            LogLevel = NpmLogLevel.Info,
            WorkingDirectory = "./CPMS.Web",
            ScriptName = "build-prod"
        };

        NpmRunScript(settings);
});

Task("DotNetPublish")
.IsDependentOn("DotNetBuild")
.IsDependentOn("NpmBuild")
.Does(() =>
{
     var settings = new DotNetCorePublishSettings
     {
         Configuration = configuration,
         NoRestore = true,
         OutputDirectory = artifactsPath
     };

     DotNetCorePublish(solutionPath, settings);
});

Task("DockerBuild")
.IsDependentOn("DotNetPublish")
.Does(() => {
     var settings = new DockerImageBuildSettings
     {
        Tag = new[] { "sito/cpms:latest" }
     };

     DockerBuild(settings, ".");
});

Task("DockerLogin")
.IsDependentOn("DockerBuild")
.Does(() => {
    var dockerUsername = EnvironmentVariable("DOCKER_USERNAME");
    var dockerPassword = EnvironmentVariable("DOCKER_PASSWORD");
    if(!string.IsNullOrWhiteSpace(dockerUsername))
    {
        DockerLogin(dockerUsername, dockerPassword);
    }
});

Task("DockerPush")
.IsDependentOn("DockerLogin")
.Does(() => {
    DockerPush("sito/cpms");
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
.IsDependentOn("DockerPush");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
