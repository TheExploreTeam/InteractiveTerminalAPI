using InteractiveTerminalAPI.Misc.Util;
using InteractiveTerminalAPI.UI.Screen;
using System.Text;

namespace InteractiveTerminalAPI.UI.Page
{
    public class PageElement : ITextElement
    {
        public int pageIndex;
        public IScreen[] elements;

        public string GetText(int availableLength)
        {
            IScreen selectedScreen = elements[pageIndex];
            StringBuilder sb = new StringBuilder();
            sb.Append(selectedScreen.GetText(availableLength));
            if (elements.Length > 1)
            {
                sb.Append(new string(APIConstants.WHITE_SPACE, availableLength - APIConstants.START_PAGE_COUNTER))
                    .Append($"Page {pageIndex + 1}/{elements.Length}");
            }

            return sb.ToString();
        }
        public void PageUp()
        {
            pageIndex = (pageIndex + 1) % elements.Length;
        }
        public void PageDown()
        {
            pageIndex--;
            if (pageIndex < 0) pageIndex = elements.Length - 1;
        }
        public void ResetPage()
        {
            pageIndex = 0;
        }
        public IScreen GetCurrentScreen()
        {
            return elements[pageIndex];
        }

        public static PageElement Create(int startingPageIndex = 0, IScreen[] elements = default)
        {
            return new PageElement()
            {
                pageIndex = startingPageIndex,
                elements = elements
            };
        }
    }
}
