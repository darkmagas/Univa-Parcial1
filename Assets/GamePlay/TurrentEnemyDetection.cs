using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentEnemyDetection : MonoBehaviour
{
    private GameObject _detectEdenemy = null;
    [SerializeField] private Transform _turretPivot = null;

    private void Update() // dirigir el pivote de la torreta
    {
        if (_detectEdenemy == null) return;
        var direction = _detectEdenemy.transform.position - _turretPivot.position; // se guarda la posicion del pivote del enemigo
        var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        _turretPivot.rotation = targetRotation;  //la torreta esta rotando
    }



    private void OnTriggerEnter(Collider other) //asignar valor y disparar
    {
        if (other.CompareTag("Enemy") && _detectEdenemy ==null) //si mi detected enemy es igual a nulo, agregale un valor. Estamos haciend una comparacion de valores
        {
            _detectEdenemy = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) //quitar valor y dejar de disparar
    {
        if (other.CompareTag("Enemy") && _detectEdenemy == other.gameObject)  
        {
            _detectEdenemy = null;
        }
    }
}
