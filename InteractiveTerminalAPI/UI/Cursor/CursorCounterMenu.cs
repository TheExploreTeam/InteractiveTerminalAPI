using InteractiveTerminalAPI.Misc.Util;
using InteractiveTerminalAPI.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace InteractiveTerminalAPI.UI.Cursor
{
    internal class CursorCounterMenu : ITextElement
    {
        public char cursorCharacter = '>';
        public int cursorIndex;
        public CursorCounterElement[] elements;

        public void Execute()
        {
            elements[cursorIndex].ExecuteAction();
        }
        public void Forward()
        {
            cursorIndex = (cursorIndex + 1) % elements.Length;
            while (elements[cursorIndex] == null)
            {
                cursorIndex = (cursorIndex + 1) % elements.Length;
            }
        }
        public void Backward()
        {
            cursorIndex--;
            if (cursorIndex < 0) cursorIndex = elements.Length - 1;
            while (elements[cursorIndex] == null)
            {
                cursorIndex--;
                if (cursorIndex < 0) cursorIndex = elements.Length - 1;
            }
        }

        public void ResetCursor()
        {
            cursorIndex = 0;
        }

        public void IncrementCounter()
        {
            elements[cursorIndex].IncrementCounter();
        }
        public void DecrementCounter()
        {
            elements[cursorIndex].DecrementCounter();
        }

        public string GetText(int availableLength)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < elements.Length; i++)
            {
                CursorCounterElement element = elements[i];
                if (element == null) continue;
                if (i == cursorIndex) sb.Append(cursorCharacter).Append(APIConstants.WHITE_SPACE); else sb.Append(APIConstants.WHITE_SPACE).Append(APIConstants.WHITE_SPACE);
                string text = element.GetText(availableLength - 2);
                text = i == cursorIndex ? string.Format(APIConstants.SELECTED_CURSOR_ELEMENT_FORMAT, APIConstants.DEFAULT_BACKGROUND_SELECTED_COLOR, APIConstants.DEFAULT_TEXT_SELECTED_COLOR, text) : text;
                sb.Append(Tools.WrapText(text, availableLength, leftPadding: "  ", rightPadding: "", false));
            }
            return sb.ToString();
        }

        public static CursorCounterMenu Create(int startingCursorIndex = 0, char cursorCharacter = '>', CursorCounterElement[] elements = default)
        {
            return new CursorCounterMenu()
            {
                cursorIndex = startingCursorIndex,
                cursorCharacter = cursorCharacter,
                elements = elements
            };
        }
    }
}
