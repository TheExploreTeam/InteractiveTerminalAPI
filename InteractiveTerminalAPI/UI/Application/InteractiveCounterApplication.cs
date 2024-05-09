using InteractiveTerminalAPI.Input;
using InteractiveTerminalAPI.UI.Cursor;
using InteractiveTerminalAPI.UI.Screen;
using System;
using static UnityEngine.InputSystem.InputAction;

namespace InteractiveTerminalAPI.UI.Application
{
    public abstract class InteractiveCounterApplication<K,V> : BaseInteractiveApplication<K,V> where K : BaseCursorCounterMenu<V> where V : CursorCounterElement
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
    }
}
