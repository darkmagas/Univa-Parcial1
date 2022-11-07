using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UITurretSelection : MonoBehaviour
{
    [SerializeField] private TurretManagement _turretManagement;
    [SerializeField] private UnityEvent<(GameObject go, int cost)> _onTurretSelected = new();

    public void SelectTuret(int index)
    {
        var x = _turretManagement.GetTurretConfig(index);
        _onTurretSelected?.Invoke(x);
    }
}
