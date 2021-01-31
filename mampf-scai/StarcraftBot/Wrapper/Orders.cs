using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    enum Orders {
        /// <summary>
        /// Causes the unit to die. Normal units run the death iscript animation, while hallucinated units have the sound/sprite spawned and then are removed.
        /// Default Requirements: Allow on hallucinated units.
        /// </summary>
        Die = 0x00,
 
        /// <summary>
        /// Normal unit stop command. Stops current order chain, and then goes to idle.
        /// Default Requirements: Allow on hallucinated units.
        /// </summary>
        Stop = 0x01, 

        /// <summary>
        /// Generic Guard order. Determines what guard command a unit uses.
        /// Default Requirements: Unit responds to Battle Orders. Allow on hallucinated units.
        /// </summary>
        Guard = 0x02, 

        /// <summary>
        /// Attacking Mobile unit guard order.
        /// Default Requirements: Unit responds to Battle Orders. Allow on hallucinated units.
        /// </summary>
        PlayerGuard = 0x03, 

        /// <summary>
        /// Attacking unit turret guard.
        /// Default Requirements: Unit is a subunit. Allow on hallucinated units.
        /// </summary>
        TurretGuard = 0x04, 

        /// <summary>
        /// Transport building guard. Set when a building picks up a unit.
        /// Default Requirements: Unit must be a Terran Bunker.
        /// </summary>
        BunkerGuard = 0x05, 

        /// <summary>
        /// Unit move. Ignores enemies on way to destination.
        /// Default Requirements: Unit is able to move. Allow on hallucinated units.
        /// </summary>
        Move = 0x06, 

        /// <summary>
        /// Stop order for the reaver.
        /// Default Requirements: Unit must be Reaver/Warbringer. Allow on hallucinated units.
        /// </summary>
        ReaverStop = 0x07, 

        /// <summary>
        /// Generic attack order.
        /// Default Requirements: Unit responds to battle orders. Allow on hallucinated units. 
        /// </summary>
        Attack1 = 0x08, 

        /// <summary>
        /// Move to attack shrouded building.
        /// Default Requirements: Unit responds to battle orders. Allow on hallucinated units.
        /// </summary>
        Attack2 = 0x09, 

        /// <summary>
        /// Mobile unit attacking a unit/building.
        /// Default Requirements: Unit is able to move. Allow on hallucinated units.
        /// </summary>
        AttackUnit = 0x0A, 

        /// <summary>
        /// Attack for an immobile unit. Lurker attack.
        /// Default Requirements: Unit responds to battle orders. Allow on hallucinated units.
        /// </summary>
        AttackFixedRange = 0x0B, 

        /// <summary>
        /// Unused.
        /// Default Requirements: Unit responds to battle orders. Allow on hallucinated units.
        /// </summary>
        AttackTile = 0x0C, 

        /// <summary>
        /// Unused.
        /// Default Requirements: Unit is able to move. Allow on hallucinated units.
        /// </summary>
        Hover = 0x0D, 

        /// <summary>
        /// Unit move, attack enemies along path to target.
        /// Default Requirements: Unit is able to move. Allow on hallucinated units. 
        /// </summary>
        AttackMove = 0x0E, 

        /// <summary>
        /// Ran when a unit is being infested.
        /// Default Requirements: Unit must be Terran Command Center.
        /// </summary>
        InfestMine1 = 0x0F, 

        /// <summary>
        /// Unknown.
        /// </summary>
        UnusedNothing = 0x10, 

        /// <summary>
        /// Unknown. Speculated to be a Powerup being built order.
        /// </summary>
        UnusedPowerup = 0x11, 

        /// <summary>
        /// Building tower guard.
        /// Default Requirements: Unit must be either Photon Cannon, Missile Turret, Sunken Colony, or Spore Colony.
        /// </summary>
        TowerGuard = 0x12, 

        /// <summary>
        /// Building tower attack.
        /// Default Requirements: Unit must be either Photon Cannon, Missile Turret, Sunken Colony, Spore Colony, Floor Gun Trap, Left Wall Missile Trap, Left Wall Flame Trap, Right Wall Flame Trap, Right Wall Missile Trap
        /// </summary>
        TowerAttack = 0x13, 

        /// <summary>
        /// Spidermine idle order.
        /// Default Requirements: Unit must be Vulture Spider Mine.
        /// </summary>
        VultureMine = 0x14, 

        /// <summary>
        /// Mobile unit base attack.
        /// Default Requirements: Unit is able to move. Allow on hallucinated units.
        /// </summary>
        StayinRange = 0x15, 

        /// <summary>
        /// Mobile Unit Turret attack.
        /// Default Requirements: Must be subunit. Allow on hallucinated units.
        /// </summary>
        TurretAttack = 0x16, 

        /// <summary>
        /// Do nothing, next order.
        /// Default Requirements: Allow on hallucinated units.
        /// </summary>
        Nothing = 0x17, 

        /// <summary>
        /// Unknown, used when a unit is changing state between siege to normal and back.
        
        /// </summary>
        Nothing3ToFromSiegeMode = 0x18, 

        /// <summary>
        /// Move to target position and run drone build.
        /// Default Requirements: Unit must be Zerg Drone.
        /// </summary>
        DroneStartBuild = 0x19, 

        /// <summary>
        /// Check resources and run drone land.
        /// Default Requirements: Unit must be Zerg Drone.
        /// </summary>
        DroneBuild = 0x1A, 

        /// <summary>
        /// Move to Infest a unit.
        /// Default Requirements: Unit must be Zerg Queen/Matriarch.
        /// </summary>
        InfestMine2 = 0x1B, 

        /// <summary>
        /// Move to Infest shrouded unit.
        /// Default Requirements: Unit must be Zerg Queen/Matriarch.
        /// </summary>
        InfestMine3 = 0x1C, 

        /// <summary>
        /// Infest Unit. Hides unit, runs infest 1 on target, then reshows unit.
        /// Default Requirements: Unit must be Zerg Queen/Matriarch.
        /// </summary>
        InfestMine4 = 0x1D, 

        /// <summary>
        /// Move/Start Terran Building.
        /// Default Requirements: Unit must be Terran SCV. 
        /// </summary>
        BuildTerran = 0x1E, 
        
        /// <summary>
        /// Full Protoss Building order.
        /// Default Requirements: Unit must be Protoss Probe.
        /// </summary>
        BuildProtoss1 = 0x1F, 

        /// <summary>
        /// Creates the Protoss Building.
        /// Default Requirements: Unit must be Protoss Probe.
        /// </summary>
        BuildProtoss2 = 0x20, 

        /// <summary>
        /// SCV is building.
        /// Default Requirements: Unit must be Terran SCV.
        /// </summary>
        ConstructingBuilding = 0x21, 

        /// <summary>
        /// Repair Unit.
        /// Default Requirements: Unit must be Terran SCV.
        /// </summary>
        Repair1 = 0x22, 

        /// <summary>
        /// Move to repair shrouded building.
        /// Default Requirements: Unit must be Terran SCV.
        /// </summary>
        Repair2 = 0x23, 

        /// <summary>
        /// Move and start addon.
        /// Default Requirements: Blank.
        /// </summary>
        PlaceAddon = 0x24, 

        /// <summary>
        /// Building Addon.
        /// </summary>
        BuildAddon = 0x25, 

        /// <summary>
        /// Training Unit.
        /// </summary>
        Train = 0x26, 

        /// <summary>
        /// Rally to Visible Unit. Causes units to follow the selected unit.
        /// Default Requirements: Unit is able to set Rally Point.
        /// </summary>
        RallyPointUnit = 0x27, 

        /// <summary>
        /// Rally to tile position.
        /// Default Requirements: Unit is able to set Rally Point.
        /// </summary>
        RallyPointTile = 0x28, 

        /// <summary>
        /// Unit is being born.
        /// Default Requirements: Unit must be Zerg Egg or Zerg Cocoon.
        /// </summary>
        ZergBirth = 0x29, 

        /// <summary>
        /// Unit Morph.
        /// </summary>
        ZergUnitMorph = 0x2A, 

        /// <summary>
        /// Building Morph.
        /// </summary>
        ZergBuildingMorph = 0x2B, 

        /// <summary>
        /// Terran Building, Is being built.
        /// </summary>
        TerranBuildSelf = 0x2C, 

        /// <summary>
        /// Zerg Building build order.
        /// </summary>
        ZergBuildSelf = 0x2D, 

        /// <summary>
        /// Nydus canal exit build order.
        /// Default Requirements: Unit must be Zerg Nydus Canal and must not have exit.
        /// </summary>
        BuildNydusExit = 0x2E, 

        /// <summary>
        /// Enter/transport through nydus canal.
        /// </summary>
        EnterNydusCanal = 0x2F, 

        /// <summary>
        /// Protoss Building being built order.
        /// </summary>
        ProtossBuildSelf = 0x30, 

        /// <summary>
        /// Move to/with unit or building. Causes units to load into transports or enter nydus canal or recharge shields.
        /// </summary>
        Follow = 0x31, 

        /// <summary>
        /// Idle command for the carrier.
        /// Default Requirements: Unit must be Carrier/Gantrithor. Allow on hallucinated units.
        /// </summary>
        Carrier = 0x32, 

        /// <summary>
        /// Carrier move command. Ignores enemies
        /// Default Requirements: Unit must be Carrier/Gantrithor or Reaver/Warbringer. Allow on hallucinated units.
        /// </summary>
        ReaverCarrierMove = 0x33, 

        /// <summary>
        /// Carrier stop command. Runs idle.
        /// Default Requirements: Unit must be Carrier/Gantrithor. Allow on hallucinated units.
        /// </summary>
        CarrierStop = 0x34, 

        /// <summary>
        /// Generic Carrier attack command.
        /// Default Requirements: Unit must be Carrier/Gantrithor. Allow on hallucinated units.
        /// </summary>
        CarrierAttack1 = 0x35, 

        /// <summary>
        /// Move to attack shrouded building.
        /// Default Requirements: Unit must be Carrier/Gantrithor. Allow on hallucinated units.
        /// </summary>
        CarrierAttack2 = 0x36, 

        /// <summary>
        /// Unknown. Possibly a secondary move.
        /// Default Requirements: Unit must be Carrier/Gantrithor or Reaver/Warbringer. Allow on hallucinated units.
        /// </summary>
        CarrierIgnore2 = 0x37, 

        /// <summary>
        /// Carrier Attack Unit.
        /// Default Requirements: Unit must be Carrier/Gantrithor. Allow on hallucinated units.
        /// </summary>
        CarrierFight = 0x38, 

        /// <summary>
        /// Carrier Hold Position.
        /// Default Requirements: Unit must be Carrier/Gantrithor. Allow on hallucinated units.
        /// </summary>
        CarrierHoldPosition = 0x39, 

        /// <summary>
        /// Reaver Idle order.
        /// Default Requirements: Unit must be Reaver/Warbringer. Allow on hallucinated units.
        /// </summary>
        Reaver = 0x3A, 

        /// <summary>
        /// Generic reaver attack order.
        /// Default Requirements: Unit must be Reaver/Warbringer. Allow on hallucinated units.
        /// </summary>
        ReaverAttack1 = 0x3B, 

        /// <summary>
        /// Move to attack shrouded building.
        /// Default Requirements: Unit must be Reaver/Warbringer. Allow on hallucinated units.
        /// </summary>
        ReaverAttack2 = 0x3C, 

        /// <summary>
        /// Reaver attack unit.
        /// Default Requirements: Unit must be Reaver/Warbringer. Allow on hallucinated units.
        /// </summary>
        ReaverFight = 0x3D, 

        /// <summary>
        /// Reaver hold position.
        /// Default Requirements: Unit must be Reaver/Warbringer. Allow on hallucinated units.
        /// </summary>
        ReaverHoldPosition = 0x3E, 

        /// <summary>
        /// Training subunit(scarab, interceptor). Causes all interceptors within a carrier to be healed when not attacking.
        /// </summary>
        TrainFighter = 0x3F, 

        /// <summary>
        /// Interceptor move and attack.
        /// Default Requirements: Unit must be Protoss Interceptor. Allow on hallucinated units.
        /// </summary>
        StrafeUnit1 = 0x40, 

        /// <summary>
        /// Scarab move and attack.
        /// Default Requirements: Unit must be Protoss Scarab.
        /// </summary>
        StrafeUnit2 = 0x41, 

        /// <summary>
        /// Unit recharge shields.
        /// </summary>
        RechargeShieldsUnit = 0x42, 

        /// <summary>
        /// Shield Battery, recharge shield cast on unit or ground. Unit runs recharge shields 1, shield battery runs shield battery. If cast on ground, recharges all units within rechargeable radius.
        /// Default Requirements: Unit must be Protoss Shield Battery.
        /// </summary>
        RechargeShieldsBattery = 0x43, 

        /// <summary>
        /// Shield Battery, is recharging.
        /// </summary>
        ShieldBattery = 0x44, 

        /// <summary>
        /// Interceptor(or worker?) return to parent.
        /// Default Requirements: Unit must be a Worker (has harvest orders).
        /// </summary>
        Return = 0x45, //TODO: rename to InterceptorReturn (?)

        /// <summary>
        /// Drone landing order. Used when building.
        /// Default Requirements: Unit must be Zerg Drone.
        /// </summary>
        DroneLand = 0x46, 

        /// <summary>
        /// Building land order.
        /// Default Requirements: Unit must be a building(can lift off) that is lifted off.
        /// </summary>
        BuildingLand = 0x47, 

        /// <summary>
        /// Begin Building Liftoff.
        /// Default Requirements: Unit must be a building(can lift off) that is on the ground.
        /// </summary>
        BuildingLiftOff = 0x48, 

        /// <summary>
        /// Begin Drone liftoff.
        /// Default Requirements: Unit must be Zerg Drone.
        /// </summary>
        DroneLiftOff = 0x49, 

        /// <summary>
        /// Unit is lifting off.
        /// Default Requirements: Unit must be a building(can lift off).
        /// </summary>
        LiftingOff = 0x4A, 

        /// <summary>
        /// Building researching tech.
        /// </summary>
        ResearchTech = 0x4B, 

        /// <summary>
        /// Building researching upgrade.
        /// </summary>
        Upgrade = 0x4C,

        /// <summary>
        /// Idle order for larva. Make sure it stays on creep, dies if off, and says within the range of the parent it came from.
        /// Default Requirements: Unit must be Zerg Larva. Allow on hallucinated units. 
        /// </summary>
        Larva = 0x4D, 

        /// <summary>
        /// Building is spawning larva.
        /// Default Requirements: Unit must be Hatchery/Lair/Hive.
        /// </summary>
        SpawningLarva = 0x4E, 

        /// <summary>
        /// Generic move to harvest order.
        /// Default Requirements: Unit must be a Worker (has harvest orders).
        /// </summary>
        Harvest1 = 0x4F, 

        /// <summary>
        /// Move to harvest shrouded minerals/gas.
        /// Default Requirements: Unit must be a Worker (has harvest orders).
        /// </summary>
        Harvest2 = 0x50, 

        /// <summary>
        /// Move to harvest gas.
        /// Default Requirements: Unit must be a Worker (has harvest orders).
        /// </summary>
        MoveToGas = 0x51, 

        /// <summary>
        /// Check if it can enter the gas mine(no unit in it).
        /// Default Requirements: Unit must be a Worker (has harvest orders).
        /// </summary>
        WaitForGas = 0x52, 

        /// <summary>
        /// Enter/exit mine, set return order.
        /// </summary>
        HarvestGas = 0x53, 

        /// <summary>
        /// Return order, has gas.
        /// Default Requirements: Unit must be a Worker (has harvest orders).
        /// </summary>
        ReturnGas = 0x54, 

        /// <summary>
        /// Move to harvest minerals.
        /// Default Requirements: Unit must be a Worker (has harvest orders).
        /// </summary>
        MoveToMinerals = 0x55, 

        /// <summary>
        /// Can harvest minerals(one unit per field).
        /// Default Requirements: Unit must be a Worker (has harvest orders).
        /// </summary>
        WaitForMinerals = 0x56, 

        /// <summary>
        /// Harvesting minerals. Runs iscript to spawn weapon.
        /// </summary>
        MiningMinerals = 0x57, 

        /// <summary>
        /// Harvesting minerals is interrupted.
        /// </summary>
        Harvest3 = 0x58, 

        /// <summary>
        /// Unknown harvest command.
        /// </summary>
        Harvest4 = 0x59, 

        /// <summary>
        /// Return resources /B Has minerals.
        /// Default Requirements: Unit must be a Worker (has harvest orders).
        /// </summary>
        ReturnMinerals = 0x5A, 

        /// <summary>
        /// Harvest Interrupt /B recharge shields.
        /// </summary>
        Interrupted = 0x5B, 

        /// <summary>
        /// Move/enter a transport.
        /// Default Requirements: Allow on Hallucinated Units. 
        /// </summary>
        EnterTransport = 0x5C, 

        /// <summary>
        /// Transport Idle command.
        /// Default Requirements: Unit must be Transport(Can carry units) or Zerg Overlord.
        /// </summary>
        PickupIdle = 0x5D, 

        /// <summary>
        /// Mobile Transport unit pickup.
        /// Default Requirements: Unit must be Transport(Can carry units).
        /// </summary>
        PickupTransport = 0x5E, 

        /// <summary>
        /// Building pickup.
        /// Default Requirements: Unit must be Terran Bunker.
        /// </summary>
        PickupBunker = 0x5F, 

        /// <summary>
        /// Unknown /B AI pickup?
        /// </summary>
        Pickup4 = 0x60, 

        /// <summary>
        /// Idle for powerups.
        /// Default Requirements: Unit must be a powerup.
        /// </summary>
        PowerupIdle = 0x61, 

        /// <summary>
        /// Switch to Siege mode.
        /// </summary>
        SiegeMode = 0x62, 

        /// <summary>
        /// Switch to Tank mode.
        /// </summary>
        TankMode = 0x63, 

        /// <summary>
        /// Immobile Unit base, watch the target.
        /// Default Requirements: Allow on hallucinated units.
        /// </summary>
        WatchTarget = 0x64, 

        /// <summary>
        /// Start Spreading Creep.
        /// Default Requirements: Unit must be Hatchery/Lair/Hive or Creep Colony. 
        /// </summary>
        InitCreepGrowth = 0x65,

        /// <summary>
        /// Spreads creep. If it is a larva producer, runs that order also.
        /// Default Requirements: Blank.
        /// </summary>
        SpreadCreep = 0x66, 

        /// <summary>
        /// Stops creep growth.
        /// Default Requirements: Unit must be Sunken/Spore Colony.
        /// </summary>
        StoppingCreepGrowth = 0x67, 

        /// <summary>
        /// Unused, Morph 1 is used for unit morphing.
        /// Default Requirements: Unit must be Zerg Mutalisk.
        /// </summary>
        GuardianAspect = 0x68, 

        /// <summary>
        /// Move and start archon merge.
        /// </summary>
        WarpingArchon = 0x69, 

        /// <summary>
        /// Archon build self order.
        /// </summary>
        CompletingArchonsummon = 0x6A, 

        /// <summary>
        /// Attacking Unit hold position.
        /// Default Requirements: Unit is able to Hold Position. Allow on hallucinated units.
        /// </summary>
        HoldPosition = 0x6B, 

        /// <summary>
        /// Queen Hold position.
        /// Default Requirements: Unit must be Zerg Queen/Matriarch.
        /// </summary>
        QueenHoldPosition = 0x6C, 

        /// <summary>
        /// Cloak Unit.
        /// </summary>
        Cloak = 0x6D, 

        /// <summary>
        /// Decloak Unit.
        /// </summary>
        Decloak = 0x6E, 

        /// <summary>
        /// Unload a unit from the transport.
        /// Default Requirements: Unit must be a transport.
        /// </summary>
        Unload = 0x6F, 

        /// <summary>
        /// Move to unload site and run unload order.
        /// Default Requirements: Unit must be a transport.
        /// </summary>
        MoveUnload = 0x70, 

        /// <summary>
        /// Cast Spell: Yamato.
        /// </summary>
        FireYamatoGun1 = 0x71, 

        /// <summary>
        /// Move to cast spell on shrouded building.
        /// </summary>
        FireYamatoGun2 = 0x72, 

        /// <summary>
        /// Cast Spell: Lockdown.
        /// </summary>
        MagnaPulse = 0x73, 

        /// <summary>
        /// Burrow Unit.
        /// </summary>
        Burrow = 0x74, 

        /// <summary>
        /// Burrowed Unit idle.
        /// </summary>
        Burrowed = 0x75, 

        /// <summary>
        /// Unburrow unit.
        /// </summary>
        Unburrow = 0x76, 

        /// <summary>
        /// Cast Spell: Dark Swarm.
        /// </summary>
        DarkSwarm = 0x77, 

        /// <summary>
        /// Cast Spell: Parasite.
        /// </summary>
        CastParasite = 0x78, 

        /// <summary>
        /// Cast Spell: Spawn Broodings.
        /// </summary>
        SummonBroodlings = 0x79, 

        /// <summary>
        /// Cast Spell: EMP Shockwave.
        /// </summary>
        EmpShockwave = 0x7A, 

        /// <summary>
        /// Unknown.
        /// Default Requirements: Unit must be Terran Nuclear Missile.
        /// </summary>
        NukeWait = 0x7B, 

        /// <summary>
        /// Silo Idle.
        /// </summary>
        NukeTrain = 0x7C, 

        /// <summary>
        /// Launch for nuclear missile.
        /// Default Requirements: Unit must be Terran Nuclear Missile.
        /// </summary>
        NukeLaunch = 0x7D, 

        /// <summary>
        /// Move to and set nuke target.
        /// Default Requirements: Unit must be Terran Ghost.
        /// </summary>
        NukePaint = 0x7E, 

        /// <summary>
        /// Nuke the ground location of the unit.
        /// Default Requirements: Unit must be Terran Nuclear Missile.
        /// </summary>
        NukeUnit = 0x7F, 

        /// <summary>
        /// Nuke ground.
        /// Default Requirements: Unit must be Terran Nuclear Missile.
        /// </summary>
        NukeGround = 0x80, 

        /// <summary>
        /// Ghost order during nuke.
        /// Default Requirements: Unit must be Terran Nuclear Missile.
        /// </summary>
        NukeTrack = 0x81, 

        /// <summary>
        /// Run nearby cloaking.
        /// Default Requirements: Unit must be Protoss Arbiter/Danimoth. Allow on Hallucinated units.
        /// </summary>
        InitArbiter = 0x82, 

        /// <summary>
        /// Cloak non arbiters within range.
        /// Default Requirements: Unit must be Protoss Arbiter/Danimoth.
        /// </summary>
        CloakNearbyUnits = 0x83, 

        /// <summary>
        /// Place spider mine.
        /// </summary>
        PlaceMine = 0x84, 

        /// <summary>
        /// Right click, sets correct order based on target.
        /// Default Requirements: Allow on Hallucinated units.
        /// </summary>
        RightClickAction = 0x85, 

        /// <summary>
        /// Suicide Attack Unit.
        /// Default Requirements: Unit must be Zerg infested Terran. Allow on Hallucinated units.
        /// </summary>
        SapUnit = 0x86, 

        /// <summary>
        /// Suicide Attack tile.
        /// Default Requirements: Unit must be Zerg infested Terran. Allow on Hallucinated units.
        /// </summary>
        SapLocation = 0x87,

        /// <summary>
        /// Suicide Hold Position.
        /// Default Requirements: Unit must be Zerg Infested Terran or Zerg Scourge. Allow on Hallucinated units.
        /// </summary>
        SuicideHoldPosition = 0x88, 

        /// <summary>
        /// Recall(units within range of target pos).
        /// </summary>
        Teleport = 0x89, 

        /// <summary>
        /// Causes units to teleport when being recalled.
        /// </summary>
        TeleportToLocation = 0x8A, 

        /// <summary>
        /// Place Scanner Sweep Unit at position.
        /// </summary>
        PlaceScanner = 0x8B, 

        /// <summary>
        /// Scanner Sweep Unit idle.
        /// Default Requirements: Unit must be Scanner Sweep.
        /// </summary>
        Scanner = 0x8C,

        /// <summary>
        /// Defensive Matrix cast on target.
        /// </summary>
        DefensiveMatrix = 0x8D, 

        /// <summary>
        /// Cast Spell: Psi Storm.
        /// </summary>
        PsiStorm = 0x8E, 

        /// <summary>
        /// Cast Spell: Irradiate.
        /// </summary>
        Irradiate = 0x8F,

        /// <summary>
        /// Cast Spell: Plague.
        /// </summary>
        Plague = 0x90, 

        /// <summary>
        /// Cast Spell: Consume.
        /// </summary>
        Consume = 0x91, 

        /// <summary>
        /// Cast Spell: Ensnare.
        /// </summary>
        Ensnare = 0x92, 

        /// <summary>
        /// Cast Spell: Stasis Field.
        /// </summary>
        StasisField = 0x93, 

        /// <summary>
        /// Hallucination Cast on target.
        /// </summary>
        Hallucination1 = 0x94, 

        /// <summary>
        /// Kill Halluciation on spell cast.
        /// </summary>
        Hallucination2 = 0x95, 

        /// <summary>
        /// Collision Reset between 2 units.
        /// </summary>
        ResetCollision1 = 0x96, 

        /// <summary>
        /// Collision reset between harvester and mine.
        /// </summary>
        ResetCollision2 = 0x97, 

        /// <summary>
        /// Patrol to target, queue patrol to original position.
        /// Default Requirements: Unit is able to move. Allow on Hallucinated units.
        /// </summary>
        Patrol = 0x98, 

        /// <summary>
        /// CTF Initialization
        /// </summary>
        CTFCOPInit = 0x99, 

        /// <summary>
        /// CTF Idle
        /// </summary>
        CTFCOP1 = 0x9A, 

        /// <summary>
        /// Unknown? Reset COP?
        /// Default Requirements: Unit must be Zerg Flag Beacon, Terran Flag Beacon, or Protoss Flag Beacon.
        /// </summary>
        CTFCOP2 = 0x9B, 

        /// <summary>
        /// AI Control.
        /// </summary>
        ComputerAI = 0x9C, 

        /// <summary>
        /// AI Attack Move?
        /// Default Requirements: Unit is able to move. Allow on Hallucinated units.
        /// </summary>
        AtkMoveEP = 0x9D,

        /// <summary>
        /// Passive attack move. Attack only if target is in sight range? used for computer?
        /// </summary>
        HarassMove = 0x9E, 

        /// <summary>
        /// Moves units to the center of the current âË¶areaââ they are at? Not sure if the spacing is meant to allow for detectors to cover an area or not.
        /// </summary>
        AIPatrol = 0x9F, 

        /// <summary>
        /// Immobile Unit Guard.
        /// </summary>
        GuardPost = 0xA0,

        /// <summary>
        /// Rescuable unit idle.
        /// </summary>
        RescuePassive = 0xA1, 

        /// <summary>
        /// Neutral Unit idle.
        /// </summary>
        Neutral = 0xA2,

        /// <summary>
        /// Return computer units to defensive position? Was seen returning units that had followed a unit outside of a base and killed it.
        /// </summary>
        ComputerReturn = 0xA3, 

        /// <summary>
        /// Init Psi Provider. Adds to some kind of linked list.
        /// </summary>
        InitPsiProvider = 0xA4, 

        /// <summary>
        /// Kill unit.
        /// Default Requirements: Unit must be Protoss Scarab.
        /// </summary>
        SelfDestructing = 0xA5, 

        /// <summary>
        /// Critter idle.
        /// Default Requirements: Unit must be Rhynadon, Bengalaas, Ragnasaur, Scantid, Kakaru, or Ursadon. Allow on hallucinated units.
        /// </summary>
        Critter = 0xA6, 

        /// <summary>
        /// Trap idle order.
        /// Default Requirements: Unit must be Floor Gun Trap, Left Wall Missile Trap, Left Wall Flame Trap, Right Wall Missile Trap, or Right Wall Flame Trap.
        /// </summary>
        HiddenGun = 0xA7,

        /// <summary>
        /// Opens the door.
        /// Default Requirements: Unit must be Left Upper Level Door, Right Upper Level Door, Left Pit Door, or Right pit Door.
        /// </summary>
        OpenDoor = 0xA8, 

        /// <summary>
        /// Closes the door.
        /// Default Requirements: Unit must be Left Upper Level Door, Right Upper Level Door, Left Pit Door, or Right pit Door. 
        /// </summary>
        CloseDoor = 0xA9, 

        /// <summary>
        /// Trap return to idle.
        /// Default Requirements: Unit must be Floor Missile Trap, Floor Gun Trap, Left Wall Missile Trap, Left Wall Flame Trap, Right Wall Missile Trap, or Right Wall Flame Trap.
        /// </summary>
        HideTrap = 0xAA, 

        /// <summary>
        /// Trap attack.
        /// Default Requirements: Unit must be Floor Missile Trap, Floor Gun Trap, Left Wall Missile Trap, Left Wall Flame Trap, Right Wall Missile Trap, or Right Wall Flame Trap.
        /// </summary>
        RevealTrap = 0xAB,

        /// <summary>
        /// Enable Doodad state.
        /// </summary>
        EnableDoodad = 0xAC, 

        /// <summary>
        /// Disale Doodad state.
        /// </summary>
        DisableDoodad = 0xAD, 

        /// <summary>
        /// Unused. Left over from unit warp in which now exists in Starcraft 2.
        /// </summary>
        Warpin = 0xAE, 

        /// <summary>
        /// Idle command for the Terran Medic.
        /// Default Requirements: Unit must be Terran Medic.
        /// </summary>
        Medic = 0xAF,

        /// <summary>
        /// Heal cast on target.
        /// Default Requirements: Unit must be Terran Medic.
        /// </summary>
        MedicHeal1 = 0xB0, 

        /// <summary>
        /// Attack move command for the Terran Medic.
        /// Default Requirements: Unit must be Terran Medic.
        /// </summary>
        MedicHealAttackMove = 0xB1, 

        /// <summary>
        /// Holds Position for Terran Medics, heals units within range.
        /// Default Requirements: Unit must be Terran Medic.
        /// </summary>
        MedicHoldPosition = 0xB2, 

        /// <summary>
        /// Return to idle after heal.
        /// </summary>
        MedicHeal2 = 0xB3,

        /// <summary>
        /// Cast Spell: Restoration.
        /// </summary>
        Restoration = 0xB4, 

        /// <summary>
        /// Cast Spell: Disruption Web.
        /// </summary>
        CastDisruptionWeb = 0xB5, 

        /// <summary>
        /// Mind Control Cast on Target.
        /// Default Requirements: Unit must be Protoss Dark Archon.
        /// </summary>
        CastMindControl = 0xB6, 

        /// <summary>
        /// Dark Archon Meld.
        /// </summary>
        WarpingDarkArchon = 0xB7, 

        /// <summary>
        /// Feedback cast on target.
        /// </summary>
        CastFeedback = 0xB8, 

        /// <summary>
        /// Cast Spell: Optical Flare.
        /// </summary>
        CastOpticalFlare = 0xB9, 

        /// <summary>
        /// Cast Spell: Maelstrom.
        /// </summary>
        CastMaelstrom = 0xBA,

        /// <summary>
        /// Junk yard dog movement.
        /// </summary>
        JunkYardDog = 0xBB, 

        /// <summary>
        /// Nothing.
        /// </summary>
        Fatal = 0xBC, 

    }
}
