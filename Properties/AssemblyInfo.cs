using System.Reflection;
using RumbleMod2;
using MelonLoader;

// ^C+^V from iLikeMyAccountName along with RumbleMod2.BuildInfo
[assembly: AssemblyTitle(RumbleMod2.BuildInfo.Description)]
[assembly: AssemblyDescription(RumbleMod2.BuildInfo.Description)]
[assembly: AssemblyCompany(RumbleMod2.BuildInfo.Company)]
[assembly: AssemblyProduct(RumbleMod2.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + RumbleMod2.BuildInfo.Author)]
[assembly: AssemblyTrademark(RumbleMod2.BuildInfo.Company)]
[assembly: AssemblyVersion(RumbleMod2.BuildInfo.Version)]
[assembly: AssemblyFileVersion(RumbleMod2.BuildInfo.Version)]
[assembly: MelonInfo(typeof(HighNoon), RumbleMod2.BuildInfo.Name, RumbleMod2.BuildInfo.Version, RumbleMod2.BuildInfo.Author)]

[assembly: MelonGame("Buckethead Entertainment", "RUMBLE")]