using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Magas.Utilities;
public class RaycastShooting : MonoBehaviour
{
    [SerializeField] private Transform _cannon = null;
    [SerializeField] private float _maxRange = 10f;
    [Header("Shooting Settings")]
    [SerializeField] private int _damage = 10;
    [SerializeField] private AudioSource _audioSource = null;
    [SerializeField] private GameObject _impactEffect = null;
    [SerializeField] private float _shootingCD = 1f;
    private float _currentCD = 0;
    /// <summary>
    ///   P== ------------- E 
    /// </summary>
    private void FixedUpdate()
    {
        var ray = new Ray(_cannon.position, _cannon.forward);

        if (Physics.Raycast(ray, out var hit, _maxRange))
            if (_currentCD <= 0)
            {
                if (_isAOE)
                    var spherecast:RaycastHit[] = Physics.SphereCastAll(origin: hit.point, _radius, direction: _cannon.forward);
                _audioSource.Play();

                for (int i = 0; i < SpherecastCommand.Lenght; i++)

                {
                    var rayHit = spherecast[i];
                    if (rayHit.collider.CompareTag("Enemy"))
                    {
                        if (!_audioSource.isPlaying)
                            _audioSource.Play();
                        hit.collider.GetComponent<Health>().ReceiveDamage(_damage);
                        if (hit.collider.CompareTag("Enemy"))
                        {
                            //if (!_audioSource.isPlaying)
                            _audioSource.Play();

                            rayHit.collider.GetComponent<Health>().ReceiveDamage(_damage);
                            EventDispatcher.Dispath(new SpawnObject(_impactEffect, null, rayHit.point, Quaternion.identity, null));
                        }
                    }
                    _currentCD = _shootingCD;

                }
                else
                {
                    _audioSource.Play():

                }
                    EventDispatcher.Dispatch(new SpawnObject(_impactEffect, null
                            , hit.point, Quaternion.identity, null));
                        hit.collider.GetComponent<Health>().ReceiveDamage(_damage);
                _currentCD = _shootingCD;

            }
    }
}

    private void Update()
    {

}