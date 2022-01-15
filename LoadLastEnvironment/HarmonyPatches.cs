using Bigscreen;
using Bigscreen.UI;
using HarmonyLib;

namespace LoadLastEnvironment
{
    [HarmonyPatch]
    internal static class HarmonyPatches
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(TabletUI), nameof(TabletUI.OnEnable))]
        public static void OnEnable(TabletUI __instance)
        {
            LoadLastEnvironmentMod.Instance.Initialize(__instance.app);
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(App), nameof(App.CreateAndJoinMyRoom))]
        public static void CreateAndJoinMyRoomPrefix(ref string environmentName)
        {
            LoadLastEnvironmentMod.Instance.OnPreCreateAndJoinMyRoom(ref environmentName);
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(TabletUI), nameof(TabletUI.OnEnvironmentChanged))]
        public static void OnEnvironmentChanged()
        {
            LoadLastEnvironmentMod.Instance.HandleEnvironmentChanged();
        }
    }
}