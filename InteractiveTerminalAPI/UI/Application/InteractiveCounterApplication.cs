using InteractiveTerminalAPI.Input;
using InteractiveTerminalAPI.Misc.Util;
using InteractiveTerminalAPI.UI.Cursor;
using InteractiveTerminalAPI.UI.Screen;
using System;
using static UnityEngine.InputSystem.InputAction;

namespace InteractiveTerminalAPI.UI.Application
{
    internal abstract class InteractiveCounterApplication : BaseInteractiveApplication<CursorCounterMenu, CursorCounterElement>
    {
        protected override void AddInputBindings()
        {
            base.AddInputBindings();
            Keybinds.pageUpAction.performed += OnApplicationCountUp;
            Keybinds.pageDownAction.performed += OnApplicationCountDown;
        }
        protected override void RemoveInputBindings()
        {
            base.RemoveInputBindings();
            Keybinds.pageUpAction.performed -= OnApplicationCountUp;
            Keybinds.pageDownAction.performed -= OnApplicationCountDown;
        }
        void IncrementSelectedCounter()
        {
            currentCursorMenu.IncrementCounter();
        }
        void DecrementSelectedCounter()
        {
            currentCursorMenu.DecrementCounter();
        }
        internal void OnApplicationCountUp(CallbackContext context)
        {
            IncrementSelectedCounter();
        }
        internal void OnApplicationCountDown(CallbackContext context)
        {
            DecrementSelectedCounter();
        }
        /// Example of initializing this application
        /*
        public override void Initialization()
        {
            CursorOutputElement<string>[] cursorCounterElements = new CursorOutputElement<string>[10];
            Func<int, string>[] functions = new Func<int, string>[10];
            for(int i = 0; i < cursorCounterElements.Length; i++)
            {
                functions[i] = (x) => $"More Yippies{x}!";
                cursorCounterElements[i] = CursorOutputElement<string>.Create(name: "Yippie" + i, counter: 0, func: functions[i]);
            }
            CursorCounterMenu cursorMenu = CursorCounterMenu.Create(0, '>', cursorCounterElements);
            IScreen screen = BoxedOutputScreen<string, string>.Create("Yippie", [cursorMenu], input: () => cursorCounterElements[0].ApplyFunction() + cursorCounterElements[1].ApplyFunction(), output: (x) => x);

            currentCursorMenu = cursorMenu;
            currentScreen = screen;
        }
        */
    }
}
