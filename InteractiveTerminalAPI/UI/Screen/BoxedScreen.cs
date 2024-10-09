using System.Text;
using InteractiveTerminalAPI.Misc.Util;
using InteractiveTerminalAPI.Util;

namespace InteractiveTerminalAPI.UI.Screen
{
    public class BoxedScreen : IScreen
    {
        public string Title;
        public ITextElement[] elements;
        public virtual string GetText(int availableLength)
        {
            string title = Title;
            if (Title.Length > availableLength - 6) title = title.Substring(0, availableLength - 6);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine().AppendLine();
            sb.Append(new string(APIConstants.WHITE_SPACE, 1))
                .Append(APIConstants.TOP_LEFT_TITLE_CORNER)
                .Append(new string(APIConstants.HORIZONTAL_TITLE_LINE, title.Length + 2))
                .Append(APIConstants.TOP_RIGHT_TITLE_CORNER)
                .AppendLine();
            sb.Append(APIConstants.TOP_LEFT_CORNER)
                .Append(APIConstants.CONNECTING_TITLE_LEFT)
                .Append(APIConstants.WHITE_SPACE)
                .Append(title)
                .Append(APIConstants.WHITE_SPACE)
                .Append(APIConstants.CONNECTING_TITLE_RIGHT)
                .Append(new string(APIConstants.HORIZONTAL_LINE, availableLength - 6 - title.Length))
                .Append(APIConstants.TOP_RIGHT_CORNER)
                .AppendLine();
            sb.Append(APIConstants.VERTICAL_LINE)
                .Append(APIConstants.BOTTOM_LEFT_TITLE_CORNER)
                .Append(new string(APIConstants.HORIZONTAL_TITLE_LINE, title.Length + 2))
                .Append(APIConstants.BOTTOM_RIGHT_TITLE_CORNER)
                .Append(new string(APIConstants.WHITE_SPACE, availableLength - 6 - title.Length))
                .Append(APIConstants.VERTICAL_LINE)
                .AppendLine();
            for (int i = 0; i < elements.Length; i++)
            {
                sb.Append(Tools.WrapText(elements[i].GetText(availableLength - 4), availableLength, leftPadding: "│ ", rightPadding: " │"));
            }
            sb.Append(APIConstants.BOTTOM_LEFT_CORNER)
                .Append(new string(APIConstants.HORIZONTAL_LINE, availableLength - 2))
                .Append(APIConstants.BOTTOM_RIGHT_CORNER)
                .AppendLine();


            return sb.ToString();
        }

        public static BoxedScreen Create(string title = "", ITextElement[] elements = default)
        {
            return new BoxedScreen()
            {
                Title = title,
                elements = elements
            };
        }
    }
}
