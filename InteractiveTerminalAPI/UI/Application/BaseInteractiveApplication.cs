using InteractiveTerminalAPI.Input;
using InteractiveTerminalAPI.Misc.Util;
using InteractiveTerminalAPI.UI.Cursor;
using InteractiveTerminalAPI.UI.Screen;
using System;
using System.Collections.Generic;
using System.Text;
using static UnityEngine.InputSystem.InputAction;

namespace InteractiveTerminalAPI.UI.Application
{
    public abstract class BaseInteractiveApplication<K,V> : TerminalApplication where K : BaseCursorMenu<V> where V : CursorElement
    {
        public K currentCursorMenu;
        protected override string GetApplicationText()
        {
            return currentScreen.GetText(APIConstants.AVAILABLE_CHARACTERS_PER_LINE);
        }
        protected override Action PreviousScreen()
        {
            return () => SwitchScreen(currentScreen, currentCursorMenu, previous: true);
        }

        protected override void AddInputBindings()
        {
            base.AddInputBindings();
            Keybinds.cursorUpAction.performed += OnApplicationCursorUp;
            Keybinds.cursorDownAction.performed += OnApplicationCursorDown;
            Keybinds.storeConfirmAction.performed += OnApplicationConfirm;
        }
        protected override void RemoveInputBindings()
        {
            base.RemoveInputBindings();
            Keybinds.cursorUpAction.performed -= OnApplicationCursorUp;
            Keybinds.cursorDownAction.performed -= OnApplicationCursorDown;
            Keybinds.storeConfirmAction.performed -= OnApplicationConfirm;
        }
        internal void OnApplicationConfirm(CallbackContext context)
        {
            Submit();
        }
        internal void OnApplicationCursorUp(CallbackContext context)
        {
            MoveCursorUp();
        }
        internal void OnApplicationCursorDown(CallbackContext context)
        {
            MoveCursorDown();
        }
        public void MoveCursorUp()
        {
            currentCursorMenu.Backward();
        }
        public void MoveCursorDown()
        {
            currentCursorMenu.Forward();
        }
        public void Submit()
        {
            currentCursorMenu.Execute();
        }
        protected virtual void SwitchScreen(IScreen screen, K cursorMenu, bool previous)
        {
            currentScreen = screen;
            currentCursorMenu = cursorMenu;
            if (!previous) cursorMenu.cursorIndex = 0;
        }
    }
}
