using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorrentEnemyDetection : MonoBehaviour
{
    private GameObject _detectedEnemy = null;
    [SerializeField] private Transform _torretPivot = null;

    private void Update()
    {
        if (_detectedEnemy == null) return;

       var direction = _detectedEnemy.transform.position - _torretPivot.position; //restamos posicion para saber donde se encuentra el enemigo
        var targetRotation = Quaternion.LookRotation(direction, Vector3.up); //al detectarla que gire unicamente en el pivote de arriba.
        _torretPivot.rotation = targetRotation;
    }
    private void OnTriggerEnter(Collider other)
        
    {
        if (other.CompareTag("Enemy") && _detectedEnemy == null )//detecta al enemigo y le asigna un valor, para seguirle disparando unicamente a ese
        {
            _detectedEnemy = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Enemy") && _detectedEnemy == other.gameObject) //para que si el objeto que se tiene asignado sale del rango le 
                                                                            //deje de disparar.
        {
            _detectedEnemy = null;
        }
    }

}
