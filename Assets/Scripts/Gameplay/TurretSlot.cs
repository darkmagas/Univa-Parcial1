using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSlot : MonoBehaviour
{
    private bool isUsed = false;
    public bool IsUsed => isUsed;

    public void SetStatus(bool z)
    {
        isUsed = z;
    }
}
