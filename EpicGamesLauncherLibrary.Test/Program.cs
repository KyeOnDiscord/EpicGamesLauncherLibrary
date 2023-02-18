using EpicGamesLauncherLibrary;

//Get all the installed apps on Epic Games Launcher
var apps = EpicGamesLauncher.GetInstalledApps();
Console.WriteLine($"Found {apps.Count} installed apps on Epic Games Launcher: {string.Join(", ", apps.Select(x => x.AppName))}");

//Get a specific app on Epic Games Launcher by its name

const string GameName = "Fortnite";
if (EpicGamesLauncher.IsGameInstalled(GameName))
{
    Console.WriteLine("Fortnite is installed on Epic Games Launcher");
    var fortnite = new EpicGamesLauncher(GameName);

    //Get an app's installation location
    var InstallPath = fortnite.LocalInstallInfo.InstallLocation;
    Console.WriteLine($"Install Path: {InstallPath}");
    //Get an app's version
    var Version = fortnite.LocalInstallInfo.AppVersion;
    Console.WriteLine($"Fortnite Version: {Version}");

    // Launch the app
    //fortnite.Launch();
}
else
    Console.WriteLine("Fortnite is not installed on Epic Games Launcher");