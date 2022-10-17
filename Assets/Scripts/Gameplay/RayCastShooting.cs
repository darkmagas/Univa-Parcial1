using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShooting : MonoBehaviour
{
    [SerializeField] private Transform _cannon=null;
    [SerializeField] private float _maxRange = 10f;
    [Header("Shooting Settings")]
    [SerializeField] private int _damage = 10;
    [SerializeField] private AudioSource _audioSource = null;
    [SerializeField] private GameObject _impactEffect = null;

    private void FixedUpdate()
    {
        Ray ray = new Ray(_cannon.position, _cannon.forward);

        if(Physics.Raycast(ray, out var  hit, _maxRange))
        {
            if(hit.collider.CompareTag("Enemy"))
            {
                if(!_audioSource.isPlaying)
                    _audioSource.Play();
                    hit.collider.GetComponent<Health>().ReceiveDamage(_damage);
            }
        }
    }
}
