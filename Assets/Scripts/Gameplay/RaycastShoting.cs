using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoting : MonoBehaviour
{
	[SerializeField] private Transform _cannon = null;
	[SerializeField] private float _maxRange = 10f;
	[Header("Shoting Setting")]
	[SerializeField] private int _damage = 10;
	[SerializeField] private AudioSource _audioSource = null; 
	[SerializeField] private GameObject _impactEffect = null;
	[SerializeField] private float _shootingCD = 1f;
	private float _currentCD = 0; 

	private void FixedUpdate()
	{
		if (_currentCD <= 0)
		{
		var ray = new Ray(origin: _cannon.position, direction: _cannon.forward);

			if (Physics.Raycast(ray, out var hit, _maxRange))
			{
				if (hit.collider.CompareTag("Enemy"))
				{
					if (!_audioSource.isPlaying)
					_audioSource.Play();

					hit.collider.GetComponent <Health>().ReceiveDamage (_damage);
					_currentCD = _shootingCD; 
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
