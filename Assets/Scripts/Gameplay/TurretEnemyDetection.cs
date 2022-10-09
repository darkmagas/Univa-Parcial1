using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class TurretEnemyDetection : MonoBehaviour
{
    private GameObject _detectedEnemy = null;
    [SerializeField] private Transform _turretPivot = null;
    [SerializeField] private float _maxDistance = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && _detectedEnemy == null)
        {
            _detectedEnemy = other.gameObject;
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if(other.Comparetag("Enemy") && _detectedEnemy == other.GameObject)
    //    {
    //        _detectedEnemy = null;
    //    }
    //}

    private void update()
    {
        if( _detectedEnemy != null)
        {
            var direction = _detectedEnemy.transform.position - transform.parent.position;
            //direction.y = 0;  codigo para que la torreta se mantenga en el y y que no se vaya ni arriba ni abajo
            var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            _turretPivot.rotation = targetRotation;

            var distance = Vector3.Distance(_detectedEnemy.transform.position, transform.parent.position);

            if(Mathf.Abs(distance) > _maxDistance)
            {
                _detectedEnemy = null;
            }
        }
    }
}
