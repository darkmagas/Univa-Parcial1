using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UiTurretSelection : MonoBehaviour
{
    [SerializeField] private TurretManagment _turretManagment;
    [SerializeField] private UnityEvent<(GameObject go, int cost)> _onTurretSelected = new();

    public void SelecteTurret(int index)
    {
        var turret = _turretManagment.GetTurretConfig(index);
        _onTurretSelected?.Invoke((turret.turret, turret.cost));
    }
}
