using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Magas.Utilities;

public class RaycastShooting : MonoBehaviour
{
    [SerializeField] private Transform _cannon = null;
    [SerializeField] private float _maxRange = 10f;
    [SerializeField] private int _damage = 10;
    [SerializeField] private AudioSource _audioSource=null;
    [SerializeField] private GameObject _impactEffect = null;
    [SerializeField] private float _shootingCD = 1f;
    private float _currenteCD = 0;
    private void FixedUpdate()
    {
        if (_currenteCD <= 0)
        { 
          var ray = new Ray(_cannon.position, _cannon.forward);

            if (Physics.Raycast(ray, out var hit, _maxRange))
            {
                if (hit.collider.CompareTag("Enemy"))
                {

                    if (!_audioSource.isPlaying)
                        _audioSource.Play();

                    EventDispatcher.Dispatch(new SpawnObject(_impactEffect, null, hit.point, Quaternion.identity, null));

                    hit.collider.GetComponent<Health>().RecieveDamage(_damage);
                    _currenteCD = _shootingCD;
                }
            }
        }
       
    }
    private void Update()
    {
        if (_currenteCD >0)
        {
            _currenteCD -= Time.deltaTime; 
        }
    }
}
