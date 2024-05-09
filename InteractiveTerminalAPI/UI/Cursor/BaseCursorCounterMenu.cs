namespace InteractiveTerminalAPI.UI.Cursor
{
    public abstract class BaseCursorCounterMenu<T> : BaseCursorMenu<T> where T : CursorCounterElement
    {
        public void IncrementCounter()
        {
            elements[cursorIndex].IncrementCounter();
        }
        public void DecrementCounter()
        {
            elements[cursorIndex].DecrementCounter();
        }
    }
}
