using EpicManifestParser.Objects;

namespace EpicGamesLauncherLibrary;

public class EpicGamesLauncher
{
    public static readonly string EpicGamesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Epic");

    public string AppName { get; private set; }
    public LauncherInstalledDat.InstalledApp LocalInstallInfo { get; set; }
    public InstalledManifest.ManifestObject LocalManifest { get; set; }

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

    public static IReadOnlyCollection<EpicGamesLauncher> GetInstalledApps()
    {
        List<EpicGamesLauncher> result = new();
        var installed = LauncherInstalledDat.GetInstalledApps();
        var manifests = InstalledManifest.GetInstalledManifests();
        foreach (var installedApp in installed)
        {
            if (manifests.Any(x => x.AppName == installedApp.AppName))
                result.Add(new EpicGamesLauncher(installedApp, manifests.First(x => x.AppName == installedApp.AppName)));
        }
        return result;
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