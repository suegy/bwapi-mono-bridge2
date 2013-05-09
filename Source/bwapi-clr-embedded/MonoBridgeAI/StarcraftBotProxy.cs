using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using SWIG;

namespace MonoBridgeAI
{
	public class StarcraftBotProxy
	{
		private BWAPI.IStarcraftBot realBot=null;
		private string err = "";

		public StarcraftBotProxy()
		{
			string dll = Path.Combine( Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Properties.Settings.Default.BotDLL);
			if (!File.Exists(dll)) { err = "DLL ["+dll+"] not Found"; return; }

			Assembly a = Assembly.LoadFile(dll);
			if (a == null) { err = "Could not load Assembly"; return; }

			Type botType = a.GetExportedTypes().Where((t) => (t.GetInterfaces().Contains(typeof(BWAPI.IStarcraftBot)))).FirstOrDefault();
			if (botType == null) { err = "No Types implement IStarcraftBot"; return; }

			var ci = botType.GetConstructor(new Type[0]);
			if (ci == null) { err = "No Constructor that take 0 arguments for ["+botType.FullName+"]"; return; }

			realBot = (BWAPI.IStarcraftBot)ci.Invoke(new object[0]);
		}

		public void onStart()
		{
			SWIG.BWAPI.bwapi.Broodwar.sendText("Loaded C# Module!");

			if (realBot == null)
                SWIG.BWAPI.bwapi.Broodwar.sendText("dotNet: " + this.err);
			else
				realBot.onStart();
		}

		public void onEnd(bool isWinner)
		{
			if (realBot != null)
				realBot.onEnd(isWinner);
		}

		public void onFrame()
		{
			if (realBot != null)
				realBot.onFrame();
		}

		public void onSendText(string text)
		{
			if (realBot != null)
				realBot.onSendText(text);
		}

		public void onReceiveText(long p_player, string text)
		{
            SWIG.BWAPI.Player player = BWAPI.Helper.NewPlayer(new IntPtr(p_player));
			if (realBot != null)
				realBot.onReceiveText(player, text);
		}

		public void onPlayerLeft(long p_player)
		{
            SWIG.BWAPI.Player player = BWAPI.Helper.NewPlayer(new IntPtr(p_player));
			if (realBot != null)
				realBot.onPlayerLeft(player);
		}

		public void onNukeDetect(long p_pos)
		{
            SWIG.BWAPI.Position pos = BWAPI.Helper.NewPosition(new IntPtr(p_pos));
			if (realBot != null)
				realBot.onNukeDetect(pos);
		}

		public void onUnitDiscover(long p_unit)
		{
            SWIG.BWAPI.Unit unit = BWAPI.Helper.NewUnit(new IntPtr(p_unit));
			if (realBot != null)
				realBot.onUnitDiscover(unit);
		}

		public void onUnitEvade(long p_unit)
		{
            SWIG.BWAPI.Unit unit = BWAPI.Helper.NewUnit(new IntPtr(p_unit));
			if (realBot != null)
				realBot.onUnitEvade(unit);
		}

		public void onUnitShow(long p_unit)
		{
            SWIG.BWAPI.Unit unit = BWAPI.Helper.NewUnit(new IntPtr(p_unit));
			if (realBot != null)
				realBot.onUnitShow(unit);
		}

		public void onUnitHide(long p_unit)
		{
            SWIG.BWAPI.Unit unit = BWAPI.Helper.NewUnit(new IntPtr(p_unit));
			if (realBot != null)
				realBot.onUnitHide(unit);
		}

		public void onUnitCreate(long p_unit)
		{
            SWIG.BWAPI.Unit unit = BWAPI.Helper.NewUnit(new IntPtr(p_unit));
			if (realBot != null)
				realBot.onUnitCreate(unit);
		}

		public void onUnitDestroy(long p_unit)
		{
            SWIG.BWAPI.Unit unit = BWAPI.Helper.NewUnit(new IntPtr(p_unit));
			if (realBot != null)
				realBot.onUnitDestroy(unit);
		}

		public void onUnitMorph(long p_unit)
		{
            SWIG.BWAPI.Unit unit = BWAPI.Helper.NewUnit(new IntPtr(p_unit));
			if (realBot != null)
				realBot.onUnitMorph(unit);
		}

		public void onUnitRenegade(long p_unit)
		{
            SWIG.BWAPI.Unit unit = BWAPI.Helper.NewUnit(new IntPtr(p_unit));
			if (realBot != null)
				realBot.onUnitRenegade(unit);
		}

		public void onSaveGame(string gameName)
		{
			if (realBot != null)
				realBot.onSaveGame(gameName);
		}
	}
}
