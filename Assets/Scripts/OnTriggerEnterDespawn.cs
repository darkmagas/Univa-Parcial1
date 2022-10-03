using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class OnTriggerEnterDespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            EventDispatcher.Dispatch(new DespawnObject(gameObject));
        }
    } 

   
}
