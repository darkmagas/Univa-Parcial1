using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManagement : MonoBehaviour
{
    [Serializable]public struct TurretConfig
    {
        public GameObject turret;
        public int cost;
    }
    
    [SerializeField] private List<TurretConfig> _turretConfigs = new ();
    
    public (GameObject turret, int cost) GetTurretConfig(int index)
    {
        return (_turretConfigs[index].turret, _turretConfigs[index].cost);
    }
}
