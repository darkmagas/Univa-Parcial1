using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TorrentManagement : MonoBehaviour
{
    [Serializable] public struct TurretConfig
    {
        public GameObject turrent;
        public int cost;
    }

    [SerializeField] private List<TurretConfig> _turretConfigs = new ();

    public (GameObject turrent, int cost) GetTurrentConfig(int index) 
    {
        return (_turretConfigs[index].turrent, _turretConfigs[index].cost);
    }
}
