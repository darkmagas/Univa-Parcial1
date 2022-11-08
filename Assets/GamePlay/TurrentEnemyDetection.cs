using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class TurrentEnemyDetection : MonoBehaviour
{
    private GameObject _detectEdenemy = null;
    [SerializeField] private Transform _turretPivot = null;
    [SerializeField] private float _maxDistance = 5f;

    private void Start()
    {
        EventDispatcher.Subscribe<OnEnemyDeathSignal>(OnEnemyDeath);
    }

    private void OnDisable()
    {
        EventDispatcher.Unsubscribe<OnEnemyDeathSignal>(OnEnemyDeath);

    }

    private void OnDestroy()
    {
        EventDispatcher.Unsubscribe<OnEnemyDeathSignal>(OnEnemyDeath);
    }

    private void OnEnemyDeath(ISignal signal)
    {
        if (signal is OnEnemyDeathSignal enemyDeathSignal)
        {
            if (enemyDeathSignal.go == _detectEdenemy)
            {
                _detectEdenemy = null;
            }
        }
    }
    private void Update() // dirigir el pivote de la torreta
    {
        if (_detectEdenemy == null) return;
        var direction = _detectEdenemy.transform.position - transform.parent.position; // se guarda la posicion del pivote del enemigo
        direction.y = 0;
        var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        _turretPivot.rotation = targetRotation;  //la torreta esta rotando

        var distance = Vector3.Distance(_detectEdenemy.transform.position, transform.parent.position);

        if (Mathf.Abs(distance) > _maxDistance)
        {
            _detectEdenemy = null;
        }
    }



    private void OnTriggerStay(Collider other) //asignar valor y disparar
    {
        if (other.CompareTag("Enemy") && _detectEdenemy ==null) //si mi detected enemy es igual a nulo, agregale un valor. Estamos haciend una comparacion de valores
        {
            
            _detectEdenemy = other.gameObject;
        }
    }


//    private void OnTriggerExit(Collider other) //quitar valor y dejar de disparar
//    {
//        if (other.CompareTag("Enemy") && _detectEdenemy == other.gameObject)  
//        {
//            _detectEdenemy = null;
//        }
//    }
}
