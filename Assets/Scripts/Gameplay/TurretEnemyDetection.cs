using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemyDetection : MonoBehaviour
{

    private GameObject _detectedEnemt = null;
    [SerializeField] private Transform _turretPivot = null;
    [SerializeField] private float _maxDistance = 5f;
    
    void Update()
    {
        if (_detectedEnemt == null) return;

        var direction = _detectedEnemt.transform.position - transform.parent.position;
        direction.y = 0;
        var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        _turretPivot.rotation = targetRotation;
        var distance = Vector3.Distance(_detectedEnemt.transform.position, transform.parent.position);

        if(Mathf.Abs(distance) > _maxDistance)
        {
            _detectedEnemt = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy") && _detectedEnemt == null)


        _detectedEnemt = other.gameObject;
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if(other.CompareTag("Enemy") && _detectedEnemt == other.gameObject)
    //    {
    //        _detectedEnemt = null;
    //    }
    //}




}
