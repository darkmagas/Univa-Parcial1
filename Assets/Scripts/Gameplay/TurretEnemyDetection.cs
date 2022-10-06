using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemyDetection : MonoBehaviour
{
    public GameObject _detectedEnemy = null;
    [SerializeField] private Transform _turretPivot = null;

    private void Update()
    {
        if (_detectedEnemy == null) return;
        var direction = _detectedEnemy.transform.position - _turretPivot.position;// restamos posicion pra saber donde se encuentra el enemigo
        var targetRotation = Quaternion.LookRotation(direction, Vector3.up); //al detectar que gire unicamnete el pivote de arriba
        _turretPivot.rotation = targetRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && _detectedEnemy ==null) //detecta al enemigo y le asigna un valor, para disparando unicamente
        {
            _detectedEnemy = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy") && _detectedEnemy == other.gameObject)//para que si el objecto se tiene asignando sale del rango le deje disparar
        {
            _detectedEnemy = null;
        }
    }
}