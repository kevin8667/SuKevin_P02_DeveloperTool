using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName = "New Physical Data", menuName = "Ability Data/Physical")]
public class PhysicalData : AbilityData
{
    public PhysicalType _physicalType;
    public PhysicalAttributeType _physicalAttributeType;
    public ElementalType _elementalType;

    public override void Use()
    {
        Debug.Log(_name);
    }

}
