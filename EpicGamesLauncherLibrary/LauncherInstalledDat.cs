﻿using System.Text.Json;
using static EpicGamesLauncherLibrary.Modals;

namespace EpicGamesLauncherLibrary;

public static class LauncherInstalledDat
{
    private static readonly string InstalledPath = Path.Combine(EpicGamesLauncher.EpicGamesPath, "UnrealEngineLauncher", "LauncherInstalled.dat");
    public static IReadOnlyList<InstalledApp> GetInstalledApps()
    {

        if (!File.Exists(InstalledPath))
        {
            throw new FileNotFoundException($"{InstalledPath} not found. Please install Epic Games Launcher");
        }

        string LaunchPathContents = File.ReadAllText(InstalledPath);
        if (string.IsNullOrEmpty(LaunchPathContents))
        {
            throw new Exception($"{InstalledPath}'s contents was null or empty");
        }
        return JsonSerializer.Deserialize<EpicGamesLauncherData>(LaunchPathContents).InstallationList;
    }
    public static InstalledApp GetApp(string AppName)
    {
        var InstalledApps = GetInstalledApps();
        bool IsAppInstalled = InstalledApps.Any(x => x.AppName == AppName);

        if (!IsAppInstalled)
            throw new Exception($"\"{AppName}\" is not installed by Epic Games Launcher");
        else
            return InstalledApps.First(x => x.AppName == AppName);
    }
}