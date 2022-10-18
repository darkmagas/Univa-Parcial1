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
    [SerializeField] private float _shootingCD = 0.5f;
    private float _currentCD = 0f;

    /// <summary>
    /// p== ------------ E / 0
    /// <summary>

    private void FixedUpdate()
    {
        if (_currentCD <= 0)
        { 
            var ray = new Ray(_Cannon.position, _Cannon.forward);
            if (Physics.Raycast(ray, out var hit, _maxRange))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    if (!_audioSource.isPlaying)
                        _audioSource.Play();

                    hit.collider.GetComponent<Health>().ReceiveDamange(_damage);
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