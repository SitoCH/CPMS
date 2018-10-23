#addin "Cake.Npm"
#addin "Cake.Docker"
#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");
var isMasterBranch = StringComparer.OrdinalIgnoreCase.Equals("master", BuildSystem.TFBuild.Environment.Repository.Branch);

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

Task("DotNetCoreRestore")
.IsDependentOn("Clean")
.Does(() =>
{
    DotNetCoreRestore(solutionPath);
});

Task("DotNetCoreBuild")
.IsDependentOn("DotNetCoreRestore")
.Does(() =>
{
    var buildSettings = new DotNetCoreBuildSettings {
        Configuration = configuration,
        NoRestore = true,
        ArgumentCustomization = arg => arg.AppendSwitch("/p:DebugType","=","Full")
    };

    DotNetCoreBuild(solutionPath, buildSettings);
});

Task("DotNetCoreTest")
.IsDependentOn("DotNetCoreBuild")
.Does(() =>
{
    var testSettings = new DotNetCoreTestSettings {
        Configuration = configuration,
        NoRestore = true,
        NoBuild = true,
        Logger = "trx;LogFileName=TestResults.trx",
    };

    DotNetCoreTest("CPMS.Tests/CPMS.Tests.csproj", testSettings);
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

Task("DotNetCorePublish")
.IsDependentOn("DotNetCoreTest")
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
.IsDependentOn("DotNetCorePublish")
.WithCriteria(isMasterBranch)
.Does(() => {
     var settings = new DockerImageBuildSettings
     {
        Tag = new[] { "sito/cpms:latest" }
     };

     DockerBuild(settings, ".");
});

Task("DockerLogin")
.IsDependentOn("DockerBuild")
.WithCriteria(TFBuild.IsRunningOnVSTS)
.WithCriteria(isMasterBranch)
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
.WithCriteria(TFBuild.IsRunningOnVSTS)
.WithCriteria(isMasterBranch)
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
