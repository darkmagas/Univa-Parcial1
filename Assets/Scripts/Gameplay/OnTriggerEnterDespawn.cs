using Magas.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OnTriggerEnterDespawn : MonoBehaviour
{
    [SerializeField] private int _ScoreOnDeath = 1;
    [SerializeField] private UnityEvent _onDeath = new();
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Player"))
       {
            //Destroy(gameObject);
            EventDispatcher.Dispatch(new DespawnObject(gameObject));
            GameManager.Instance.ModifyScore(_ScoreOnDeath);
            _onDeath?.Invoke();
        }
    }
}
