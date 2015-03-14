# A quick guide to set up a mono/C# Environment with BWAPI in Client Mode.

# Mono BWAPI in CLient Mode #

  * download BWAPI 3.7.X http://code.google.com/p/bwapi/downloads/detail?name=BWAPI%203.7.4.7z
  * extract archive into a preferred place
  * cd into the BWAPI folder
  * apply the patch to include\BWTA\RectangleArray.h
```
//------------------------------------------------ SET ITEM ------------------------------------------------
  template <class Type>
  void RectangleArray<Type>::setItem(unsigned int x, unsigned int y, Type* item)
  {
   //added *  
  this->getColumn(x)[y] = *item;
  }
```
  * git clone https://code.google.com/p/bwapi-mono-bridge2/
  * cd into bwapi-mono-bridge
  * open the StarcraftBot solution from the starcraftbot folder with VS 2008 sp1
  * edit the references of the starcraftbot project and remove bwapi-clr.dll and starcraftbotlib.dll
  * add references to starcraftbotlib.dll and bwapi-clr.dll from the libs\client folder
  * compile the project
  * Copy everything from the libs\client folder and place them into bwapi-data\ai in your starcraft folder. (this is not essential, the bot can be run from anywhere on your system, as long as the required files are in the same place)
  * copy starcraftbot.dll from your project bin folder to the bwapi-data\AI folder

## Running the Bot ##

To run the bot:

  * launch the ClrAiModuleLoader by running ClrAiModuleLoader.exe (it should say connecting...)
  * launch starcraft on the same computer (the bot should now say "waiting for match")
  * start a custom match against the computer.
  * the bot should print some stuff to the screen etc.