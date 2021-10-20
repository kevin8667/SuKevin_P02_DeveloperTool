using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityData : ScriptableObject
{
    public float _power;
    public int _cost;
    public string _name;

    public virtual void Use() 
    {

    }

}
