using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSlot : MonoBehaviour
{
    private bool _isOcupied = false;

    public bool IsOcupied => _isOcupied;

    public void SetStatus(bool status)
    {
        _isOcupied = status;
    }
}
