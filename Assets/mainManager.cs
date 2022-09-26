using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainManager : MonoBehaviour
{
    [SerializeField] private WaveConfiguration WaveConfig;
    private int _currentWave = 0;
    [SerializeField] private string[] _pathNames;
    [SerializeField] private Transform[] _spwanPoints;
}
