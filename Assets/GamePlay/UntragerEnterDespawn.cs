using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class UntragerEnterDespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EventDispatcher.Dispatch(new DespawnObject(gameObject));
        }
    }
}




   


