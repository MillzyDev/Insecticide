using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSLZ.Bonelab.SaveData;
using Il2CppSLZ.Marrow.Warehouse;
using Il2CppSLZ.UI;
using MelonLoader;
using UnityEngine;

/*
 * Fixes the hand getting stuck to body mall when a non-installed avatar is favourited.
 * This occurs due to a null reference exception being thrown, in the hand detach event;
 * the fail case for TryGetCrate is not accounted for.
 */

/*
 * FIXED IN PATCH 6
 */

/*
namespace Insecticide.HarmonyPatches {
    [HarmonyPatch(typeof(AvatarsPanelView))]
    [HarmonyPatch(nameof(AvatarsPanelView.LoadFavoriteAvatars))]
    internal static class AvatarsPanelView_LoadFavouriteAvatars {
        [HarmonyPrefix]
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once UnusedMember.Local
        private static bool Prefix(AvatarsPanelView __instance)
        {
            _ = DataManager.TryLoadActiveSave(0);
            Save activeSave = DataManager.ActiveSave;
            PlayerSettings playerSettings = activeSave._PlayerSettings_k__BackingField;
            Il2CppSystem.Collections.Generic.List<string>? favouriteAvatars = playerSettings._FavoriteAvatars_k__BackingField;
            Il2CppSystem.Collections.Generic.List<AvatarCrateReference>? defaultFavouriteAvatars = __instance.defaultFavoriteAvatarsBarcodes;

            var barcodes = new List<Barcode>();
            if (favouriteAvatars == null || favouriteAvatars._size < defaultFavouriteAvatars._size)
            {
                foreach (AvatarCrateReference? avatar in defaultFavouriteAvatars)
                {
                    barcodes.Add(avatar.Barcode);
                }
            }
            else
            {
                foreach (string? barcodeString in favouriteAvatars)
                {
                    var barcode = new Barcode(barcodeString);
                    barcodes.Add(barcode);
                }
            }

            Il2CppReferenceArray<AvatarCrateReference>? avatarFavourites = __instance.avatarFavorites;
            for (int i = 0; i < barcodes.Count; i++)
            {
                Barcode barcode = barcodes[i];
                Debug.Log($"Loading avatar {barcode.ID} from save data"); // same as game log

                AvatarCrateReference crateReference = AssetWarehouse.Instance.TryGetCrate(barcode, out Crate? crate) 
                    ? new AvatarCrateReference(crate.Barcode) 
                    : defaultFavouriteAvatars._items[i];
                avatarFavourites[i] = crateReference;

                ButtonReferenceHolder? slotButton = __instance.slotButtons[i];
                slotButton.tmp.text = crateReference.Crate.name;
            }

            return false;
        }
    }
}
*/