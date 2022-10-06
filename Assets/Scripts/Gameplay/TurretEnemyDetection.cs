using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemyDetection : MonoBehaviour
{
    private GameObject _detectedEnemy = null;
    [SerializeField] private Transform _turretPivot = null;

    private void Update()
    {
        if (_detectedEnemy == null) return;

        var direction = _detectedEnemy.transform.position - _turretPivot.position;
        var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        _turretPivot.rotation = targetRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && _detectedEnemy == null)
        {
            _detectedEnemy = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
      if (other.CompareTag("Enemy") && _detectedEnemy == other.gameObject)
        {
            _detectedEnemy = other.gameObject;
        }
    }
}
