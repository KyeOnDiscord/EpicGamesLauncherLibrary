using EpicGamesLauncherLibrary;

//var installed = EpicGamesLauncher.GetInstalledApps();

EpicGamesLauncher fortnite = new EpicGamesLauncher("Fortnite");
//int i = 0;


string paksfolder = fortnite.Info.InstallLocation + "\\FortniteGame\\Content\\Paks";
string[] paks = Directory.GetFiles(paksfolder);
foreach (string file in paks)
{
    if (file.Contains("ProSwapper"))
        File.Move(file, file.Replace("ProSwapper", "WindowsClient"));
}
int i = 0;