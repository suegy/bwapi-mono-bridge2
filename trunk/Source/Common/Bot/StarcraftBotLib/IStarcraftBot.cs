
using System;
using SWIG.BWAPI;

namespace BWAPI
{
	/// <summary>
	/// Base Class for Mono Starcraft Bots
	/// </summary>
	public interface IStarcraftBot
	{
		void onStart();
		void onEnd(bool isWinner);
		void onFrame();
		void onSendText(string text);
		void onReceiveText(Player player, string text);
		void onPlayerLeft(Player player);
		void onNukeDetect(Position target);
		void onUnitDiscover(Unit unit);
		void onUnitEvade(Unit unit);
		void onUnitShow(Unit unit);
		void onUnitHide(Unit unit);
		void onUnitCreate(Unit unit);
		void onUnitDestroy(Unit unit);
		void onUnitMorph(Unit unit);
		void onUnitRenegade(Unit unit);
		void onSaveGame(string gameName);
	}
}