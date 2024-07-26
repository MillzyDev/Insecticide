using HarmonyLib;
using Il2CppCysharp.Threading.Tasks;
using Il2CppSLZ.Marrow.Warehouse;

namespace Insecticide.HarmonyPatches {
    [HarmonyPatch(typeof(AssetWarehouse))]
    [HarmonyPatch(nameof(AssetWarehouse.ReloadPallet))]
    internal static class AssetWarehouse_ReloadPallet {
        [HarmonyPrefix]
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once UnusedMember.Local
        private static bool Prefix(AssetWarehouse __instance, Barcode barcode)
        {
            if (!__instance.TryGetScannable(barcode, out Pallet pallet))
            {
                // todo error
                return false;
            }

            Il2CppSystem.Collections.Generic.Dictionary<Barcode, PalletManifest>? palletManifests = __instance.palletManifests;
            if (palletManifests == null)
            {
                // TODO: exception
                return false;
            }

            if (!palletManifests.TryGetValue(barcode, out PalletManifest palletManifest))
            {
                return false;
            }
            
            __instance.UnloadPallet(pallet);
            UniTask<bool> task = __instance.LoadPalletFromFolderAsync(palletManifest._palletPath, true);
            task.Forget();
            
            return false;
        }
    }
}