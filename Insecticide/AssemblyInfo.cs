using Insecticide;
using MelonLoader;
using BuildInfo = Insecticide.BuildInfo;

[assembly: MelonInfo(typeof(Mod), BuildInfo.Name, BuildInfo.Version, BuildInfo.Author)]
[assembly: MelonGame("Stress Level Zero", "BONELAB")]
[assembly: MelonID(BuildInfo.Id)]
[assembly: VerifyLoaderVersion("0.6.5")]
[assembly: HarmonyDontPatchAll]