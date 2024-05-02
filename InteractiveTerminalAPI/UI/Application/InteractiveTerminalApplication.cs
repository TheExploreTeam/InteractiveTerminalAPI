using InteractiveTerminalAPI.Misc.Util;
using InteractiveTerminalAPI.UI.Cursor;
using InteractiveTerminalAPI.UI.Screen;
using System;

namespace InteractiveTerminalAPI.UI.Application
{
    public abstract class InteractiveTerminalApplication : BaseInteractiveApplication<CursorMenu, CursorElement>
    {
        protected void Confirm(string title, string description, Action confirmAction, Action declineAction, string additionalMessage = "")
        {
            CursorElement[] cursorElements =
                [
                    CursorElement.Create(name: APIConstants.CONFIRM_PROMPT, action: confirmAction),
                    CursorElement.Create(name: APIConstants.CANCEL_PROMPT, action: declineAction),
                ];
            CursorMenu cursorMenu = CursorMenu.Create(elements: cursorElements);

            ITextElement[] elements =
                [
                    TextElement.Create(description),
                    TextElement.Create(" "),
                    TextElement.Create(additionalMessage),
                    cursorMenu
                ];
            IScreen screen = BoxedScreen.Create(title: title, elements: elements);

            SwitchScreen(screen, cursorMenu, false);
        }
        protected void ErrorMessage(string title, Action backAction, string error)
        {
            CursorElement[] cursorElements = [CursorElement.Create(name: APIConstants.GO_BACK_PROMPT, action: backAction)];
            CursorMenu cursorMenu = CursorMenu.Create(startingCursorIndex: 0, elements: cursorElements);
            ITextElement[] elements =
                [
                    TextElement.Create(text: error),
                    TextElement.Create(" "),
                    cursorMenu
                ];
            IScreen screen = BoxedScreen.Create(title: title, elements: elements);
            SwitchScreen(screen, cursorMenu, false);
        }
        protected void ErrorMessage(string title, string description, Action backAction, string error)
        {
            CursorElement[] cursorElements =
                [
                    CursorElement.Create(name: APIConstants.GO_BACK_PROMPT, action: backAction)
                ];
            CursorMenu cursorMenu = CursorMenu.Create(startingCursorIndex: 0, elements: cursorElements);
            ITextElement[] elements =
                [
                    TextElement.Create(text: description),
                    TextElement.Create(" "),
                    TextElement.Create(text: error),
                    TextElement.Create(" "),
                    cursorMenu
                ];
            IScreen screen = BoxedScreen.Create(title: title, elements: elements);
            SwitchScreen(screen, cursorMenu, false);
        }
    }
}
