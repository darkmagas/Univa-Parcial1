using Magas.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnemyDeath : MonoBehaviour
{
   
    public void Die()
    {
        EventDispatcher.Dispatch(new DespawnObject(gameObject));
    }

}
