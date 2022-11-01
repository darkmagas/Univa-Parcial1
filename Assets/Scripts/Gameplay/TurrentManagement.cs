using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class TurrentManagement : MonoBehaviour
{
    [Serializable]public struct TurretConfig
    {
        public GameObject turret;
        public int cost;
      
    }
    [SerializableField] private List<TurretConfig> _turretConfigs = new();

    public(GameObject turret, int cost) GetTurretConfig (int Index)
    {
        return (_turretConfigs[Index].turret, _turretConfigs[Index].cost);
    }
}
