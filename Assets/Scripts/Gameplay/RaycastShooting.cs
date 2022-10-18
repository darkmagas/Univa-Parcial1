using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RaycastShooting : MonoBehaviour //fixed Upadate es para fisica, es un frame rate fijo sin importar los fps que corra el juego
{
    [SerializeField] private Transform _cannon = null;
    [SerializeField] private float _maxRange = 10f;
    [Header("Shooting Settings")]
    [SerializeField] private int _damage = 10;
    [SerializeField] private AudioSource _audioSource = null;
    [SerializeField] private GameObject _impactEffect = null;
    [SerializeField] private float _shootingCD = 0.5f;
    private float _currentCD = 0f;
    //vamos a hacer el ca�on luego el da�o a un enemigo y si no que no haga da�o
   

    private void FixedUpdate()
    {
        if(_currentCD <= 0)
        {
            var ray = new Ray(_cannon.position, _cannon.forward);
            if (Physics.Raycast(ray, out var hit, _maxRange))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    if (!_audioSource.isPlaying)
                        _audioSource.Play();

                    hit.collider.GetComponent<Health>().ReceiveDamage(_damage);
                }
            }
        }
       
    }
    private void Update()
    {
        if (_currentCD > 0)
            _currentCD -= Time.deltaTime;
    }
}
