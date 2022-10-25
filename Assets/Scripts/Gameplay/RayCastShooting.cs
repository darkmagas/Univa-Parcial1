using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class RayCastShooting : MonoBehaviour
{

    [SerializeField] private Transform _cannon = null;
    [SerializeField] private float _maxRange = 10f;
    [Header("Shooting Setings")]
    [SerializeField] private int _damage = 10;
    [SerializeField] private AudioSource _audioSource = null;
    [SerializeField] private GameObject _impactEffect = null;
    [SerializeField] private float _shootingCD = 0.5f;
    private float _currentCD = 0f;
    private void FixedUpdate()
    {
        if (_currentCD <= 0)
        {



            var ray = new Ray(_cannon.position, _cannon.forward);
            if (Physics.Raycast(ray, out var hit, _maxRange))
            {
                // switch( hit. collider.tag)  para hacer que choque con mas cosas



                if (hit.collider.CompareTag("Enemy"))
                {
                    //if (!_audioSource.isPlaying)
                        _audioSource.Play();
                    EventDispatcher.Dispatch(new SpawnObject(_impactEffect, null, hit.point, Quaternion.identity, null));

                    hit.collider.GetComponent<Health>().RecieveDamage(_damage);

                    _currentCD = _shootingCD;

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
