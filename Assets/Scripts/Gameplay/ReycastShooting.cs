using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;
public class ReycastShooting : MonoBehaviour
{

    [SerializeField] private Transform _cannon = null;
    [SerializeField] private float _maxRange = 10f;
    [Header("Shooting Settings")]
    [SerializeField] private int _damage = 10;
    [SerializeField] private AudioSource _audioSource = null;
    [SerializeField] private GameObject _impactEffect = null;
    [SerializeField] private float _shootingCD = 1F;
    private float _currentCD = 0;


    private void FixedUpdate()
    {
        var ray = new Ray(_cannon.position, _cannon.forward);
        
        if(Physics.Raycast(ray, out var hit, _maxRange))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                // (!_audioSource.isPlaying)
                    _audioSource.Play();

                EventDispatcher.Dispatch(new SpawnObject(_impactEffect, null, hit.point, Quaternion.identity, null));
                hit.collider.GetComponent<Health>().ReceiveDamage(_damage);
                _currentCD = _shootingCD;

            }
        }

    }
    private void Update()
    {
        if (_currentCD > 0)
        {
            _currentCD -= Time.deltaTime;
        }
    }
}


