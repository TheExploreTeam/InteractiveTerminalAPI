using InteractiveTerminalAPI.Util;

namespace InteractiveTerminalAPI.UI
{
    public class TextElement : ITextElement
    {
        public string Text { get; set; }
        public string GetText(int availableLength)
        {
            return Tools.WrapText(Text, availableLength);
        }
        public static TextElement Create(string text = "")
        {
            return new TextElement()
            {
                Text = text
            };
        }
    }
}
