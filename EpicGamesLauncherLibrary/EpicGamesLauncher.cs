using EpicManifestParser.Objects;
using System.Text.Json;
using static EpicGamesLauncherLibrary.Modals;

namespace EpicGamesLauncherLibrary;

public class EpicGamesLauncher
{
    public static readonly string EpicGamesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Epic");

    public string AppName { get; private set; }
    private InstalledApp app { get; set; }

    public EpicGamesLauncher(string AppName)
    {
        this.AppName = AppName;
        this.app = LauncherInstalledDat.GetApp(AppName);
        this.InstalledManifest = GetManifest(AppName);
    }

    public InstalledApp Info => this.app;
    public ManifestObject InstalledManifest;

    private readonly static string ManifestFolder = Path.Combine(EpicGamesPath, "EpicGamesLauncher", "Data", "Manifests");

    public static IReadOnlyList<ManifestObject> GetInstalledManifests()
    {
        List<ManifestObject> manifests = new();
        string[] manifestjson = Directory.GetFiles(ManifestFolder, "*.item", SearchOption.TopDirectoryOnly);
        foreach (var manifestFile in manifestjson)
        {
            string FileContent = File.ReadAllText(manifestFile);
            var manifest = JsonSerializer.Deserialize<ManifestObject>(FileContent);
            if (manifest is not null)
                manifests.Add(manifest);
        }
        return manifests;
    }

    public static ManifestObject GetManifest(string AppName)
    {
        var manifests = GetInstalledManifests();
        bool IsAppInstalled = manifests.Any(x => x.AppName == AppName);
        if (!IsAppInstalled)
            throw new Exception($"\"{AppName}\" is not installed by Epic Games Launcher");
        else
            return manifests.First(x => x.AppName == AppName);
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