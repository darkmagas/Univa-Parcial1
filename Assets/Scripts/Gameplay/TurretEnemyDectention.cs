using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemyDectention : MonoBehaviour
{
    private GameObject _detectedEnemy = null;
    [SerializeField] private Transform _turrentPivot = null;
    [SerializeField] private float _maxDistance = 5f;


    private void Update()
    {
        if (_detectedEnemy == null) return;

        var direction = _detectedEnemy.transform.position - transform.parent.position;
        var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        _turrentPivot.rotation = targetRotation;
        var distance = Vector3.Distance(_detectedEnemy.transform.position, transform.parent.position);

        if(Mathf.Abs(distance) > 10f)
        {
            _detectedEnemy = null;
        }
    }

    private void OnTriggerStay(Collider other)

    {
        if(other.CompareTag("Enemy") && _detectedEnemy == null) 
        {
            _detectedEnemy = other.gameObject;
        }
    }
   //private void OnTriggerExit(Collider other)

   // {
   //  if (other.CompareTag("Enemy") && _detectedEnemy == other.gameObject)
   //   {
   //        _detectedEnemy = null;
   //    }
   // }
}
