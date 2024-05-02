using InteractiveTerminalAPI.Misc.Util;
using System;
using System.Text;

namespace InteractiveTerminalAPI.UI.Cursor
{
    internal class CursorCounterElement : CursorElement
    {
        public int Counter { get; set; }

        public void IncrementCounter()
        {
            Counter++;
        }

        public void DecrementCounter()
        {
            if (Counter > 0) Counter--;
        }

        public override string GetText(int availableLength)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(APIConstants.LEFT_ARROW).Append(Counter).Append(APIConstants.RIGHT_ARROW).Append(APIConstants.WHITE_SPACE);
            sb.Append(base.GetText(availableLength));
            return sb.ToString();
        }
        public static new CursorCounterElement Create(string name = "", string description = "", Action action = default, int counter = 0)
        {
            return new CursorCounterElement()
            {
                Name = name,
                Description = description,
                Action = action,
                Counter = counter
            };
        }
    }
}
