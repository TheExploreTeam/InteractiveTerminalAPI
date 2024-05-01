using UnityEngine;

namespace InteractiveTerminalAPI.Misc.Util
{
    internal static class LGUConstants
    {
        #region General

        #region Characters
        internal const char WHITE_SPACE = ' ';
        #endregion

        #region Hex Colors

        internal const string HEXADECIMAL_RED = "#FF0000";
        internal const string HEXADECIMAL_WHITE = "#FFFFFF";
        internal const string HEXADECIMAL_GREEN = "#00FF00";

        #endregion

        #endregion

        #region Keybinds

        internal const string MOVE_CURSOR_UP_KEYBIND_NAME = "Move Cursor Up in the current application";
        internal const string MOVE_CURSOR_UP_DEFAULT_KEYBIND = "<Keyboard>/w";

        internal const string MOVE_CURSOR_DOWN_KEYBIND_NAME = "Move Cursor Down in the current application";
        internal const string MOVE_CURSOR_DOWN_DEFAULT_KEYBIND = "<Keyboard>/s";

        internal const string EXIT_STORE_KEYBIND_NAME = "Exit application";
        internal const string EXIT_STORE_DEFAULT_KEYBIND = "<Keyboard>/escape";

        internal const string NEXT_PAGE_KEYBIND_NAME = "Next Page in the current application";
        internal const string NEXT_PAGE_DEFAULT_KEYBIND = "<Keyboard>/d";

        internal const string PREVIOUS_PAGE_KEYBIND_NAME = "Previous Page in the current application";
        internal const string PREVIOUS_PAGE_DEFAULT_KEYBIND = "<Keyboard>/a";

        internal const string SUBMIT_PROMPT_KEYBIND_NAME = "Submit Prompt in the current application";
        internal const string SUBMIT_PROMPT_DEFAULT_KEYBIND = "<Keyboard>/enter";

        #endregion

        #region LGU Store Interactive UI

        #region Main Screen

        internal const string MAIN_SCREEN_TITLE = "Lategame Upgrades";
        internal const string MAIN_SCREEN_TOP_TEXT = "Select an upgrade to purchase:";

        internal const string MAIN_WEATHER_PROBE_SCREEN_TITLE = "Weather Probe";
        internal const string MAIN_WEATHER_PROBE_TOP_TEXT = "Select a moon you wish to alter the weather of:";

        #endregion

        #region Weather Display

        internal const string SELECT_WEATHER_FORMAT = "Select the available weathers for {0}:";
        internal const string CURRENT_WEATHER_FORMAT = "Current weather: {0}";

        internal const string CONFIRM_WEATHER_FORMAT = "Do you wish to change {0}'s weather to {1} for {2} credits?";
        internal const string CONFIRM_RANDOM_WEATHER_FORMAT = "Do you wish to randomize {0}'s weather for {1} credits?";
        internal const string CONFIRM_CLEAR_WEATHER_FORMAT = "Do you wish to clear {0}'s weather for {1} credits?";

        internal const string WEATHER_CHANGED_FORMAT = "{0}'s weather has changed to {1}. Thank you for your purchase.";
        internal const string NOT_ENOUGH_CREDITS_PROBE = "You do not have enough credits to purchase a randomized weather probe.";
        internal const string NOT_ENOUGH_CREDITS_SPECIFIED_PROBE = "You do not have enough credits to purchase a specified weather probe.";

        #endregion

        #region Upgrade Display

        internal const string NOT_ENOUGH_CREDITS = "You do not have enough credits to purchase this upgrade.";
        internal const string REACHED_MAX_LEVEL = "You have reached the maximum level of this upgrade.";
        internal const string PURCHASE_UPGRADE_FORMAT = "Do you wish to purchase this upgrade for {0} credits?";

        #endregion

        #region Cursor Display
        internal const char CURSOR = '>';

        internal const string SELECTED_CURSOR_ELEMENT_FORMAT = "<mark={0}><color={1}>{2}</color></mark>";
        internal const string DEFAULT_BACKGROUND_SELECTED_COLOR = HEXADECIMAL_GREEN + "33";
        internal const string DEFAULT_TEXT_SELECTED_COLOR = HEXADECIMAL_WHITE + "FF";

        internal const string GO_BACK_PROMPT = "Back";

        internal const string CONFIRM_PROMPT = "Confirm";
        internal const string CANCEL_PROMPT = "Abort";
        #endregion

        #region Screen Display
        internal const int AVAILABLE_CHARACTERS_PER_LINE = 51;
        internal const char TOP_LEFT_CORNER = '╭';
        internal const char TOP_RIGHT_CORNER = '╮';
        internal const char BOTTOM_LEFT_CORNER = '╰';
        internal const char BOTTOM_RIGHT_CORNER = '╯';
        internal const char VERTICAL_LINE = '│';
        internal const char HORIZONTAL_LINE = '─';

        internal const char CONNECTING_TITLE_LEFT = '╢';
        internal const char CONNECTING_TITLE_RIGHT = '╟';
        internal const char TOP_RIGHT_TITLE_CORNER = '╗';
        internal const char TOP_LEFT_TITLE_CORNER = '╔';
        internal const char BOTTOM_RIGHT_TITLE_CORNER = '╝';
        internal const char BOTTOM_LEFT_TITLE_CORNER = '╚';
        internal const char VERTICAL_TITLE_LINE = '║';
        internal const char HORIZONTAL_TITLE_LINE = '═';

        #region Page Display
        internal const int START_PAGE_COUNTER = 30;
        #endregion

        #region Upgrades Display
        internal const int NAME_LENGTH = 17;
        internal const int LEVEL_LENGTH = 7;

        internal const char EMPTY_LEVEL = '○';
        internal const char FILLED_LEVEL = '●';
        #endregion

        #endregion

        #region Colours
        internal static readonly Color Invisible = new Color(0, 0, 0, 0);
        #endregion

        #endregion
    }
}
