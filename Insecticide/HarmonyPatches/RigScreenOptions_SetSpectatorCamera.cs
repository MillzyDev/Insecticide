using HarmonyLib;
using Il2CppSLZ.Bonelab;

/*
 * Fixes the skybox rendering in the spectator camera by setting the clear flags to "Skybox" instead of "Nothing".
 */

namespace Insecticide.HarmonyPatches {
    [HarmonyPatch(typeof(RigScreenOptions))]
    [HarmonyPatch(nameof(RigScreenOptions.SetSpectatorCamera))]
    internal static class RigScreenOptions_SetSpectatorCamera {
        [HarmonyPostfix]
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once UnusedMember.Local
        private static void Postfix(RigScreenOptions __instance)
        {
            __instance.cam.clearFlags = UnityEngine.CameraClearFlags.Skybox;
        }
    }
}