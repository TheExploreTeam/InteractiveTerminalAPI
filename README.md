# InteractiveTerminalAPI
A Lethal Company mod API which focuses on making terminal applications where the player can interact with besides inputting text to it

# Classes
## Application
### ``TerminalApplication``
- Most basic application to insert on the terminal
- Basically a fancy window to appear in the terminal
- Doesn't allow player interaction, they can only exit out of it

### ``InteractiveTerminalApplication : TerminalApplication``
- Basic application where the player can go through its listed options through their keybind configurations
- Selected option will appear with a different font and background compared to non-selected options
- The player can execute a prompt when pressing the respective keybind (enter by default) which executes the respective ``Action`` associated to that option

### ``PageApplication : InteractiveTerminalApplication``
- Application that allows moving through different screens (labelled pages) with same list of options.
- A page counter will appear at the bottom of the screen saying which screen they are currently located at.
- The player can change between screens through the respective keybinds ('a' and 'd' keys respectively)

## Cursor
### ``CursorElement : ITextElement``
- An entry in the screen in which the player can select to execute.
- #### Attributes
  - ``Name``: Name of the option displayed in the screen
  - ``Description``: Text to appear below the option displayed in the screen
  - ``Action``: Code to be executed when the player decides to submit this option

### ``CursorMenu : ITextElement``
- Manager of ``CursorElement`` to know which one is selected or not.
- #### Attributes
  - ``cursorCharacter``: What character to appear before the selected text
  - ``cursorIndex``: Current picked option displayed in the screen
  - ``elements``: List of options displayed in the screen

## Page
### ``PageElement : ITextElement``
- An entry where the player can switch between its screens
- #### Attributes
  - ``pageIndex``: Current selected screen to display to the player
  - ``elements``: List of screens the player can switch between

### ``PageCursorElement : PageElement``
- An entry where the player can switch between its screens and they are interactable
- #### Attributes
  - ``cursorMenus``: List of managers of ``CursorElement`` of the each screen
 
## Screen
### ``BoxedScreen : IScreen``
- Typical screen that shows:
  - A title on top left of the terminal
  - Surrounds the relevant text in a box-like manner to make it seem it's an application being open
 
### ``IScreen : ITextElement``
- An interface to represent a screen

## Text
### ``ITextElement``
- An interface for all components displayed in the terminal (screen, options, etc.)
- #### Methods
  - ``GetText(int availableLength)``: method which returns a string to be displayed in the terminal
    - ``availableLength`` is how many character space you have left to fill a line

## ``InteractiveTerminalManager``
- Responsible to make applications to appear in the terminal when prompted to.
- Relevant methods:
  - ``RegisterApplication<T>(string command) where T : TerminalApplication, new()``: method where you register your own custom application (where you specify through T) to appear on provided text prompt when typed in the terminal
  - ``RegisterApplication<T>(string[] commands) where T : TerminalApplication, new()``: method where you register your own custom application (where you specify through T) to appear on provided text prompts when typed in the terminal
