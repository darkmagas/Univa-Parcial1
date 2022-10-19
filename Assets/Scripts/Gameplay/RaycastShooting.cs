using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using Magas.Utilities;

public class RaycastShooting : MonoBehaviour
{

    [SerializeField] private Transform _cannon = null;
    [SerializeField] private float _maxRange = 0f;
    [SerializeField] private AudioSource _audioSource = null;
    [SerializeField] private GameObject _impactEffect = null;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _shootingCD = 1f;
    private float _currentCD = 0 ;
    private void FixedUpdate()
    {
        var ray = new Ray(origin: _cannon.position, direction: _cannon.forward);
        if (Physics.Raycast(ray, out var hit, _maxRange))
        {
            if (hit.collider.CompareTag("Enemy"))
            { 
              if(!_audioSource.isPlaying)
                    _audioSource.Play();
                EventDispatcher.Dispatch(signal:new SpawnObject(_impactEffect, Parent: null 
                    ,hit.point, Quaternion.identity, OnSpawned: null));
                hit.collider.GetComponent<Health>().ReceiveDamage(_damage);
                _currentCD = _shootingCD;
            }
        
        }







    }
    private void update()
    { 
    if (_currentCD >0 )
            _currentCD -= Time.deltaTime;
    
    }
}
