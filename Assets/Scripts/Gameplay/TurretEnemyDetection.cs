using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemyDetection : MonoBehaviour
{
    public GameObject _detectedEnemy = null;
    [SerializeField] private Transform _turretPivot = null;
    [SerializeField] private float _maxDistance = 5f;

    private void Update()
    {
        if (_detectedEnemy == null) return;
        var direction = _detectedEnemy.transform.position - transform.parent.position;// restamos posicion pra saber donde se encuentra el enemigo
        var targetRotation = Quaternion.LookRotation(direction, Vector3.up); //al detectar que gire unicamnete el pivote de arriba
        _turretPivot.rotation = targetRotation;
        var distance = Vector3.Distance(_detectedEnemy.transform.position, transform.parent.position);
        if(Mathf.Abs(distance) < _maxDistance)
        {
            _detectedEnemy = null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && _detectedEnemy ==null) //detecta al enemigo y le asigna un valor, para disparando unicamente
        {
            _detectedEnemy = other.gameObject;
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Enemy") && _detectedEnemy == other.gameObject)//para que si el objecto se tiene asignando sale del rango le deje disparar
    //    {
    //        _detectedEnemy = null;
    //    }
    //}
}