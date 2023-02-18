using System.Text.Json;

namespace EpicGamesLauncherLibrary;

public static class LauncherInstalledDat
{
    private static readonly string InstalledPath = Path.Combine(EpicGamesLauncher.EpicGamesPath, "UnrealEngineLauncher", "LauncherInstalled.dat");
    public static IReadOnlyList<InstalledApp> GetInstalledApps()
    {
        if (!File.Exists(InstalledPath))
            throw new FileNotFoundException($"{InstalledPath} not found. Please install Epic Games Launcher");

        string LaunchPathContents = File.ReadAllText(InstalledPath);
        if (string.IsNullOrEmpty(LaunchPathContents))
        {
            throw new Exception($"{InstalledPath}'s contents was null or empty");
        }
        return JsonSerializer.Deserialize<EpicGamesLauncherData>(LaunchPathContents).InstallationList;
    }
    public static InstalledApp GetInstalledApp(string AppName)
    {
        var InstalledApps = GetInstalledApps();
        bool IsAppInstalled = InstalledApps.Any(x => x.AppName.ToLower() == AppName.ToLower());

        if (IsAppInstalled)
            return InstalledApps.First(x => x.AppName.ToLower() == AppName.ToLower());
        else
            throw new Exception($"\"{AppName}\" is not installed by Epic Games Launcher");
    }

    public class InstalledApp
    {
        public string? InstallLocation { get; set; }
        public string? NamespaceId { get; set; }
        public string? ItemId { get; set; }
        public string? ArtifactId { get; set; }
        public string? AppVersion { get; set; }
        public string? AppName { get; set; }
    }

    public class EpicGamesLauncherData
    {
        public List<InstalledApp>? InstallationList { get; set; }
    }
}
