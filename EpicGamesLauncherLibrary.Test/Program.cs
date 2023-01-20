using EpicGamesLauncherLibrary;

//Get all the installed apps on Epic Games Launcher
var apps = EpicGamesLauncher.GetInstalledApps();


//Get a specific app on Epic Games Launcher by its name
EpicGamesLauncher fortnite = new EpicGamesLauncher("Fortnite");

//Get an app's installation location
var InstallPath = fortnite.LocalInstallInfo.InstallLocation;

//Get an app's version
var Version = fortnite.LocalInstallInfo.AppVersion;
return;