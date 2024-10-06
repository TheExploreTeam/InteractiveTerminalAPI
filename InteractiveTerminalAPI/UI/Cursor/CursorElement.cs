using System;
using System.Text;
using InteractiveTerminalAPI.Misc.Util;
using InteractiveTerminalAPI.Util;

namespace InteractiveTerminalAPI.UI.Cursor
{
    public class CursorElement : ITextElement
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Func<CursorElement, bool> Active { get; set; } = (x) => true;
        public bool SelectInactive { get; set; } = true;
        public Action Action { get; set; }
        public virtual string GetText(int availableLength)
        {
            StringBuilder sb = new StringBuilder();
            if (!Active(this)) sb.Append(string.Format(APIConstants.COLOR_INITIAL_FORMAT, APIConstants.HEXADECIMAL_GREY));
            sb.Append(Name);
            if (Description != null & Description != "")
                sb.AppendLine().Append(Tools.WrapText(Description, availableLength));
            if (!Active(this)) sb.Append(APIConstants.COLOR_FINAL_FORMAT);
            return sb.ToString();
        }

        public virtual void ExecuteAction()
        {
            if (Action != null) Action();
        }

        public static CursorElement Create(string name = "", string description = "", Action action = default, Func<CursorElement, bool> active = null, bool selectInactive = true)
        {
            return new CursorElement()
            {
                Name = name,
                Description = description,
                Action = action,
                Active = active == null ? (_ => true) : active,
                SelectInactive = selectInactive
            };
        }
    }
}
