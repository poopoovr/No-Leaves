using BepInEx;
using BepInEx.Logging;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NoLeaves
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        // Logs for bepinex
        internal static new ManualLogSource Logger;
        // unity temp file name for leaves
        private const string leafName = "UnityTempFile-974861d3659c78d4297f984b2f46d076 (combined by EdMeshCombiner)";
        // Checks if leaves were already removed
        private bool done = false;

        // self explainatory
        private void Awake()
        {
            Logger = base.Logger;
            SceneManager.sceneLoaded += OnSceneLoaded;
            RemoveLeaves();
        }

        // stuff go boom boom
        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        // new scene loader
        private void OnSceneLoaded(Scene scn, LoadSceneMode mode)
        {
            done = false;
            Invoke(nameof(RemoveLeaves), 0.5f);
        }

        // removes the leaves. dih yum yes bro
        private void RemoveLeaves()
        {
            if(done) return;
            
            GameObject obj = GameObject.Find(leafName);
            if(obj != null) {
                obj.SetActive(false);
                Logger.LogInfo("Mod is working");
                done = true;
            } else {
                Logger.LogError("Mod is failing");
            }
        }
    }
}
