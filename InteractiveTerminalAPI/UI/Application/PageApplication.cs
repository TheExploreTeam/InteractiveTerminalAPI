using InteractiveTerminalAPI.Input;
using InteractiveTerminalAPI.Misc.Util;
using InteractiveTerminalAPI.UI.Cursor;
using InteractiveTerminalAPI.UI.Page;
using InteractiveTerminalAPI.UI.Screen;
using System;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace InteractiveTerminalAPI.UI.Application
{
    public abstract class PageApplication : InteractiveTerminalApplication
    {
        protected PageCursorElement initialPage;
        protected PageCursorElement currentPage;
        protected override string GetApplicationText()
        {
            return currentScreen == currentPage.GetCurrentScreen() ? currentPage.GetText(APIConstants.AVAILABLE_CHARACTERS_PER_LINE) : currentScreen.GetText(APIConstants.AVAILABLE_CHARACTERS_PER_LINE);
        }
        protected virtual int GetEntriesPerPage<T>(T[] entries)
        {
            return Mathf.CeilToInt(entries.Length / 2f);
        }
        protected override Action PreviousScreen()
        {
            return () => ResetScreen();
        }

        protected virtual int GetAmountPages<T>(T[] entries)
        {
            return Mathf.CeilToInt(entries.Length / (float)GetEntriesPerPage(entries));
        }
        protected override void ChangeSorting()
        {
            currentPage.ChangeSorting();
        }
        public override void MoveCursorUp()
        {
            int cursorIndex = currentCursorMenu.cursorIndex;
            base.MoveCursorUp();
            if (currentPage.GetCurrentCursorMenu() == currentCursorMenu && currentCursorMenu.cursorIndex > cursorIndex)
            {
                ChangeScreenBackward();
                base.MoveCursorUp();
            }
        }
        public override void MoveCursorDown()
        {
            int cursorIndex = currentCursorMenu.cursorIndex;
            base.MoveCursorDown();
            if (currentPage.GetCurrentCursorMenu() == currentCursorMenu && currentCursorMenu.cursorIndex < cursorIndex)
            {
                ChangeScreenForward();
                currentCursorMenu.cursorIndex = 0;
            }
        }
        protected void ResetScreen()
        {
            SwitchScreen(initialPage, true);
        }
        protected void SwitchScreen(PageCursorElement pages, bool previous)
        {
            currentPage = pages;
            SwitchScreen(currentPage.GetCurrentScreen(), currentPage.GetCurrentCursorMenu(), previous);
        }
        protected override void SwitchScreen(IScreen screen, CursorMenu cursorMenu, bool previous)
        {
            base.SwitchScreen(screen, cursorMenu, previous);
            if (screen == currentPage.GetCurrentScreen())
            {
                Keybinds.pageUpAction.performed += OnApplicationPageUp;
                Keybinds.pageDownAction.performed += OnApplicationPageDown;
            }
            else
            {
                Keybinds.pageUpAction.performed -= OnApplicationPageUp;
                Keybinds.pageDownAction.performed -= OnApplicationPageDown;
            }
        }
        public void ChangeScreenForward()
        {
            currentPage.PageUp();
            SwitchScreen(currentPage.GetCurrentScreen(), currentPage.GetCurrentCursorMenu(), false);
        }
        public void ChangeScreenBackward()
        {
            currentPage.PageDown();
            SwitchScreen(currentPage.GetCurrentScreen(), currentPage.GetCurrentCursorMenu(), false);
        }
        protected override void AddInputBindings()
        {
            base.AddInputBindings();
            Keybinds.pageUpAction.performed += OnApplicationPageUp;
            Keybinds.pageDownAction.performed += OnApplicationPageDown;
        }
        protected override void RemoveInputBindings()
        {
            base.RemoveInputBindings();
            Keybinds.pageUpAction.performed -= OnApplicationPageUp;
            Keybinds.pageDownAction.performed -= OnApplicationPageDown;
        }

        protected (T[][], CursorMenu[], IScreen[]) GetPageEntries<T>(T[] entries)
        {
            int amountPages = GetAmountPages(entries);
            int lengthPerPage = GetEntriesPerPage(entries);

            T[][] pages = new T[amountPages][];
            for (int i = 0; i < amountPages; i++)
                pages[i] = new T[lengthPerPage];
            for (int i = 0; i < entries.Length; i++)
            {
                int row = i / lengthPerPage;
                int col = i % lengthPerPage;
                pages[row][col] = entries[i];
            }
            CursorMenu[] cursorMenus = new CursorMenu[pages.Length];
            IScreen[] screens = new IScreen[pages.Length];
            initialPage = PageCursorElement.Create(startingPageIndex: 0, cursorMenus: cursorMenus, elements: screens);

            return (pages, cursorMenus, screens);
        }
        internal void OnApplicationPageUp(CallbackContext context)
        {
            ChangeScreenForward();
        }
        internal void OnApplicationPageDown(CallbackContext context)
        {
            ChangeScreenBackward();
        }

    }
}
