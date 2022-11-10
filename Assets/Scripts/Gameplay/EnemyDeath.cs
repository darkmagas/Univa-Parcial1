using Magas.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDeath : MonoBehaviour
{
    public void Die()
    {
        EventDispatcher.Dispatch(new DespawnObject(gameObject));
    }
   
}
