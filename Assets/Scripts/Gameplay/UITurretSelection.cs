using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UITurretSelection : MonoBehaviour
{
    [SerializeField] private TorrentManagement _torrentManagement;
    [SerializeField] private UnityEvent<(GameObject go, int cost)> _onTurretSelect = new();
    
    public void SelectTurret(int index)
    {
        var turret = _torrentManagement.GetTurrentConfig(index);
        _onTurretSelect?.Invoke((turret.turrent, turret.cost));
    }

}
