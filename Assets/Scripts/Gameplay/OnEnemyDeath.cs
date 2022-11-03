using Magas.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnemyDeath : MonoBehaviour
{
    [SerializeField] private int _scoreOnDeath = 5;
    public void Die()
    {
        EventDispatcher.Dispatch(new DespawnObject(gameObject));
        GameManager.Instance.ModifyScore(_scoreOnDeath);
    }
}

