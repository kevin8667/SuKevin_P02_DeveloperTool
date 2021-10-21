using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName = "New Magical Data", menuName = "Ability Data/Magical")]
public class MagicalData : AbilityData
{
    public MagicalType _magicalType;
    public MagicalAttributeType _magicalAttributeType;
    public ElementalType _elementalType;

    public override void Use()
    {
        Debug.Log(_name);
    }

}
