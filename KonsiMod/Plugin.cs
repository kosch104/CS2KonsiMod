using BepInEx;
using HarmonyLib;
using System.Reflection;
using System.Linq;

#if BEPINEX_V6
    using BepInEx.Unity.Mono;
#endif

namespace KonsiMod
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private Mod Mod;
        
        private void Awake()
        {
            Mod = new Mod();
            Mod.OnLoad();

            UnityEngine.Debug.Log("[KonsiMod]: Loading Harmony patches.");

            var harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), MyPluginInfo.PLUGIN_GUID + "_Cities2Harmony");
            var patchedMethods = harmony.GetPatchedMethods().ToArray();

            UnityEngine.Debug.Log($"[KonsiMod]: Plugin {MyPluginInfo.PLUGIN_GUID} is loaded! Patched methods " + patchedMethods.Length);
            foreach (var patchedMethod in patchedMethods)
            {
                UnityEngine.Debug.Log($"[KonsiMod]: Patched method: {patchedMethod.Module.Name}:{patchedMethod.Name}");
            }
        }
    }
}