using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class OnEnemyDeath : MonoBehaviour
{
    [SerializeField] private int _ScoreOnDeath = 5;
    [SerializeField] private int _moneyOnDeath = 1;
    [SerializeField] private Collider _collider;

    private bool _isDying = false;
    public void Die()
    {
        if (_isDying) return;
        _isDying = true;
        _collider.enabled = false;

       
        StartCoroutine(OnEnemyDie());
        GameManager.Instance.ModifyScore(_ScoreOnDeath);
        GameManager.Instance.AddCurrency(_moneyOnDeath);//*

        
    }

    private IEnumerator OnEnemyDie()
    {
        yield return new WaitForSeconds(2.0f);//duracion de la animacion
        EventDispatcher.Dispatch(new DespawnObject(gameObject));
        _isDying = false;
        _collider.enabled = true;
    }
}
