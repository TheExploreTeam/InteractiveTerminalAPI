using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using MoreShipUpgrades.Misc;
using InteractiveTerminalAPI.Compat;
using InteractiveTerminalAPI.Patches.TerminalComponents;
using InteractiveTerminalAPI.Misc;
using InteractiveTerminalAPI.Input;

namespace InteractiveTerminalAPI
{
    [BepInEx.BepInPlugin(Metadata.GUID,Metadata.NAME,Metadata.VERSION)]
    [BepInDependency("com.rune580.LethalCompanyInputUtils")]
    public class Plugin : BaseUnityPlugin
    {
        internal static readonly Harmony harmony = new(Metadata.GUID);
        internal static readonly ManualLogSource mls = BepInEx.Logging.Logger.CreateLogSource(Metadata.NAME);

        public new static PluginConfig Config;

        void Awake()
        {
            //Config = new PluginConfig(base.Config);

            InputUtils_Compat.Init();
            PatchMainVersion();

            mls.LogInfo($"{Metadata.NAME} {Metadata.VERSION} has been loaded successfully.");
        }
        internal static void PatchMainVersion()
        {
            PatchVitalComponents();
        }
        static void PatchVitalComponents()
        {
            try
            {
            harmony.PatchAll(typeof(Keybinds));
            harmony.PatchAll(typeof(TerminalPatcher));
            mls.LogInfo("Game managers have been patched");
            }
            catch (Exception exception)
            {
                mls.LogError("An error has occurred patching the game managers...");
                mls.LogError(exception);
            }
        }
    }   
}
