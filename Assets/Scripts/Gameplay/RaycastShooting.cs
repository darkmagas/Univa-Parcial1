using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooting : MonoBehaviour
{
    [SerializeField] private Transform _canon = null;
    [SerializeField] private float _maxRange = 10f;
    [Header("Shoothing settings")]
    [SerializeField] private int _damage = 10;
    [SerializeField] private AudioSource _audioSource = null;
    [SerializeField] private GameManager _impactEffect = null;
    [SerializeField] private float _shootingCD = 0.5f;
    private float _currentCD = 0f;








    /// <summary>
    /// P== --------------------E / 0
    /// </summary>


    private void FixedUpdate()
    {

        if (_currentCD <= 0)
        {
            var ray = new Ray(_canon.position, _canon.forward);
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
        if(_currentCD> 0)
            _currentCD -= Time.deltaTime;
    }
}

