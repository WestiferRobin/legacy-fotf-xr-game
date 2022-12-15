using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum BodyArmor
{
    Unknown = 0,
    LeftArm = 1,
    RightArm = 2,
    Head = 3,
    Torso = 4,
    Legs = 5,
}

public enum Gender
{
    Other = 0,
    Male = 1,
    Female = 2,
    NonBinary = 3,
}

public enum Rank
{
    Unknown = 0,
    Recruit = 1,
    Private = 2,
    Corporal = 3,
    Sergeant = 4,
    Lieutenant = 5,
    Captin = 6,
    Admiral = 7
}

public enum WeaponUnitType
{
    Primary = 1,
    Secondary = 2,
    Unknown = 0,
}

public enum Tiers
{
    I = 1,
    II = 2,
    III = 3,
    IV = 4,
}