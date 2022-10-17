using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemyDetection : MonoBehaviour
{
    private GameObject _detectedEnemy = null;
    [SerializeField] private Transform _TurretPivot = null;
    [SerializeField] private float _maxDistance = 1f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && _detectedEnemy == null)
        {
            _detectedEnemy = other.gameObject;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Enemy") && _detectedEnemy == other.gameObject)
    //    {
    //        _detectedEnemy = null;
    //    }
    //}
    private void update()
    {
        if (_detectedEnemy != null)
        {
            var direction = _detectedEnemy.transform.position - transform.parent.position.position;
            direction.y = 0;
            var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            _TurretPivot.rotation = targetRotation;

            var distance = Vector3.Distance(_detectedEnemy.transform.position, transform.parent.position);
            if(Mathf.Abs(distance)>10)
            {
                _detectedEnemy = null; 
            }
        }
    }

}
