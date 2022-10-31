using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSlot : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _isOccupied = false;
    public bool IsOccupied => _isOccupied;
   public void SetStatus(bool status)
    {
        _isOccupied = status;
    }
        
    
}
