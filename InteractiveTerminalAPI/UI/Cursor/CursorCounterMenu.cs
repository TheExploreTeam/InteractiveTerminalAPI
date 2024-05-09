using InteractiveTerminalAPI.Misc.Util;
using InteractiveTerminalAPI.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace InteractiveTerminalAPI.UI.Cursor
{
    public class CursorCounterMenu : BaseCursorCounterMenu<CursorCounterElement>
    {
        public override string GetText(int availableLength)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < elements.Length; i++)
            {
                CursorCounterElement element = elements[i];
                if (element == null) continue;
                if (i == cursorIndex) sb.Append(cursorCharacter).Append(APIConstants.WHITE_SPACE); else sb.Append(APIConstants.WHITE_SPACE).Append(APIConstants.WHITE_SPACE);
                string text = element.GetText(availableLength - 2);
                string backgroundColor = element.Active(element) ? APIConstants.DEFAULT_BACKGROUND_SELECTED_COLOR : APIConstants.INACTIVE_BACKGROUND_SELECTED_COLOR;
                text = i == cursorIndex ? string.Format(APIConstants.SELECTED_CURSOR_ELEMENT_FORMAT, backgroundColor, APIConstants.DEFAULT_TEXT_SELECTED_COLOR, text) : text;
                sb.Append(Tools.WrapText(text, availableLength, leftPadding: "  ", rightPadding: "", false));
            }
            return sb.ToString();
        }

        public static CursorCounterMenu Create<T>(int startingCursorIndex = 0, char cursorCharacter = '>', T[] elements = default, Func<CursorElement, CursorElement, int>[] sorting = null) where T : CursorCounterElement
        {
            if (sorting == null)
            {
                sorting = new Func<CursorElement, CursorElement, int>[1];
                sorting[0] = (element1, element2) => string.Compare(element2.Name, element1.Name);
            }
            return new CursorCounterMenu()
            {
                cursorIndex = startingCursorIndex,
                cursorCharacter = cursorCharacter,
                elements = elements,
                SortingFunctions = sorting
            };
        }
    }
}
