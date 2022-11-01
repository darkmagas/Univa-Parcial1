using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSlot : MonoBehaviour
{
    private bool _isOcuppied = false;

    public bool IsOccupied => _isOcuppied;

    public void SetStatus(bool status)
    {
        _isOcuppied = status;
    }
}
