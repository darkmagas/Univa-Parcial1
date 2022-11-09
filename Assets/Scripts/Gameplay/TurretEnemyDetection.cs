using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class TurretEnemyDetection : MonoBehaviour
{
    private GameObject _detectedEnemy = null;
    [SerializeField] private Transform _turretPivot = null;
    [SerializeField] private float _maxDistance = 5f;

    private void Start()
    {
        EventDispatcher.Subscribe<EnemyDeathSignal>(OnEnemyDeath);
    }

    private void OnDisable()
    {
        EventDispatcher.Unsubscribe<EnemyDeathSignal>(OnEnemyDeath);
    }

    private void OnDestroy()
    {
        EventDispatcher.Unsubscribe<EnemyDeathSignal>(OnEnemyDeath); 
    }

    private void OnEnemyDeath(ISignal signal)
    {
        if (signal is EnemyDeathSignal enemyDeathSignal)
        {
            if (enemyDeathSignal.go == _detectedEnemy)
            {
                _detectedEnemy = null;
            }
        }
    }

    private void Update()
    {
        if(_detectedEnemy == null) return;

        var direction = _detectedEnemy.transform.position - transform.parent.position;
        
        var targetRotation = Quaternion.LookRotation(direction,
            Vector3.up);
        _turretPivot.rotation = targetRotation;
        var distance = Vector3.Distance(_detectedEnemy.transform.position, transform.parent.position);

        if (Mathf.Abs(distance) > _maxDistance)
        {
            _detectedEnemy = null;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && _detectedEnemy == null)
        {
            _detectedEnemy = other.gameObject;
        }
        
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Enemy") && _detectedEnemy == other.gameObject)
    //     {
    //         _detectedEnemy = null;
    //     }
    // }
}
