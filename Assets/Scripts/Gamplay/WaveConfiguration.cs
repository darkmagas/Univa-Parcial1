using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName="Maga/WaveCofig", fileName = "WaveConfiguration", order = 0)]

public class WaveConfiguration : ScriptableObject
{
    public List<Wave> _waves;
}
