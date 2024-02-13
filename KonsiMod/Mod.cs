using Colossal.Logging;
using Game;
using Game.Modding;
using KonsiMod.Systems;

namespace KonsiMod
{
    public sealed class Mod : IMod
    {
        public const string Name = MyPluginInfo.PLUGIN_NAME;
        public static Mod Instance { get; set; }
        internal ILog Log { get; private set; }
        public void OnLoad()
        {
            Instance = this;
            Log = LogManager.GetLogger(Name);
#if VERBOSE
            Log.effectivenessLevel = Level.Verbose;
#elif DEBUG
            Log.effectivenessLevel = Level.Debug;
#endif

            Log.Info("Loading.");
        }

        public void OnCreateWorld(UpdateSystem updateSystem)
        {
            UnityEngine.Debug.Log("[KonsiMod]: Add system to world.");
            updateSystem.UpdateAt<KonsiModSystem>(SystemUpdatePhase.ModificationEnd);
        }

        public void OnDispose()
        {
            UnityEngine.Debug.Log("[KonsiMod]: Mod disposed.");
            Instance = null;
        }
    }
}
