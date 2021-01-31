using System;
using System.Collections.Generic;
using System.Text;

namespace StarcraftBot.Wrapper {
    enum Errors {
        UnitDoesNotExists = 0,
        UnitNotVisible = 1,
        UnitNotOwned = 2,
        UnitBusy = 3,
        IncompatibleUnitType = 4,
        IncompatibleTechType = 5,
        AlreadyResearched = 6,
        FullyUpgraded = 7,
        InsufficientMinerals = 8,
        InsufficientGas = 9,
        InsufficientSupply = 10,
        InsufficientEnergy = 11,
        InsufficientTech = 12,
        InsufficientAmmo = 13,
        InsufficientSpace = 14,
        UnbuildableLocation = 15,
        OutOfRange = 16,
        UnableToHit = 17,
        AccessDenied = 18,
        None = 19,
        Unknown = 20

    }
}
