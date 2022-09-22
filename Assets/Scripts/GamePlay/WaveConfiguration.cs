using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Xi/WaveConfig", fileName = "WaveCofiguration", order = 0)]

public class WaveConfiguration : ScriptableObject

{
    public List<Wave> _waves;  
}
