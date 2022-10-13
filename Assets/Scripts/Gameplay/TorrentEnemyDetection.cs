using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorrentEnemyDetection : MonoBehaviour
{
    private GameObject _detectedEnemy = null;
    [SerializeField] private Transform _torretPivot = null;
    [SerializeField] private float _maxDistance = 5f; //* para limitar el rango en el que la torreta detecta al enemigo, voltee a ver

    private void Update()
    {
        if (_detectedEnemy == null) return;

       var direction = _detectedEnemy.transform.position - _torretPivot.parent.position; //restamos posicion para saber donde se encuentra el enemigo

        var targetRotation = Quaternion.LookRotation(direction, Vector3.up); //al detectarla que gire unicamente en el pivote de arriba.
        _torretPivot.rotation = targetRotation;
        var distance = Vector3.Distance(_detectedEnemy.transform.position, transform.parent.position); //para que la torreta siga a los enemigos
                                                                                                       //para ver mas que el primero.
        if(Mathf.Abs(distance) > 10f) //independientemente del tamaño de la esfera 
        {
            _detectedEnemy = null;
        }
    }
    private void OnTriggerEnter(Collider other)
        
    {
        if (other.CompareTag("Enemy") && _detectedEnemy == null )//detecta al enemigo y le asigna un valor, para seguirle disparando unicamente a ese
        {
            _detectedEnemy = other.gameObject;
        }
    }


    //private void OnTriggerExit(Collider other)
    //{
    //    if(other.CompareTag("Enemy") && _detectedEnemy == other.gameObject) //para que si el objeto que se tiene asignado sale del rango le 
    //                                                                        //deje de disparar.
    //    {
    //        _detectedEnemy = null;
    //    }} * lo comentamos porque modificamos el codigo de arriba.
    

}
