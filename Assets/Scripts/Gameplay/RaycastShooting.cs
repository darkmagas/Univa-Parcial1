using Magas.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooting : MonoBehaviour
{
    [SerializeField] private Transform _Cannon = null;
    [SerializeField] private float _maxRange = 10f;
    [Header("Shooting Settings")]
    [SerializeField] private int _damage = 10;
    [SerializeField] private AudioSource _audioSource = null;
    [SerializeField] private GameObject _impactEffect = null;
    [SerializeField] private float _shootingCD = 1f;
    private float _currentCD = 0f;
    
    [Header("AOE settings")]
    [SerializeField] private bool _isAOE = false;

    [SerializeField] private float _radius = 2f;

    private void FixedUpdate()
    {
        if (_currentCD <= 0)
        {
            var ray = new Ray(_Cannon.position, _Cannon.forward);
            if (Physics.Raycast(ray, out var hit, _maxRange))
            {


                if (hit.collider.CompareTag("Enemy"))
                {
                    if (_isAOE)
                    {
                        var sphereCast = Physics.SphereCastAll(hit.point, _radius,
                            _Cannon.forward);
                        for (int i = 0; i < sphereCast.Length; i++)
                        {
                            var rayHit = sphereCast[i];
                            if (rayHit.collider.CompareTag("Enemy"))
                            {
                                rayHit.collider.GetComponent<Health>().ReceiveDamange(_damage);

                                EventDispatcher.Dispatch(new SpawnObject(_impactEffect, null
                                    , rayHit.point, Quaternion.identity, null));
                            }
                        }
                        _currentCD = _shootingCD;
                    }
                    else
                    {
                        if (!_audioSource.isPlaying)
                            _audioSource.Play();

                        EventDispatcher.Dispatch(new SpawnObject(_impactEffect, null
                            , hit.point, Quaternion.identity, null));
                        hit.collider.GetComponent<Health>().ReceiveDamange(_damage);
                        _currentCD = _shootingCD;
                    }

                }
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