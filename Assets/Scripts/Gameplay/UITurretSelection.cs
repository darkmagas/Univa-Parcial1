using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITurretSelection : MonoBehaviour
{
    [SerializedField] private TurretManagement _turretManagement;
    [SerializedField] private UnityEvent<(GameObject go, int cost)> _onTurretSelected = new();

    public void SelectTurret(int index)
    {
        var turret = _turretManagement.GetTurretConfig(index);
        _onTurretSelected?.Invoke((turret.turret, turret.cost));
    }
}
