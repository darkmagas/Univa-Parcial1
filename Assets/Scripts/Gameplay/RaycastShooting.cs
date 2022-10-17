using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooting : MonoBehaviour
{

    [SerializeField] private float _maxRange = 10f;
    [SerializeField] private Transform _cannon = null;
    [Header("Shooting Settings")]
    [SerializeField] private int _damage = 10;
    [SerializeField] private GameObject _impactEffect = null;
    [SerializeField] private AudioSource _audioSource = null;
   
    private void FixedUpdate()
    {
        var ray = new Ray(_cannon.position, _cannon.forward);
        if (Physics.Raycast(ray, out var hit, _maxRange))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                if (!_audioSource.isPlaying) 
                    _audioSource.Play();
                Debug.Log(hit.collider.name);
                hit.collider.GetComponent<Health>().ReceiveDamage(_damage);
            }

        }
      
    }




}
