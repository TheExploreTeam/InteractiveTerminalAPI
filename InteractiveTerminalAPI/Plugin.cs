using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using InteractiveTerminalAPI.Compat;
using InteractiveTerminalAPI.Patches.TerminalComponents;
using InteractiveTerminalAPI.Misc;
using InteractiveTerminalAPI.Input;
#if DEBUG
using InteractiveTerminalAPI.UI;
using InteractiveTerminalAPI.UI.Application;
#endif

namespace InteractiveTerminalAPI
{
    [BepInPlugin(Metadata.GUID,Metadata.NAME,Metadata.VERSION)]
    [BepInDependency("com.rune580.LethalCompanyInputUtils")]
    public class Plugin : BaseUnityPlugin
    {
        internal static readonly Harmony harmony = new(Metadata.GUID);
        internal static readonly ManualLogSource mls = BepInEx.Logging.Logger.CreateLogSource(Metadata.NAME);

        void Awake()
        {
            InputUtils_Compat.Init();
            PatchMainVersion();
#if DEBUG
            InteractiveTerminalManager.RegisterApplication<ExampleApplication>("hello", caseSensitive: true);
#endif
            mls.LogInfo($"{Metadata.NAME} {Metadata.VERSION} has been loaded successfully.");
        }
        internal static void PatchMainVersion()
        {
            PatchVitalComponents();
        }
        static void PatchVitalComponents()
        {
            harmony.PatchAll(typeof(Keybinds));
            harmony.PatchAll(typeof(TerminalPatcher));
            mls.LogInfo("Game managers have been patched");
        }
    }
}
