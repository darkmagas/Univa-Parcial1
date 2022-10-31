using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurretManagement : MonoBehaviour
{
    [Serializable]public struct TurretConfig
    {
        public GameObject turret;
        public int cost;

    }

    [SerializeField] private List<TurretConfig> _turretConfig = new List<TurretConfig> ();

    public (GameObject turret, int cost) GetTurretConfig(int index)
    {
        return (_turretConfig[index].turret, _turretConfig[index].cost);

    }
    
   
}
