using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalAbility : MonoBehaviour
{
    public PhysicList _physicList;
    private PhysicalData[] _physicalData;
    public int _currentAbility;

    private void Awake()
    {
        _physicalData = _physicList._physicalDataList;

        _currentAbility = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_currentAbility > 0)
            {
                _currentAbility -= 1;
            }

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_currentAbility < _physicalData.Length - 1)
            {

                _currentAbility += 1;
            }
            Debug.Log(_currentAbility);

        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _physicalData[_currentAbility].Use();
        }

    }

}
