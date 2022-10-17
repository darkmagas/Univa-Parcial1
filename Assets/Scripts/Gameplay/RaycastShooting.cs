using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RaycastShooting : MonoBehaviour
{

    [SerializeField] private Transform _cannon = null;
    [SerializeField] private float _maxRange = 0f;
    [SerializeField] private AudioSource _audioSource = null;
    [SerializeField] private GameObject _impactEffect = null;
    private void FixedUpdate()
    {
        var ray = new Ray(origin: _cannon.position, direction: _cannon.forward);
        if (Physics.Raycast(ray, out var hit, _maxRange))
        {
            if (hit.collider.CompareTag("Enemy"))
            { 
              if(!_audioSource.isPlaying)
                    _audioSource.Play();
                hit.collider.GetComponent<Health>().ReceiveDamage(_Damage);
            }
        
        }







    }

}
