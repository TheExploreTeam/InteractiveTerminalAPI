using InteractiveTerminalAPI.Input;
using InteractiveTerminalAPI.Misc.Util;
using InteractiveTerminalAPI.UI.Cursor;
using InteractiveTerminalAPI.UI.Screen;
using System;
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
            Keybinds.changeSortingAction.performed += OnApplicationChangeSorting;
            Keybinds.cursorUpAction.performed += OnApplicationCursorUp;
            Keybinds.cursorDownAction.performed += OnApplicationCursorDown;
            Keybinds.storeConfirmAction.performed += OnApplicationConfirm;
        }
        protected override void RemoveInputBindings()
        {
            base.RemoveInputBindings();
            Keybinds.changeSortingAction.performed -= OnApplicationChangeSorting;
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
        internal void OnApplicationChangeSorting(CallbackContext context)
        {
            ChangeSorting();
        }
        internal void OnApplicationCursorDown(CallbackContext context)
        {
            MoveCursorDown();
        }
        protected virtual void ChangeSorting()
        {
            currentCursorMenu.ChangeSorting();
        }
        public virtual void MoveCursorUp()
        {
            currentCursorMenu.Backward();
        }
        public virtual void MoveCursorDown()
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
