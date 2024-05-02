using InteractiveTerminalAPI.Input;
using InteractiveTerminalAPI.Misc.Util;
using InteractiveTerminalAPI.UI.Cursor;
using InteractiveTerminalAPI.UI.Screen;
using System;
using static UnityEngine.InputSystem.InputAction;

namespace InteractiveTerminalAPI.UI.Application
{
    internal class InteractiveCounterApplication : InteractiveTerminalApplication
    {
        protected new CursorCounterMenu currentCursorMenu;
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
        internal override void MoveCursorUp()
        {
            currentCursorMenu.Backward();
        }
        internal override void MoveCursorDown()
        {
            currentCursorMenu.Forward();
        }
        public override void Submit()
        {
            currentCursorMenu.Execute();
        }

        public override void Initialization()
        {
            CursorCounterElement[] cursorCounterElements = new CursorCounterElement[10];
            for(int i = 0; i < cursorCounterElements.Length; i++)
                cursorCounterElements[i] = CursorOutputElement<int>.Create(name: "Yippie" + i, counter: 0, func: (x) => x*10);
            CursorCounterMenu cursorMenu = CursorCounterMenu.Create(0, '>', cursorCounterElements);
            IScreen screen = BoxedScreen.Create("Yippie", [cursorMenu]);

            currentCursorMenu = cursorMenu;
            currentScreen = screen;
        }
    }
}
