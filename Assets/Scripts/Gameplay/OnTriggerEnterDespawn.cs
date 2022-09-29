using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities; //no olvidar poner Magas.Utilies

public class OnTriggerEnterDespawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EventDispatcher.Dispatch(new DespawnObject(gameObject));
        }
    }
}
