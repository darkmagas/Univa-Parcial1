using Magas.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class EnemyDeath : MonoBehaviour
{
    public void Die()
    {
        EventDispatcher.Dispatch(new DespawnObject(gameObject));
    }
   
}
