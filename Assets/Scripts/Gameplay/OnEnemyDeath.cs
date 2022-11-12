using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;
using UnityEngine.Events;
using UnityEngine.UI;

public class OnEnemyDeath : MonoBehaviour
{
    [SerializeField] private int _ScoreOnDeath = 5;
    [SerializeField] private int _moneyOnDeath = 1;
    [SerializeField] private Collider _collider;
    [SerializeField] private UnityEvent _onDeath = new();
    private bool _isDying = false;
   public void Die()
    {
        if (_isDying) return;
        _isDying = true;
        _collider.enabled = false;
        EventDispatcher.Dispatch(new EnemyDeathSignal(gameObject));
        StartCoroutine(OnEnemyDie());   
        GameManager.Instance.ModifyScore(_ScoreOnDeath);
        GameManager.Instance.AddCurrency(_moneyOnDeath);

    }

    private IEnumerator OnEnemyDie()
    {
        yield return new WaitForSeconds(1.0f);
        EventDispatcher.Dispatch(new DespawnObject(gameObject));
        _isDying=false;
        _collider.enabled = true;
    }
    
}
