using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Types
{
    public enum MagicalType
    {
        SingleTargetMagic,
        AOEMagic,
        SingleTagetHeal,
        AOEHeal
    }

    public enum PhysicalType
    {
        SingleTargetMelee,
        AOEMelee,
        SingleTargetRanged,
        AOERanged

    }

    public enum PhysicalAttributeType
    {
        STR,
        DEX,
    }

    public enum MagicalAttributeType
    {
        INT,
        MND
    }

    public enum ElementalType 
    {
        Fire,
        Wind,
        Ice,
        Earth,
        Thunder,
        Water
    }
}
