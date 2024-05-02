using System;
using System.Collections.Generic;
using System.Text;

namespace InteractiveTerminalAPI.UI.Cursor
{
    public abstract class BaseCursorMenu<T> : ITextElement where T : CursorElement
    {
        public char cursorCharacter = '>';
        public int cursorIndex;
        public T[] elements;

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

        public abstract string GetText(int availableLength);
    }
}
