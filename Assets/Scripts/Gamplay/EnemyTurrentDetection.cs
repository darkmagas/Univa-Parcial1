using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurrentDetection : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _detectedEnemy = null;
    [SerializeField] private Transform _turrentPivot = null;

    private void Update()
    {
        if (_detectedEnemy == null) return;
        Vector3 direction = _detectedEnemy.transform.position - _turrentPivot.position;
        var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        _turrentPivot.rotation = targetRotation;
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
        if(other.CompareTag("Enemy") && _detectedEnemy == other.gameObject)
        {
            _detectedEnemy = null;
        }
    }
}
