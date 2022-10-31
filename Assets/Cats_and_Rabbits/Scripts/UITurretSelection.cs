using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UITurretSelection : MonoBehaviour
{
    [SerializeField] private TurretManager _turretManagement;
    [SerializeField] private UnityEvent<(GameObject go, int cost)> _onTurretSelection = new();
    public void SelectTurret (int index)
    {
        var turret = _turretManagement.GetTurretConfig(index);
        _onTurretSelection?.Invoke((turret.turret, turret.cost));
    }
}
