using MelonLoader;

namespace Insecticide {
    public class Mod : MelonMod {
        public override void OnInitializeMelon()
        {
            HarmonyInstance.PatchAll();
        }

        public override void OnDeinitializeMelon()
        {
            HarmonyInstance.UnpatchSelf();
        }
    }
}