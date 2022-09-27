using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Enty/WaveConfiguration", fileName = "WaveConfiguration", order = 0)]

public class WaveConfiguration : ScriptableObject //scriptable es para almacenas datos e informacion.

{
    public List<Wave> _waves; //sirve para contar el numero de olas
}