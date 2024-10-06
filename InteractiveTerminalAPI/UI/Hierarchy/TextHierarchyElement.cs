using InteractiveTerminalAPI.Misc.Util;

namespace InteractiveTerminalAPI.UI.Hierarchy
{
    internal class TextHierarchyElement : BaseHierarchyElement<ITextElement>
    {
        public static TextHierarchyElement Create(string title, ITextElement[] textElements, int spacing = APIConstants.SPACING_AMOUNT, char intersectionCharacter = APIConstants.INTERSECTION, char lastIntersectionCharacter = APIConstants.LAST_INTERSECTION, char spacingCharacter = APIConstants.SPACING)
        {
            return new TextHierarchyElement()
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
