using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalAbility : MonoBehaviour
{
    public MagicList _magicList;
    private MagicalData[] _magicalData;
    public int _currentAbility;

    private void Awake()
    {
        _magicalData = _magicList._magicalDataList;

        _currentAbility = 1;
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
            if (_currentAbility < _magicalData.Length -1)
            {

                _currentAbility += 1;
            }
            Debug.Log(_currentAbility);
            
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _magicalData[_currentAbility].Use();
        }
       
    }
}
