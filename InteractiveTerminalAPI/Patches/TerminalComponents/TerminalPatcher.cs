using HarmonyLib;
using InteractiveTerminalAPI.UI;
using InteractiveTerminalAPI.Util;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace InteractiveTerminalAPI.Patches.TerminalComponents
{
    [HarmonyPatch(typeof(Terminal))]
    internal static class TerminalPatcher
    {
        [HarmonyTranspiler]
        [HarmonyPatch(nameof(Terminal.Update))]
        static IEnumerable<CodeInstruction> UpdateTranspiler(IEnumerable<CodeInstruction> instructions)
        {
            MethodInfo LategameStoreBeingUsed = typeof(InteractiveTerminalManager).GetMethod(nameof(InteractiveTerminalManager.InteractiveTerminalBeingUsed));
            MethodInfo wasPressed = typeof(ButtonControl).GetMethod("get_wasPressedThisFrame");
            List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
            int index = 0;
            Tools.FindMethod(ref index, ref codes, wasPressed, LategameStoreBeingUsed, notInstruction: true, andInstruction: true, errorMessage: "Couldn't find field used to check if the terminal is being used");
            return codes;
        }
        [HarmonyPostfix]
        [HarmonyPatch(nameof(Terminal.ParsePlayerSentence))]
        static void CustomParser(ref Terminal __instance, ref TerminalNode __result)
        {
            string text = __instance.screenText.text.Substring(__instance.screenText.text.Length - __instance.textAdded);
            if (InteractiveTerminalManager.ContainsApplication(text))
            {
                GameObject store = Object.Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube));
                store.name = "InteractiveTerminal";
                Object.Destroy(store.GetComponent<MeshRenderer>());
                Object.Destroy(store.GetComponent<MeshFilter>());
                InteractiveTerminalManager component = store.AddComponent<InteractiveTerminalManager>();
                component.Initialize(text);
                __result = Util.TerminalNodeUtils.GetHelpTerminalNode();
            }
        }
    }
}
