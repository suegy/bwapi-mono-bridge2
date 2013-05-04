This folder contains the source for bwapi-mono-bridge2 http://code.google.com/p/bwapi-mono-bridge2

you need to copy this folder inside the bwapi source folder to use the headers othwerwise the project will not compile

The layout is as follows:


bwapi-clr-client
- Source for the BWAPIClient client/server based bot/interface
     bwapi-clr
      -The BWAPI library exposed as .net/mono classes
     bwapi-native
      -Native c++ project that includes the BWAPI and BWTA libraries and exposes them for use by bwapi-clr
     testbot
      -A quick example of directly using the BWAPI and BWTA via the client/server functions (.net/mono)
     MonoAIModuleLoader
      -A project that will load bots that implement IStarcraftBot (from bwapi-clr). These bots are more similiar to the embedded BWAPI style AI Modules
     Debug/release-binaries
      -This is where the output binaries are placed after compile (for easier deployment)

MonoBridgeAI
- Source for the BWAPI embedded AIModule based bot/interface
     monobridgeai-interop
      -The BWAPI library exposed as .net/mono classes
     MonoBridge
      -Native c++ project that includes the BWAPI and BWTA libraries and exposes them for use by bwapi-clr. 
      -Loads MonoBridgeAI .net assembly via a copy of the mono runtime embedded in the starcraft process
     MonoBridgeAI
      -Loads the bot ai from the dll specified in the monobridgeai.config file. Bot must implement IStarcraftBot (declared in monobridgeai-interop)
     Release
      -This is where the output binaries are placed after compile (for easier deployment)

StarcraftBot
- Source for a bot that implements IStarcraftBot interface and can be loaded by either the in process MonoBridgeAI or client/server bwapi-clr-client\MonoAILModuleLoader