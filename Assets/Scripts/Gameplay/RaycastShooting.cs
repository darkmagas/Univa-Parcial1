using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooting : MonoBehaviour
{
   
    [SerializeField] private Transform _canon = null;
    [SerializeField] private float _maxRange = 10f;
    [Header("shooting Settings")]
    [SerializeField] private int _damage = 10;
    [SerializeField] private AudioSource _audioSource = null;
    [SerializeField] private GameObject _impactEffect = null;
    private void FixedUpdate()
    {
        var ray = new Ray(_canon.position, _canon.forward);
        if(Physics.Raycast(ray, out var hit, _maxRange))
        {
            if (hit.collider.CompareTag("enemy"))
            {
                if(!_audioSource.isPlaying)
                _audioSource.Play();
                hit.collider.GetComponent<Health>().ReceiveDamage(_damage);

            }
        }
       

    }
}
