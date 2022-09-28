using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfiguration", menuName = "Tamborez/WaveConfiguration", order = 0)]
public class WaveConfiguration : ScriptableObject
{
    public List<Wave> _waves = new();


}
