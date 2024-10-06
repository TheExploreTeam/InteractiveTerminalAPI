using InteractiveTerminalAPI.Misc.Util;
using InteractiveTerminalAPI.Util;
using System;
using System.Text;

namespace InteractiveTerminalAPI.UI.Hierarchy
{
    public class HierarchyElement : ITextElement
    {
        public char IntersectionCharacter { get; set; } = APIConstants.INTERSECTION;
        public char LastIntersectionCharacter { get; set; } = APIConstants.LAST_INTERSECTION;
        public char SpacingCharacter { get; set; } = APIConstants.SPACING;
        public int Spacing { get; set; } = APIConstants.SPACING_AMOUNT;
        public char VerticalSpacingCharacter { get; set; } = APIConstants.VERTICAL_SPACING;
        public int VerticalSpacing { get; set; } = APIConstants.VERTICAL_SPACING_AMOUNT;
        public string Title { get; set; }
        public ITextElement[] textElements { get; set; }
        public string GetText(int availableLength)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Title + "\n");
            int verticalSpacing = 0;
            for (int i = 0; i < textElements.Length;)
            {
                ITextElement element = textElements[i];
                if (verticalSpacing != VerticalSpacing)
                {
                    sb.Append(VerticalSpacingCharacter + "\n");
                    verticalSpacing++;
                    continue;
                }
                verticalSpacing = 0;
                bool last = i == textElements.Length - 1;
                if (last)
                {
                    sb.Append(LastIntersectionCharacter);
                }
                else
                {
                    sb.Append(IntersectionCharacter);
                }
                sb.Append(new string(SpacingCharacter, Spacing));
                sb.Append(APIConstants.WHITE_SPACE);
                if (element is HierarchyElement)
                {
                    sb.Append(Tools.WrapText(element.GetText(availableLength - 2 - Spacing), availableLength - 2 - Spacing, leftPadding: (!last ? new string(VerticalSpacingCharacter, 1) : "") + new string(APIConstants.WHITE_SPACE, Spacing + 1), padLeftFirst: false));
                }
                else
                {
                    if (last)
                    {
                        sb.Append(Tools.WrapText(element.GetText(availableLength - 2 - Spacing), availableLength - 2 - Spacing));
                    }
                    else
                    {
                        sb.Append(Tools.WrapText(element.GetText(availableLength - 5 - Spacing), availableLength - 5 - Spacing, leftPadding: new string(VerticalSpacingCharacter, 1), padLeftFirst: false));
                    }
                }
                i++;
            }
            return sb.ToString();
        }

        public static HierarchyElement Create(string title, ITextElement[] textElements, int spacing = APIConstants.SPACING_AMOUNT, char intersectionCharacter = APIConstants.INTERSECTION, char lastIntersectionCharacter = APIConstants.LAST_INTERSECTION, char spacingCharacter = APIConstants.SPACING) 
        {
            return new HierarchyElement()
            {
                Title = title,
                textElements = textElements,
                Spacing = spacing,
                IntersectionCharacter = intersectionCharacter,
                LastIntersectionCharacter = lastIntersectionCharacter,
                SpacingCharacter = spacingCharacter
            };
        }
    }
}
