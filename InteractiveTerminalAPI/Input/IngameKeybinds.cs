using InteractiveTerminalAPI.Misc.Util;
using LethalCompanyInputUtils.Api;
using UnityEngine.InputSystem;

namespace InteractiveTerminalAPI.Input
{
    /// <summary>
    /// Class which stores the used key binds in the mod
    /// </summary>
    internal class IngameKeybinds : LcInputActions
    {
        public static IngameKeybinds Instance;
        /// <summary>
        /// Asset used to store all the input bindings defined for our controls
        /// </summary>
        internal static InputActionAsset GetAsset()
        {
            return Instance.Asset;
        }

        /// <summary>
        /// Input binding used to trigger the move cursor up in the LGU interface action
        /// </summary>
        [InputAction(APIConstants.MOVE_CURSOR_UP_DEFAULT_KEYBIND, Name = APIConstants.MOVE_CURSOR_UP_KEYBIND_NAME)]
        public InputAction UpgradeStoreCursorUpKey { get; set; }

        /// <summary>
        /// Input binding used to trigger the move cursor down in the LGU interface action
        /// </summary>
        [InputAction(APIConstants.MOVE_CURSOR_DOWN_DEFAULT_KEYBIND, Name = APIConstants.MOVE_CURSOR_DOWN_KEYBIND_NAME)]
        public InputAction UpgradeStoreCursorDownKey { get; set; }

        /// <summary>
        /// Input binding used to trigger the exit LGU interface action
        /// </summary>
        [InputAction(APIConstants.EXIT_STORE_DEFAULT_KEYBIND, Name = APIConstants.EXIT_STORE_KEYBIND_NAME)]
        public InputAction UpgradeStoreCursorExitKey { get; set; }

        /// <summary>
        /// Input binding used to change to next page in the LGU interface action
        /// </summary>
        [InputAction(APIConstants.NEXT_PAGE_DEFAULT_KEYBIND, Name = APIConstants.NEXT_PAGE_KEYBIND_NAME)]
        public InputAction UpgradeStorePageUpKey { get; set; }

        /// <summary>
        /// Input binding used to change to previous page in the LGU interface action
        /// </summary>
        [InputAction(APIConstants.PREVIOUS_PAGE_DEFAULT_KEYBIND, Name = APIConstants.PREVIOUS_PAGE_KEYBIND_NAME)]
        public InputAction UpgradeStorePageDownKey { get; set; }

        /// <summary>
        /// Input binding used to submit current prompt in the LGU interface action
        /// </summary>
        [InputAction(APIConstants.SUBMIT_PROMPT_DEFAULT_KEYBIND, Name = APIConstants.SUBMIT_PROMPT_KEYBIND_NAME)]
        public InputAction LguStoreConfirmKey { get; set; }

    }
}
