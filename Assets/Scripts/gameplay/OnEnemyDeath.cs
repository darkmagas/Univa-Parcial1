using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class OnEnemyDeath : MonoBehaviour
{
    [SerializeField] private int _scoreOnDeath = 5;
    [SerializeField] private int _moneyOnDeath = 1;
    [SerializeField] private Collider _collider;
    [SerializeField] private bool _isDying;

    public void Die()
    {
        Debug.Log("ENEMY NEEDS TO DIE");
        if (_isDying) return;
        _isDying = true;
        _collider.enabled = false;
        EventDispatcher.Dispatch(new EnemyDeathSignal(gameObject));
        StartCoroutine(OnEnemyDie());
        GameManager.Instance.ModifyScore(_scoreOnDeath);
        GameManager.Instance.AddCurrency(_moneyOnDeath);
    }

    private IEnumerator OnEnemyDie()
    {
        yield return new WaitForSeconds(2.0f);
        Debug.Log("ENEMY NEEDS TO DIE FOR SURE");
        EventDispatcher.Dispatch(new DespawnObject(gameObject));
        _isDying = false;
        _collider.enabled = true;
    }
}
