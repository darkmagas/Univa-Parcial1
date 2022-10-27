using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;


//este script sirve para matar al enemigo

public class OnEnemyDeath : MonoBehaviour
{
   
   public void Die()
    {
        
            EventDispatcher.Dispatch(new DespawnObject(gameObject));
        
    }
    
}
