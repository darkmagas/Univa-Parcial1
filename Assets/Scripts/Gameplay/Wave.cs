using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]public class Wave
{
   [FormerlySerializedAs("weakEnemyCount")] public int weakEnemy;
   [FormerlySerializedAs("midEnemyCount")] public int midEnemy;
   [FormerlySerializedAs("strongEnemyCount")] public int strongEnemy;
}
