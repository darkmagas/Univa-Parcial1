using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private GameObject _detectEnemy = null;
    [SerializeField] private Transform _turretPivot = null;
    [SerializeField] private float _maxDistance = 1f;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _detectEnemy = other.gameObject;

        }

       
    }
   
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Enemy") && _detectEnemy == other.gameObject)
    //    {
    //        _detectEnemy = null;

    //    }
    //}

    private void Update()
    {
        if(_detectEnemy != null)
        {
            var direction = _detectEnemy.transform.position - _turretPivot.parent.position;
            direction.y = 0;
            var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            _turretPivot.rotation = targetRotation;


            var distance = Vector3.Distance(_detectEnemy.transform.position, transform.parent.position);
                if (Mathf.Abs(distance) > _maxDistance)
            {
                _detectEnemy = null;
            }
            

            
        }
    }
}
