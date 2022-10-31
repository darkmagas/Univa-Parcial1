using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentManagement : MonoBehaviour
{
   
    [Serializable]public struct TurrentConfig
    {
        public GameObject turret;
        public int cost;
    }
    [SerializeField] private List<TurrentConfig> turrentConfigs = new ();

    public (GameObject turret, int cost) GetTurrentConfig(int index)
    { 
        return