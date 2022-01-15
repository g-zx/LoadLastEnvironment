using System;
using System.Reflection;
using System.Runtime.InteropServices;
using LoadLastEnvironment;
using MelonLoader;
using BuildInfo = LoadLastEnvironment.BuildInfo;

[assembly: AssemblyTitle(BuildInfo.Name)]
[assembly: AssemblyDescription(BuildInfo.Description)]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(BuildInfo.Author)]
[assembly: AssemblyProduct(BuildInfo.Name)]
[assembly: AssemblyCopyright(BuildInfo.Copyright)]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid("A5D55E9B-81F4-4E25-9BF8-2B557480B744")]
[assembly: AssemblyVersion(BuildInfo.Version)]
[assembly: AssemblyFileVersion(BuildInfo.Version)]

[assembly: MelonInfo(typeof(LoadLastEnvironmentMod), BuildInfo.Name, BuildInfo.Version, BuildInfo.Author, BuildInfo.DownloadLink)]
[assembly: MelonGame("Bigscreen Inc.", "Bigscreen")]
[assembly: MelonColor(ConsoleColor.Green)]