using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SWIG.BWAPI;
using BWAPI;

namespace StarcraftBotLib
{
    public class BODStarCraftBot : IStarcraftBot
    {
        void IStarcraftBot.onStart()
        {
            System.Console.WriteLine("Starting Match!");
            bwapi.Broodwar.sendText("Hello world!");
        }

        void IStarcraftBot.onEnd(bool isWinner)
        {
            //throw new NotImplementedException();
        }

        void IStarcraftBot.onFrame()
        {
            //throw new NotImplementedException();
        }

        void IStarcraftBot.onSendText(string text)
        {
            //throw new NotImplementedException();
        }

        void IStarcraftBot.onReceiveText(SWIG.BWAPI.Player player, string text)
        {
            //throw new NotImplementedException();
        }

        void IStarcraftBot.onPlayerLeft(SWIG.BWAPI.Player player)
        {
            //throw new NotImplementedException();
        }

        void IStarcraftBot.onNukeDetect(SWIG.BWAPI.Position target)
        {
            //throw new NotImplementedException();
        }

        void IStarcraftBot.onUnitDiscover(SWIG.BWAPI.Unit unit)
        {
            //throw new NotImplementedException();
        }

        void IStarcraftBot.onUnitEvade(SWIG.BWAPI.Unit unit)
        {
            //throw new NotImplementedException();
        }

        void IStarcraftBot.onUnitShow(SWIG.BWAPI.Unit unit)
        {
            //throw new NotImplementedException();
        }

        void IStarcraftBot.onUnitHide(SWIG.BWAPI.Unit unit)
        {
            //throw new NotImplementedException();
        }

        void IStarcraftBot.onUnitCreate(SWIG.BWAPI.Unit unit)
        {
            //throw new NotImplementedException();
        }

        void IStarcraftBot.onUnitDestroy(SWIG.BWAPI.Unit unit)
        {
            //throw new NotImplementedException();
        }

        void IStarcraftBot.onUnitMorph(SWIG.BWAPI.Unit unit)
        {
            //throw new NotImplementedException();
        }

        void IStarcraftBot.onUnitRenegade(SWIG.BWAPI.Unit unit)
        {
            //throw new NotImplementedException();
        }

        void IStarcraftBot.onSaveGame(string gameName)
        {
            //throw new NotImplementedException();
        }
    }
}
