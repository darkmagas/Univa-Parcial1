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
    [SerializeField] GameObject _impactEffect = null;
    [SerializeField] private float _shootongCD = 0.5f;
    private float _currentCD = 0f;

    [Header("AOE settings")]
    [SerializeField] private bool _isaAOE = false;

    [SerializeField] private float _radius = 2f;

    private void FixedUpdate()
    {
        if (_currentCD <= 0)
        {

            var ray = new Ray(_cannon.position, direction: _cannon.forward); // para darle una direccion en especifico al ca�on 
                                                                             //RaycastHit hit;
            if (Physics.Raycast(ray, out var hit, _maxRange))
            {
                if (hit.collider.CompareTag("Enemy"))
                {


                    if (_isaAOE)
                    {

                        var sphercast = Physics.SphereCastAll(hit.point, _radius, _cannon.forward);
                        _audioSource.Play();

                        for (int i = 0; i < sphercast.Length; i++)
                        {
                            var rayHit = sphercast[i];
                            if (rayHit.collider.CompareTag("Enemy"))
                            {
                                rayHit.collider.GetComponent<Health>().ReciveDamage(_damage);
                                EventDispatcher.Dispatch(new SpawnObject(_impactEffect, null, rayHit.point, Quaternion.identity, null));
                            }
                        }

                        _currentCD = _shootongCD;
                    }

                  //if (_audioSource.isPlaying)
                        _audioSource.Play();

                    EventDispatcher.Dispatch(new SpawnObject(_impactEffect, null, 
                        hit.point, Quaternion.identity, null));
                    hit.collider.GetComponent<Health>().ReciveDamage(_damage);

                    _currentCD = _shootongCD;
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



