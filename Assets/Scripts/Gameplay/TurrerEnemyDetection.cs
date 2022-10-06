using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Jobs;

public class TurrerEnemyDetection : MonoBehaviour
{
    private GameObject _detectedEnemy = null;
    [SerializeField] private Transform _turrerPivot = null;
    private void Update()
    {
        if (_detectedEnemy == null) return;
        var direction = _detectedEnemy.transform.position - _turrerPivot.position;
        var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        _turrerPivot.rotation = targetRotation;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _detectedEnemy = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") && _detectedEnemy == other.gameObject)
                {
            _detectedEnemy = null;
        }
    }


}


    
