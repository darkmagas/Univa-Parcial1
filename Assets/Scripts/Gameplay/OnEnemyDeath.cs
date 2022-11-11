using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;
public class OnEnemyDeath : MonoBehaviour
{
    [SerializeField] private int _scoreOnDeath = 5;
    [SerializeField] private int _MoneyOnDeath = 1;
    [SerializeField] private Collider _collider;
  
    public bool _isDying = false;
    public void Die()
    {

        if (_isDying) return;
        _isDying = true;
       _collider.enabled = false;
        StartCoroutine(routine: OnEnemyDeath());
        
        
        EventDispatcher.Dispatch(new DespawnObject(gameObject));
    }

       private IEnumerator OnEnemyDie()
    {
        yield return new WaitForSeconds(2.0f);
        EventDispatcher.Dispatch(signal: new DespawnObject(GameObject));
        _isDying = false;
        _collider.enabled = true;



    }
     


}
