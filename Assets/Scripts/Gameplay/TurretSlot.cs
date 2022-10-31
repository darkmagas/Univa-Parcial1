using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSlot : MonoBehaviour
{
    public bool _isOccupied = false;

    public bool IsOccupied => _isOccupied;

    public void SetStatus(bool status)
    {
        _isOccupied = status;

    }

}
