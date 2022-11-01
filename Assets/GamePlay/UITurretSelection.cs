using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UITurretSelection : MonoBehaviour
{
    [SerializeField] private TurretManagement _turretManagement;
    [SerializeField] private UnityEvent<(GameObject go, int cost)> _onTurretSelect = new ();

    public void SelectTurret (int index)
    {
        var turret = _turretManagement.GetTurrentConfig(index);
        _onTurretSelect?.Invoke((turret.turret, turret.cost));
    }
}
