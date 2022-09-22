using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu ( menuName =" Ara/WaveConfiguration", fileName = "WavecOnfiguration", order =0)]

public class WaveConfiguration : ScriptableObject
{
    public List<Wave> _waves;
}
