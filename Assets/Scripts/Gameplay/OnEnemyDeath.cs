using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;
public class OnEnemyDeath : MonoBehaviour
{
    
    public void Die ()

    {
        EventDispatcher.Dispatch(new DespawnObject(gameObject));
    }

   
}
