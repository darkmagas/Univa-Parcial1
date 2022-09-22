using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DB_Lotus/WaveConfig" , fileName ="WaveConfiguration" ,order = 0)]

public class WaveConfiguration : ScriptableObject
{
    public List<Wave> _waves;
}
