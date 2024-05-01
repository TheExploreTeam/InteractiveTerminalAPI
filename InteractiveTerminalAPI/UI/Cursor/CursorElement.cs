using System;
using System.Text;
using InteractiveTerminalAPI.Util;

namespace InteractiveTerminalAPI.UI.Cursor
{
    public class CursorElement : ITextElement
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Action Action { get; set; }
        public virtual string GetText(int availableLength)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name);
            if (Description == null || Description == "") return sb.ToString();
            sb.AppendLine().Append(Tools.WrapText(Description, availableLength));
            return sb.ToString();
        }

        public static CursorElement Create(string name = "", string description = "", Action action = default)
        {
            return new CursorElement()
            {
                Name = name,
                Description = description,
                Action = action
            };
        }
    }
}
