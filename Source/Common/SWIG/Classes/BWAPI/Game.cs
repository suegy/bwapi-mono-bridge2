//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.5
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace SWIG.BWAPI {

public partial class Game : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Game(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Game obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          throw new global::System.MethodAccessException("C++ destructor does not have public access");
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  
public override int GetHashCode()
{
   return this.swigCPtr.Handle.GetHashCode();
}

public override bool Equals(object obj)
{
    bool equal = false;
    if (obj is Game)
      equal = (((Game)obj).swigCPtr.Handle == this.swigCPtr.Handle);
    return equal;
}
  
public bool Equals(Game obj) 
{
    if (obj == null) return false;
    return (obj.swigCPtr.Handle == this.swigCPtr.Handle);
}

public static bool operator ==(Game obj1, Game obj2)
{
    if (object.ReferenceEquals(obj1, obj2)) return true;
    if (object.ReferenceEquals(obj1, null)) return false;
    if (object.ReferenceEquals(obj2, null)) return false;
   
    return obj1.Equals(obj2);
}

public static bool operator !=(Game obj1, Game obj2)
{
    if (object.ReferenceEquals(obj1, obj2)) return false;
    if (object.ReferenceEquals(obj1, null)) return true;
    if (object.ReferenceEquals(obj2, null)) return true;

    return !obj1.Equals(obj2);
}




  public virtual ForcePtrSet getForces() {
    ForcePtrSet ret = new ForcePtrSet(bwapiPINVOKE.Game_getForces(swigCPtr), false);
    return ret;
  }

  public virtual PlayerPtrSet getPlayers() {
    PlayerPtrSet ret = new PlayerPtrSet(bwapiPINVOKE.Game_getPlayers(swigCPtr), false);
    return ret;
  }

  public virtual UnitPtrSet getAllUnits() {
    UnitPtrSet ret = new UnitPtrSet(bwapiPINVOKE.Game_getAllUnits(swigCPtr), false);
    return ret;
  }

  public virtual UnitPtrSet getMinerals() {
    UnitPtrSet ret = new UnitPtrSet(bwapiPINVOKE.Game_getMinerals(swigCPtr), false);
    return ret;
  }

  public virtual UnitPtrSet getGeysers() {
    UnitPtrSet ret = new UnitPtrSet(bwapiPINVOKE.Game_getGeysers(swigCPtr), false);
    return ret;
  }

  public virtual UnitPtrSet getNeutralUnits() {
    UnitPtrSet ret = new UnitPtrSet(bwapiPINVOKE.Game_getNeutralUnits(swigCPtr), false);
    return ret;
  }

  public virtual UnitPtrSet getStaticMinerals() {
    UnitPtrSet ret = new UnitPtrSet(bwapiPINVOKE.Game_getStaticMinerals(swigCPtr), false);
    return ret;
  }

  public virtual UnitPtrSet getStaticGeysers() {
    UnitPtrSet ret = new UnitPtrSet(bwapiPINVOKE.Game_getStaticGeysers(swigCPtr), false);
    return ret;
  }

  public virtual UnitPtrSet getStaticNeutralUnits() {
    UnitPtrSet ret = new UnitPtrSet(bwapiPINVOKE.Game_getStaticNeutralUnits(swigCPtr), false);
    return ret;
  }

  public virtual BulletPtrSet getBullets() {
    BulletPtrSet ret = new BulletPtrSet(bwapiPINVOKE.Game_getBullets(swigCPtr), false);
    return ret;
  }

  public virtual PositionSet getNukeDots() {
    PositionSet ret = new PositionSet(bwapiPINVOKE.Game_getNukeDots(swigCPtr), false);
    return ret;
  }

  public virtual EventList getEvents() {
    EventList ret = new EventList(bwapiPINVOKE.Game_getEvents(swigCPtr), false);
    return ret;
  }

  public virtual Force getForce(int forceID) {
    global::System.IntPtr cPtr = bwapiPINVOKE.Game_getForce(swigCPtr, forceID);
    Force ret = (cPtr == global::System.IntPtr.Zero) ? null : new Force(cPtr, false);
    return ret;
  }

  public virtual Player getPlayer(int playerID) {
    global::System.IntPtr cPtr = bwapiPINVOKE.Game_getPlayer(swigCPtr, playerID);
    Player ret = (cPtr == global::System.IntPtr.Zero) ? null : new Player(cPtr, false);
    return ret;
  }

  public virtual Unit getUnit(int unitID) {
    global::System.IntPtr cPtr = bwapiPINVOKE.Game_getUnit(swigCPtr, unitID);
    Unit ret = (cPtr == global::System.IntPtr.Zero) ? null : new Unit(cPtr, false);
    return ret;
  }

  public virtual Unit indexToUnit(int unitIndex) {
    global::System.IntPtr cPtr = bwapiPINVOKE.Game_indexToUnit(swigCPtr, unitIndex);
    Unit ret = (cPtr == global::System.IntPtr.Zero) ? null : new Unit(cPtr, false);
    return ret;
  }

  public virtual SWIGTYPE_p_Region getRegion(int regionID) {
    global::System.IntPtr cPtr = bwapiPINVOKE.Game_getRegion(swigCPtr, regionID);
    SWIGTYPE_p_Region ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_Region(cPtr, false);
    return ret;
  }

  public virtual GameType getGameType() {
    GameType ret = new GameType(bwapiPINVOKE.Game_getGameType(swigCPtr), true);
    return ret;
  }

  public virtual int getLatency() {
    int ret = bwapiPINVOKE.Game_getLatency(swigCPtr);
    return ret;
  }

  public virtual int getFrameCount() {
    int ret = bwapiPINVOKE.Game_getFrameCount(swigCPtr);
    return ret;
  }

  public virtual int getFPS() {
    int ret = bwapiPINVOKE.Game_getFPS(swigCPtr);
    return ret;
  }

  public virtual double getAverageFPS() {
    double ret = bwapiPINVOKE.Game_getAverageFPS(swigCPtr);
    return ret;
  }

  public virtual Position getMousePosition() {
    Position ret = new Position(bwapiPINVOKE.Game_getMousePosition(swigCPtr), true);
    return ret;
  }

  public virtual bool getMouseState(MouseButton button) {
    bool ret = bwapiPINVOKE.Game_getMouseState__SWIG_0(swigCPtr, Button);
    return ret;
  }

  public virtual bool getMouseState(int button) {
    bool ret = bwapiPINVOKE.Game_getMouseState__SWIG_1(swigCPtr, button);
    return ret;
  }

  public virtual bool getKeyState(Key key) {
    bool ret = bwapiPINVOKE.Game_getKeyState__SWIG_0(swigCPtr, (int)key);
    return ret;
  }

  public virtual bool getKeyState(int key) {
    bool ret = bwapiPINVOKE.Game_getKeyState__SWIG_1(swigCPtr, key);
    return ret;
  }

  public virtual Position getScreenPosition() {
    Position ret = new Position(bwapiPINVOKE.Game_getScreenPosition(swigCPtr), true);
    return ret;
  }

  public virtual void setScreenPosition(int x, int y) {
    bwapiPINVOKE.Game_setScreenPosition__SWIG_0(swigCPtr, x, y);
  }

  public virtual void setScreenPosition(Position p) {
    bwapiPINVOKE.Game_setScreenPosition__SWIG_1(swigCPtr, Position.getCPtr(p));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void pingMinimap(int x, int y) {
    bwapiPINVOKE.Game_pingMinimap__SWIG_0(swigCPtr, x, y);
  }

  public virtual void pingMinimap(Position p) {
    bwapiPINVOKE.Game_pingMinimap__SWIG_1(swigCPtr, Position.getCPtr(p));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual bool isFlagEnabled(int flag) {
    bool ret = bwapiPINVOKE.Game_isFlagEnabled(swigCPtr, flag);
    return ret;
  }

  public virtual void enableFlag(int flag) {
    bwapiPINVOKE.Game_enableFlag(swigCPtr, flag);
  }

  public virtual UnitPtrSet getUnitsOnTile(int tileX, int tileY) {
    UnitPtrSet ret = new UnitPtrSet(bwapiPINVOKE.Game_getUnitsOnTile(swigCPtr, tileX, tileY), false);
    return ret;
  }

  public virtual UnitPtrSet getUnitsInRectangle(int left, int top, int right, int bottom) {
    UnitPtrSet ret = new UnitPtrSet(bwapiPINVOKE.Game_getUnitsInRectangle__SWIG_0(swigCPtr, left, top, right, bottom), false);
    return ret;
  }

  public virtual UnitPtrSet getUnitsInRectangle(Position topLeft, Position bottomRight) {
    UnitPtrSet ret = new UnitPtrSet(bwapiPINVOKE.Game_getUnitsInRectangle__SWIG_1(swigCPtr, Position.getCPtr(topLeft), Position.getCPtr(bottomRight)), false);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual UnitPtrSet getUnitsInRadius(Position center, int radius) {
    UnitPtrSet ret = new UnitPtrSet(bwapiPINVOKE.Game_getUnitsInRadius(swigCPtr, Position.getCPtr(center), radius), false);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual Error getLastError() {
    Error ret = new Error(bwapiPINVOKE.Game_getLastError(swigCPtr), true);
    return ret;
  }

  public virtual bool setLastError(Error e) {
    bool ret = bwapiPINVOKE.Game_setLastError(swigCPtr, Error.getCPtr(e));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int mapWidth() {
    int ret = bwapiPINVOKE.Game_mapWidth(swigCPtr);
    return ret;
  }

  public virtual int mapHeight() {
    int ret = bwapiPINVOKE.Game_mapHeight(swigCPtr);
    return ret;
  }

  public virtual string mapFileName() {
    string ret = bwapiPINVOKE.Game_mapFileName(swigCPtr);
    return ret;
  }

  public virtual string mapPathName() {
    string ret = bwapiPINVOKE.Game_mapPathName(swigCPtr);
    return ret;
  }

  public virtual string mapName() {
    string ret = bwapiPINVOKE.Game_mapName(swigCPtr);
    return ret;
  }

  public virtual string mapHash() {
    string ret = bwapiPINVOKE.Game_mapHash(swigCPtr);
    return ret;
  }

  public virtual bool isWalkable(int walkX, int walkY) {
    bool ret = bwapiPINVOKE.Game_isWalkable(swigCPtr, walkX, walkY);
    return ret;
  }

  public virtual int getGroundHeight(int tileX, int tileY) {
    int ret = bwapiPINVOKE.Game_getGroundHeight__SWIG_0(swigCPtr, tileX, tileY);
    return ret;
  }

  public virtual int getGroundHeight(TilePosition position) {
    int ret = bwapiPINVOKE.Game_getGroundHeight__SWIG_1(swigCPtr, TilePosition.getCPtr(position));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool isBuildable(int tileX, int tileY, bool includeBuildings) {
    bool ret = bwapiPINVOKE.Game_isBuildable__SWIG_0(swigCPtr, tileX, tileY, includeBuildings);
    return ret;
  }

  public virtual bool isBuildable(int tileX, int tileY) {
    bool ret = bwapiPINVOKE.Game_isBuildable__SWIG_1(swigCPtr, tileX, tileY);
    return ret;
  }

  public virtual bool isBuildable(TilePosition position, bool includeBuildings) {
    bool ret = bwapiPINVOKE.Game_isBuildable__SWIG_2(swigCPtr, TilePosition.getCPtr(position), includeBuildings);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool isBuildable(TilePosition position) {
    bool ret = bwapiPINVOKE.Game_isBuildable__SWIG_3(swigCPtr, TilePosition.getCPtr(position));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool isVisible(int tileX, int tileY) {
    bool ret = bwapiPINVOKE.Game_isVisible__SWIG_0(swigCPtr, tileX, tileY);
    return ret;
  }

  public virtual bool isVisible(TilePosition position) {
    bool ret = bwapiPINVOKE.Game_isVisible__SWIG_1(swigCPtr, TilePosition.getCPtr(position));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool isExplored(int tileX, int tileY) {
    bool ret = bwapiPINVOKE.Game_isExplored__SWIG_0(swigCPtr, tileX, tileY);
    return ret;
  }

  public virtual bool isExplored(TilePosition position) {
    bool ret = bwapiPINVOKE.Game_isExplored__SWIG_1(swigCPtr, TilePosition.getCPtr(position));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool hasCreep(int tileX, int tileY) {
    bool ret = bwapiPINVOKE.Game_hasCreep__SWIG_0(swigCPtr, tileX, tileY);
    return ret;
  }

  public virtual bool hasCreep(TilePosition position) {
    bool ret = bwapiPINVOKE.Game_hasCreep__SWIG_1(swigCPtr, TilePosition.getCPtr(position));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool hasPower(int tileX, int tileY, UnitType unitType) {
    bool ret = bwapiPINVOKE.Game_hasPower__SWIG_0(swigCPtr, tileX, tileY, UnitType.getCPtr(unitType));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool hasPower(int tileX, int tileY) {
    bool ret = bwapiPINVOKE.Game_hasPower__SWIG_1(swigCPtr, tileX, tileY);
    return ret;
  }

  public virtual bool hasPower(TilePosition position, UnitType unitType) {
    bool ret = bwapiPINVOKE.Game_hasPower__SWIG_2(swigCPtr, TilePosition.getCPtr(position), UnitType.getCPtr(unitType));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool hasPower(TilePosition position) {
    bool ret = bwapiPINVOKE.Game_hasPower__SWIG_3(swigCPtr, TilePosition.getCPtr(position));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool hasPower(int tileX, int tileY, int tileWidth, int tileHeight, UnitType unitType) {
    bool ret = bwapiPINVOKE.Game_hasPower__SWIG_4(swigCPtr, tileX, tileY, tileWidth, tileHeight, UnitType.getCPtr(unitType));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool hasPower(int tileX, int tileY, int tileWidth, int tileHeight) {
    bool ret = bwapiPINVOKE.Game_hasPower__SWIG_5(swigCPtr, tileX, tileY, tileWidth, tileHeight);
    return ret;
  }

  public virtual bool hasPower(TilePosition position, int tileWidth, int tileHeight, UnitType unitType) {
    bool ret = bwapiPINVOKE.Game_hasPower__SWIG_6(swigCPtr, TilePosition.getCPtr(position), tileWidth, tileHeight, UnitType.getCPtr(unitType));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool hasPower(TilePosition position, int tileWidth, int tileHeight) {
    bool ret = bwapiPINVOKE.Game_hasPower__SWIG_7(swigCPtr, TilePosition.getCPtr(position), tileWidth, tileHeight);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool hasPowerPrecise(int x, int y, UnitType unitType) {
    bool ret = bwapiPINVOKE.Game_hasPowerPrecise__SWIG_0(swigCPtr, x, y, UnitType.getCPtr(unitType));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool hasPowerPrecise(int x, int y) {
    bool ret = bwapiPINVOKE.Game_hasPowerPrecise__SWIG_1(swigCPtr, x, y);
    return ret;
  }

  public virtual bool hasPowerPrecise(Position position, UnitType unitType) {
    bool ret = bwapiPINVOKE.Game_hasPowerPrecise__SWIG_2(swigCPtr, Position.getCPtr(position), UnitType.getCPtr(unitType));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool hasPowerPrecise(Position position) {
    bool ret = bwapiPINVOKE.Game_hasPowerPrecise__SWIG_3(swigCPtr, Position.getCPtr(position));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool canBuildHere(Unit builder, TilePosition position, UnitType type, bool checkExplored) {
    bool ret = bwapiPINVOKE.Game_canBuildHere__SWIG_0(swigCPtr, Unit.getCPtr(builder), TilePosition.getCPtr(position), UnitType.getCPtr(type), checkExplored);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool canBuildHere(Unit builder, TilePosition position, UnitType type) {
    bool ret = bwapiPINVOKE.Game_canBuildHere__SWIG_1(swigCPtr, Unit.getCPtr(builder), TilePosition.getCPtr(position), UnitType.getCPtr(type));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool canMake(Unit builder, UnitType type) {
    bool ret = bwapiPINVOKE.Game_canMake(swigCPtr, Unit.getCPtr(builder), UnitType.getCPtr(type));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool canResearch(Unit unit, TechType type) {
    bool ret = bwapiPINVOKE.Game_canResearch(swigCPtr, Unit.getCPtr(unit), TechType.getCPtr(type));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool canUpgrade(Unit unit, UpgradeType type) {
    bool ret = bwapiPINVOKE.Game_canUpgrade(swigCPtr, Unit.getCPtr(unit), UpgradeType.getCPtr(type));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual TilePositionSet getStartLocations() {
    TilePositionSet ret = new TilePositionSet(bwapiPINVOKE.Game_getStartLocations(swigCPtr), false);
    return ret;
  }

  public virtual void printf(string format) {
    bwapiPINVOKE.Game_printf(swigCPtr, format);
  }

  public virtual void sendText(string format) {
    bwapiPINVOKE.Game_sendText(swigCPtr, format);
  }

  public virtual void sendTextEx(bool toAllies, string format) {
    bwapiPINVOKE.Game_sendTextEx(swigCPtr, toAllies, format);
  }

  public virtual void changeRace(Race race) {
    bwapiPINVOKE.Game_changeRace(swigCPtr, Race.getCPtr(race));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual bool isInGame() {
    bool ret = bwapiPINVOKE.Game_isInGame(swigCPtr);
    return ret;
  }

  public virtual bool isMultiplayer() {
    bool ret = bwapiPINVOKE.Game_isMultiplayer(swigCPtr);
    return ret;
  }

  public virtual bool isBattleNet() {
    bool ret = bwapiPINVOKE.Game_isBattleNet(swigCPtr);
    return ret;
  }

  public virtual bool isPaused() {
    bool ret = bwapiPINVOKE.Game_isPaused(swigCPtr);
    return ret;
  }

  public virtual bool isReplay() {
    bool ret = bwapiPINVOKE.Game_isReplay(swigCPtr);
    return ret;
  }

  public virtual void startGame() {
    bwapiPINVOKE.Game_startGame(swigCPtr);
  }

  public virtual void pauseGame() {
    bwapiPINVOKE.Game_pauseGame(swigCPtr);
  }

  public virtual void resumeGame() {
    bwapiPINVOKE.Game_resumeGame(swigCPtr);
  }

  public virtual void leaveGame() {
    bwapiPINVOKE.Game_leaveGame(swigCPtr);
  }

  public virtual void restartGame() {
    bwapiPINVOKE.Game_restartGame(swigCPtr);
  }

  public virtual void setLocalSpeed(int speed) {
    bwapiPINVOKE.Game_setLocalSpeed__SWIG_0(swigCPtr, speed);
  }

  public virtual void setLocalSpeed() {
    bwapiPINVOKE.Game_setLocalSpeed__SWIG_1(swigCPtr);
  }

  public virtual bool issueCommand(UnitPtrSet units, UnitCommand command) {
    bool ret = bwapiPINVOKE.Game_issueCommand(swigCPtr, UnitPtrSet.getCPtr(units), UnitCommand.getCPtr(command));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual UnitPtrSet getSelectedUnits() {
    UnitPtrSet ret = new UnitPtrSet(bwapiPINVOKE.Game_getSelectedUnits(swigCPtr), false);
    return ret;
  }

  public virtual Player self() {
    global::System.IntPtr cPtr = bwapiPINVOKE.Game_self(swigCPtr);
    Player ret = (cPtr == global::System.IntPtr.Zero) ? null : new Player(cPtr, false);
    return ret;
  }

  public virtual Player enemy() {
    global::System.IntPtr cPtr = bwapiPINVOKE.Game_enemy(swigCPtr);
    Player ret = (cPtr == global::System.IntPtr.Zero) ? null : new Player(cPtr, false);
    return ret;
  }

  public virtual Player neutral() {
    global::System.IntPtr cPtr = bwapiPINVOKE.Game_neutral(swigCPtr);
    Player ret = (cPtr == global::System.IntPtr.Zero) ? null : new Player(cPtr, false);
    return ret;
  }

  public virtual PlayerPtrSet allies() {
    PlayerPtrSet ret = new PlayerPtrSet(bwapiPINVOKE.Game_allies(swigCPtr), false);
    return ret;
  }

  public virtual PlayerPtrSet enemies() {
    PlayerPtrSet ret = new PlayerPtrSet(bwapiPINVOKE.Game_enemies(swigCPtr), false);
    return ret;
  }

  public virtual PlayerPtrSet observers() {
    PlayerPtrSet ret = new PlayerPtrSet(bwapiPINVOKE.Game_observers(swigCPtr), false);
    return ret;
  }

  public virtual void setTextSize(int size) {
    bwapiPINVOKE.Game_setTextSize__SWIG_0(swigCPtr, size);
  }

  public virtual void setTextSize() {
    bwapiPINVOKE.Game_setTextSize__SWIG_1(swigCPtr);
  }

  public virtual void drawText(int ctype, int x, int y, string format) {
    bwapiPINVOKE.Game_drawText(swigCPtr, ctype, x, y, format);
  }

  public virtual void drawTextMap(int x, int y, string format) {
    bwapiPINVOKE.Game_drawTextMap(swigCPtr, x, y, format);
  }

  public virtual void drawTextMouse(int x, int y, string format) {
    bwapiPINVOKE.Game_drawTextMouse(swigCPtr, x, y, format);
  }

  public virtual void drawTextScreen(int x, int y, string format) {
    bwapiPINVOKE.Game_drawTextScreen(swigCPtr, x, y, format);
  }

  public virtual void drawBox(int ctype, int left, int top, int right, int bottom, Color color, bool isSolid) {
    bwapiPINVOKE.Game_drawBox__SWIG_0(swigCPtr, ctype, left, top, right, bottom, Color.getCPtr(color), isSolid);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawBox(int ctype, int left, int top, int right, int bottom, Color color) {
    bwapiPINVOKE.Game_drawBox__SWIG_1(swigCPtr, ctype, left, top, right, bottom, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawBoxMap(int left, int top, int right, int bottom, Color color, bool isSolid) {
    bwapiPINVOKE.Game_drawBoxMap__SWIG_0(swigCPtr, left, top, right, bottom, Color.getCPtr(color), isSolid);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawBoxMap(int left, int top, int right, int bottom, Color color) {
    bwapiPINVOKE.Game_drawBoxMap__SWIG_1(swigCPtr, left, top, right, bottom, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawBoxMouse(int left, int top, int right, int bottom, Color color, bool isSolid) {
    bwapiPINVOKE.Game_drawBoxMouse__SWIG_0(swigCPtr, left, top, right, bottom, Color.getCPtr(color), isSolid);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawBoxMouse(int left, int top, int right, int bottom, Color color) {
    bwapiPINVOKE.Game_drawBoxMouse__SWIG_1(swigCPtr, left, top, right, bottom, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawBoxScreen(int left, int top, int right, int bottom, Color color, bool isSolid) {
    bwapiPINVOKE.Game_drawBoxScreen__SWIG_0(swigCPtr, left, top, right, bottom, Color.getCPtr(color), isSolid);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawBoxScreen(int left, int top, int right, int bottom, Color color) {
    bwapiPINVOKE.Game_drawBoxScreen__SWIG_1(swigCPtr, left, top, right, bottom, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawTriangle(int ctype, int ax, int ay, int bx, int by, int cx, int cy, Color color, bool isSolid) {
    bwapiPINVOKE.Game_drawTriangle__SWIG_0(swigCPtr, ctype, ax, ay, bx, by, cx, cy, Color.getCPtr(color), isSolid);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawTriangle(int ctype, int ax, int ay, int bx, int by, int cx, int cy, Color color) {
    bwapiPINVOKE.Game_drawTriangle__SWIG_1(swigCPtr, ctype, ax, ay, bx, by, cx, cy, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawTriangleMap(int ax, int ay, int bx, int by, int cx, int cy, Color color, bool isSolid) {
    bwapiPINVOKE.Game_drawTriangleMap__SWIG_0(swigCPtr, ax, ay, bx, by, cx, cy, Color.getCPtr(color), isSolid);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawTriangleMap(int ax, int ay, int bx, int by, int cx, int cy, Color color) {
    bwapiPINVOKE.Game_drawTriangleMap__SWIG_1(swigCPtr, ax, ay, bx, by, cx, cy, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawTriangleMouse(int ax, int ay, int bx, int by, int cx, int cy, Color color, bool isSolid) {
    bwapiPINVOKE.Game_drawTriangleMouse__SWIG_0(swigCPtr, ax, ay, bx, by, cx, cy, Color.getCPtr(color), isSolid);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawTriangleMouse(int ax, int ay, int bx, int by, int cx, int cy, Color color) {
    bwapiPINVOKE.Game_drawTriangleMouse__SWIG_1(swigCPtr, ax, ay, bx, by, cx, cy, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawTriangleScreen(int ax, int ay, int bx, int by, int cx, int cy, Color color, bool isSolid) {
    bwapiPINVOKE.Game_drawTriangleScreen__SWIG_0(swigCPtr, ax, ay, bx, by, cx, cy, Color.getCPtr(color), isSolid);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawTriangleScreen(int ax, int ay, int bx, int by, int cx, int cy, Color color) {
    bwapiPINVOKE.Game_drawTriangleScreen__SWIG_1(swigCPtr, ax, ay, bx, by, cx, cy, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawCircle(int ctype, int x, int y, int radius, Color color, bool isSolid) {
    bwapiPINVOKE.Game_drawCircle__SWIG_0(swigCPtr, ctype, x, y, radius, Color.getCPtr(color), isSolid);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawCircle(int ctype, int x, int y, int radius, Color color) {
    bwapiPINVOKE.Game_drawCircle__SWIG_1(swigCPtr, ctype, x, y, radius, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawCircleMap(int x, int y, int radius, Color color, bool isSolid) {
    bwapiPINVOKE.Game_drawCircleMap__SWIG_0(swigCPtr, x, y, radius, Color.getCPtr(color), isSolid);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawCircleMap(int x, int y, int radius, Color color) {
    bwapiPINVOKE.Game_drawCircleMap__SWIG_1(swigCPtr, x, y, radius, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawCircleMouse(int x, int y, int radius, Color color, bool isSolid) {
    bwapiPINVOKE.Game_drawCircleMouse__SWIG_0(swigCPtr, x, y, radius, Color.getCPtr(color), isSolid);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawCircleMouse(int x, int y, int radius, Color color) {
    bwapiPINVOKE.Game_drawCircleMouse__SWIG_1(swigCPtr, x, y, radius, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawCircleScreen(int x, int y, int radius, Color color, bool isSolid) {
    bwapiPINVOKE.Game_drawCircleScreen__SWIG_0(swigCPtr, x, y, radius, Color.getCPtr(color), isSolid);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawCircleScreen(int x, int y, int radius, Color color) {
    bwapiPINVOKE.Game_drawCircleScreen__SWIG_1(swigCPtr, x, y, radius, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawEllipse(int ctype, int x, int y, int xrad, int yrad, Color color, bool isSolid) {
    bwapiPINVOKE.Game_drawEllipse__SWIG_0(swigCPtr, ctype, x, y, xrad, yrad, Color.getCPtr(color), isSolid);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawEllipse(int ctype, int x, int y, int xrad, int yrad, Color color) {
    bwapiPINVOKE.Game_drawEllipse__SWIG_1(swigCPtr, ctype, x, y, xrad, yrad, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawEllipseMap(int x, int y, int xrad, int yrad, Color color, bool isSolid) {
    bwapiPINVOKE.Game_drawEllipseMap__SWIG_0(swigCPtr, x, y, xrad, yrad, Color.getCPtr(color), isSolid);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawEllipseMap(int x, int y, int xrad, int yrad, Color color) {
    bwapiPINVOKE.Game_drawEllipseMap__SWIG_1(swigCPtr, x, y, xrad, yrad, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawEllipseMouse(int x, int y, int xrad, int yrad, Color color, bool isSolid) {
    bwapiPINVOKE.Game_drawEllipseMouse__SWIG_0(swigCPtr, x, y, xrad, yrad, Color.getCPtr(color), isSolid);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawEllipseMouse(int x, int y, int xrad, int yrad, Color color) {
    bwapiPINVOKE.Game_drawEllipseMouse__SWIG_1(swigCPtr, x, y, xrad, yrad, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawEllipseScreen(int x, int y, int xrad, int yrad, Color color, bool isSolid) {
    bwapiPINVOKE.Game_drawEllipseScreen__SWIG_0(swigCPtr, x, y, xrad, yrad, Color.getCPtr(color), isSolid);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawEllipseScreen(int x, int y, int xrad, int yrad, Color color) {
    bwapiPINVOKE.Game_drawEllipseScreen__SWIG_1(swigCPtr, x, y, xrad, yrad, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawDot(int ctype, int x, int y, Color color) {
    bwapiPINVOKE.Game_drawDot(swigCPtr, ctype, x, y, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawDotMap(int x, int y, Color color) {
    bwapiPINVOKE.Game_drawDotMap(swigCPtr, x, y, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawDotMouse(int x, int y, Color color) {
    bwapiPINVOKE.Game_drawDotMouse(swigCPtr, x, y, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawDotScreen(int x, int y, Color color) {
    bwapiPINVOKE.Game_drawDotScreen(swigCPtr, x, y, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawLine(int ctype, int x1, int y1, int x2, int y2, Color color) {
    bwapiPINVOKE.Game_drawLine(swigCPtr, ctype, x1, y1, x2, y2, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawLineMap(int x1, int y1, int x2, int y2, Color color) {
    bwapiPINVOKE.Game_drawLineMap(swigCPtr, x1, y1, x2, y2, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawLineMouse(int x1, int y1, int x2, int y2, Color color) {
    bwapiPINVOKE.Game_drawLineMouse(swigCPtr, x1, y1, x2, y2, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void drawLineScreen(int x1, int y1, int x2, int y2, Color color) {
    bwapiPINVOKE.Game_drawLineScreen(swigCPtr, x1, y1, x2, y2, Color.getCPtr(color));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual SWIGTYPE_p_void getScreenBuffer() {
    global::System.IntPtr cPtr = bwapiPINVOKE.Game_getScreenBuffer(swigCPtr);
    SWIGTYPE_p_void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_void(cPtr, false);
    return ret;
  }

  public virtual int getLatencyFrames() {
    int ret = bwapiPINVOKE.Game_getLatencyFrames(swigCPtr);
    return ret;
  }

  public virtual int getLatencyTime() {
    int ret = bwapiPINVOKE.Game_getLatencyTime(swigCPtr);
    return ret;
  }

  public virtual int getRemainingLatencyFrames() {
    int ret = bwapiPINVOKE.Game_getRemainingLatencyFrames(swigCPtr);
    return ret;
  }

  public virtual int getRemainingLatencyTime() {
    int ret = bwapiPINVOKE.Game_getRemainingLatencyTime(swigCPtr);
    return ret;
  }

  public virtual int getRevision() {
    int ret = bwapiPINVOKE.Game_getRevision(swigCPtr);
    return ret;
  }

  public virtual bool isDebug() {
    bool ret = bwapiPINVOKE.Game_isDebug(swigCPtr);
    return ret;
  }

  public virtual bool isLatComEnabled() {
    bool ret = bwapiPINVOKE.Game_isLatComEnabled(swigCPtr);
    return ret;
  }

  public virtual void setLatCom(bool isEnabled) {
    bwapiPINVOKE.Game_setLatCom(swigCPtr, isEnabled);
  }

  public virtual int getReplayFrameCount() {
    int ret = bwapiPINVOKE.Game_getReplayFrameCount(swigCPtr);
    return ret;
  }

  public virtual void setGUI(bool enabled) {
    bwapiPINVOKE.Game_setGUI__SWIG_0(swigCPtr, enabled);
  }

  public virtual void setGUI() {
    bwapiPINVOKE.Game_setGUI__SWIG_1(swigCPtr);
  }

  public virtual int getInstanceNumber() {
    int ret = bwapiPINVOKE.Game_getInstanceNumber(swigCPtr);
    return ret;
  }

  public virtual int getAPM(bool includeSelects) {
    int ret = bwapiPINVOKE.Game_getAPM__SWIG_0(swigCPtr, includeSelects);
    return ret;
  }

  public virtual int getAPM() {
    int ret = bwapiPINVOKE.Game_getAPM__SWIG_1(swigCPtr);
    return ret;
  }

  public virtual bool setMap(string mapFileName) {
    bool ret = bwapiPINVOKE.Game_setMap(swigCPtr, mapFileName);
    return ret;
  }

  public virtual void setFrameSkip(int frameSkip) {
    bwapiPINVOKE.Game_setFrameSkip__SWIG_0(swigCPtr, frameSkip);
  }

  public virtual void setFrameSkip() {
    bwapiPINVOKE.Game_setFrameSkip__SWIG_1(swigCPtr);
  }

  public virtual bool hasPath(Position source, Position destination) {
    bool ret = bwapiPINVOKE.Game_hasPath(swigCPtr, Position.getCPtr(source), Position.getCPtr(destination));
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool setAlliance(Player player, bool allied, bool alliedVictory) {
    bool ret = bwapiPINVOKE.Game_setAlliance__SWIG_0(swigCPtr, Player.getCPtr(player), allied, alliedVictory);
    return ret;
  }

  public virtual bool setAlliance(Player player, bool allied) {
    bool ret = bwapiPINVOKE.Game_setAlliance__SWIG_1(swigCPtr, Player.getCPtr(player), allied);
    return ret;
  }

  public virtual bool setAlliance(Player player) {
    bool ret = bwapiPINVOKE.Game_setAlliance__SWIG_2(swigCPtr, Player.getCPtr(player));
    return ret;
  }

  public virtual bool setVision(Player player, bool enabled) {
    bool ret = bwapiPINVOKE.Game_setVision__SWIG_0(swigCPtr, Player.getCPtr(player), enabled);
    return ret;
  }

  public virtual bool setVision(Player player) {
    bool ret = bwapiPINVOKE.Game_setVision__SWIG_1(swigCPtr, Player.getCPtr(player));
    return ret;
  }

  public virtual int elapsedTime() {
    int ret = bwapiPINVOKE.Game_elapsedTime(swigCPtr);
    return ret;
  }

  public virtual void setCommandOptimizationLevel(int level) {
    bwapiPINVOKE.Game_setCommandOptimizationLevel__SWIG_0(swigCPtr, level);
  }

  public virtual void setCommandOptimizationLevel() {
    bwapiPINVOKE.Game_setCommandOptimizationLevel__SWIG_1(swigCPtr);
  }

  public virtual int countdownTimer() {
    int ret = bwapiPINVOKE.Game_countdownTimer(swigCPtr);
    return ret;
  }

  public virtual SWIGTYPE_p_std__setT_BWAPI__Region_p_t getAllRegions() {
    SWIGTYPE_p_std__setT_BWAPI__Region_p_t ret = new SWIGTYPE_p_std__setT_BWAPI__Region_p_t(bwapiPINVOKE.Game_getAllRegions(swigCPtr), false);
    return ret;
  }

  public virtual SWIGTYPE_p_BWAPI__Region getRegionAt(int x, int y) {
    global::System.IntPtr cPtr = bwapiPINVOKE.Game_getRegionAt__SWIG_0(swigCPtr, x, y);
    SWIGTYPE_p_BWAPI__Region ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_BWAPI__Region(cPtr, false);
    return ret;
  }

  public virtual SWIGTYPE_p_BWAPI__Region getRegionAt(Position position) {
    global::System.IntPtr cPtr = bwapiPINVOKE.Game_getRegionAt__SWIG_1(swigCPtr, Position.getCPtr(position));
    SWIGTYPE_p_BWAPI__Region ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_BWAPI__Region(cPtr, false);
    if (bwapiPINVOKE.SWIGPendingException.Pending) throw bwapiPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int getLastEventTime() {
    int ret = bwapiPINVOKE.Game_getLastEventTime(swigCPtr);
    return ret;
  }

  public virtual bool setReplayVision(Player player, bool enabled) {
    bool ret = bwapiPINVOKE.Game_setReplayVision__SWIG_0(swigCPtr, Player.getCPtr(player), enabled);
    return ret;
  }

  public virtual bool setReplayVision(Player player) {
    bool ret = bwapiPINVOKE.Game_setReplayVision__SWIG_1(swigCPtr, Player.getCPtr(player));
    return ret;
  }

  public virtual bool setRevealAll(bool reveal) {
    bool ret = bwapiPINVOKE.Game_setRevealAll__SWIG_0(swigCPtr, reveal);
    return ret;
  }

  public virtual bool setRevealAll() {
    bool ret = bwapiPINVOKE.Game_setRevealAll__SWIG_1(swigCPtr);
    return ret;
  }

}

}
