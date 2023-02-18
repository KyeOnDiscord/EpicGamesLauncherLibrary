using EpicManifestParser.Objects;
using System.Diagnostics;

namespace EpicGamesLauncherLibrary;

public class EpicGamesLauncher
{
    public static readonly string EpicGamesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Epic");

    public string AppName { get; private set; }
    public LauncherInstalledDat.InstalledApp? LocalInstallInfo { get; set; }
    public InstalledManifest.ManifestObject? LocalManifest { get; set; }

    public EpicGamesLauncher(string AppName)
    {
        this.AppName = AppName;
        this.LocalInstallInfo = LauncherInstalledDat.GetInstalledApp(AppName);
        this.LocalManifest = InstalledManifest.GetManifest(AppName);
    }

    public EpicGamesLauncher(LauncherInstalledDat.InstalledApp LocalInstallInfo, InstalledManifest.ManifestObject LocalManifest)
    {
        this.AppName = LocalInstallInfo.AppName;
        this.LocalInstallInfo = LocalInstallInfo;
        this.LocalManifest = LocalManifest;
    }

    /// <summary>
    /// Launches the app via Epic Games Launcher
    /// </summary>
    /// <param name="silent">When false, it doesn't open Epic Games Launcher in the foreground and opens it open in the System Tray</param>
    public void Launch(bool silent = false)
    {
        string Path = $"com.epicgames.launcher://apps/{this.LocalInstallInfo.NamespaceId}:{this.LocalInstallInfo.ItemId}:{this.LocalInstallInfo.AppName}?action=launch&silent={silent.ToString().ToLower()}";
        Process.Start(new ProcessStartInfo(Path) { UseShellExecute = true });
    }

    public override string ToString() => $"{GetType()}.{AppName}";

    //Static Methods
    public static IReadOnlyCollection<EpicGamesLauncher> GetInstalledApps()
    {
        List<EpicGamesLauncher> result = new();
        var installed = LauncherInstalledDat.GetInstalledApps();
        var manifests = InstalledManifest.GetInstalledManifests();
        foreach (var installedApp in installed)
        {
            if (manifests.Any(x => x.AppName.ToLower() == installedApp.AppName.ToLower()))
                result.Add(new EpicGamesLauncher(installedApp, manifests.First(x => x.AppName.ToLower() == installedApp.AppName.ToLower())));
        }
        return result;
    }

    public static bool IsGameInstalled(string AppName)
    {
        return GetInstalledApps().Any(x => x.AppName.ToLower() == AppName.ToLower());
    }


    public class Manifests
    {
        public ManifestInfo manifestInfo;
        public Manifests(string manifestJson)
        {
            this.manifestInfo = new ManifestInfo(manifestJson);
        }
    }
}