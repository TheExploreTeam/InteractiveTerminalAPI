using InteractiveTerminalAPI.UI.Cursor;
using InteractiveTerminalAPI.UI.Screen;

namespace InteractiveTerminalAPI.UI.Page
{
    public class PageCursorElement : PageElement
    {
        internal CursorMenu[] cursorMenus;
        public CursorMenu GetCurrentCursorMenu()
        {
            return cursorMenus[pageIndex];
        }

        public static PageCursorElement Create(int startingPageIndex = 0, IScreen[] elements = default, CursorMenu[] cursorMenus = default)
        {
            return new PageCursorElement()
            {
                pageIndex = startingPageIndex,
                elements = elements,
                cursorMenus = cursorMenus
            };
        }
    }
}
