using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfiguration", menuName= "David/WaveConfiguration", order = 0)]

//Un SCRIPTABLE OBJECT solo almacena datos
public class WaveConfiguration : ScriptableObject
{
    public List<Wave> _waves = new();

}
