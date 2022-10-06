using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemyDetection : MonoBehaviour
{
    private GameObject _detectedEnemy = null;
    [SerializeField] private Transform _turretPivot = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy") && _detectedEnemy == null)
            {
            _detectedEnemy = other.gameObject;

            var direction = _detectedEnemy.transform.position - _turretPivot.position;
            var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            _turretPivot.rotation = targetRotation;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("enemy") && _detectedEnemy != other.gameObject)
        {
            _detectedEnemy = null;

        }

    }
    }

}
