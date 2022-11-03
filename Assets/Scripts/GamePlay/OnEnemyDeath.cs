using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class OnEnemyDeath : MonoBehaviour
{
    [SerializeField] private int _scoreOnDeath = 5;
    [SerializeField] private int _moneyOnDeath = 5;

    public void Die()

    {
        EventDispatcher.Dispatch(new DespawnObject(gameObject));
        GameManager.Instance.ModifyScore(_scoreOnDeath);
        GameManager.Instance.AddCurrency(_moneyOnDeath);
    }
    
}
