namespace EpicGamesLauncherLibrary;

public class Modals
{
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



    public class ManifestObject
    {
        public int FormatVersion { get; set; }
        public bool bIsIncompleteInstall { get; set; }
        public string LaunchCommand { get; set; }
        public string LaunchExecutable { get; set; }
        public string ManifestLocation { get; set; }
        public string ManifestHash { get; set; }
        public bool bIsApplication { get; set; }
        public bool bIsExecutable { get; set; }
        public bool bIsManaged { get; set; }
        public bool bNeedsValidation { get; set; }
        public bool bRequiresAuth { get; set; }
        public bool bAllowMultipleInstances { get; set; }
        public bool bCanRunOffline { get; set; }
        public bool bAllowUriCmdArgs { get; set; }
        public string[] BaseURLs { get; set; }
        public string BuildLabel { get; set; }
        public string[] AppCategories { get; set; }
        public object[] ChunkDbs { get; set; }
        public object[] CompatibleApps { get; set; }
        public string DisplayName { get; set; }
        public string InstallationGuid { get; set; }
        public string InstallLocation { get; set; }
        public string InstallSessionId { get; set; }
        public string[] InstallTags { get; set; }
        public string[] InstallComponents { get; set; }
        public string HostInstallationGuid { get; set; }
        public object[] PrereqIds { get; set; }
        public string PrereqSHA1Hash { get; set; }
        public string LastPrereqSucceededSHA1Hash { get; set; }
        public string StagingLocation { get; set; }
        public string TechnicalType { get; set; }
        public string VaultThumbnailUrl { get; set; }
        public string VaultTitleText { get; set; }
        public long InstallSize { get; set; }
        public string MainWindowProcessName { get; set; }
        public object[] ProcessNames { get; set; }
        public object[] BackgroundProcessNames { get; set; }
        public string MandatoryAppFolderName { get; set; }
        public string OwnershipToken { get; set; }
        public string CatalogNamespace { get; set; }
        public string CatalogItemId { get; set; }
        public string AppName { get; set; }
        public string AppVersionString { get; set; }
        public string MainGameCatalogNamespace { get; set; }
        public string MainGameCatalogItemId { get; set; }
        public string MainGameAppName { get; set; }
        public object[] AllowedUriEnvVars { get; set; }
    }

}
