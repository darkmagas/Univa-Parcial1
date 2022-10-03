using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class OnEnemyDeath : MonoBehaviour
{
    // Start is called before the first frame update
    public void Die()
    {
        EventDispatcher.Dispatch(new DespawnObject(gameObject));
    }

}
