using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSlot : MonoBehaviour
{
    private bool _isOccupied = false;

    public bool IsOccupied => _isOccupied;
    
    public void SetStatus(bool status)
    {
        _isOccupied = status;
    }
}
