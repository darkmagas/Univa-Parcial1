using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]public class Wave
{
   [FormerlySerializedAs("weakEnemyCount")] public int weakEnemy;
   [FormerlySerializedAs("strongEnemyCount")] public int strongEnemy;
}
