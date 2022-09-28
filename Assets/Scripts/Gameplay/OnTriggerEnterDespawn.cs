using Magas.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterDespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Player"))
       {
            //Destroy(gameObject);
            EventDispatcher.Dispatch(new DespawnObject(gameObject));
        }
    }
}
