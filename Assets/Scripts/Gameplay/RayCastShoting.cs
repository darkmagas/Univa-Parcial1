using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class RayCastShoting : MonoBehaviour //fixed update se usa para fisicas. es de un frame rate fijo sin importar los fps que corra el juego
{
    [SerializeField] private Transform _cannon = null;
    [SerializeField] private float _maxRange = 10f;
    [Header("Shooting Settings")]
    [SerializeField] private int _damage = 10;
    [SerializeField] private AudioSource _audioSource = null;
    [SerializeField] private GameObject _impactEffect = null;
    //vamos a hacer que el cañon haga daño al dispara a un enemigo y si no que no haga daño
    [SerializeField] private float _shootingCD = 0.5f;
    private float _currentCD = 0f;
    [Header("AOE settings")]
    [SerializeField] private bool _isAOE = false;
    [SerializeField] private float _radius = 2f;

    private void FixedUpdate()
    {
       
        if(_currentCD <= 0) 
        {
            var ray = new Ray(_cannon.position, _cannon.forward); //agarramos el añon y hacia donde va a disparar
            if (Physics.Raycast(ray, out var hit, _maxRange)) //lanza el rayo al rango maximo y regresa 
            {
                if (hit.collider.CompareTag("Enemy")) //si se comparan varias cosas se usa un switch
                {
                    if (_isAOE)
                    {
                        var sphercast = Physics.SphereCastAll(hit.point, _radius, _cannon.forward);
                        for (int i = 0; i < sphercast.Length; i++)
                        {
                            var rayHit = sphercast[i];
                            if (rayHit.collider.CompareTag("Enemy"))
                            {
                                rayHit.collider.GetComponent<Health>().ReciveDamage(_damage);
                                EventDispatcher.Dispatch(new SpawnObject(_impactEffect, null, hit.point, Quaternion.identity,
                                                        null));//*x2
                            }
                        }

                        _currentCD = _shootingCD;
                    }
                    else
                    { //*(!_audioSource.isPlaying) //si queremos que se reproduzca de manera infinita comentamos esta linea.
                        _audioSource.Play();
                        hit.collider.GetComponent<Health>().ReciveDamage(_damage);
                        EventDispatcher.Dispatch(new SpawnObject(_impactEffect, null, hit.point, Quaternion.identity,
                            null)); //*para que lance las particulas al disparar
                    }

                    //hit.collider.GetComponent<Health>().ReciveDamage(_damage);

                    //_currentCD = _shootingCD;
                }
            }
        }
        

    }

    private void Update()
    {
        if(_currentCD > 0)
        {
            _currentCD -= Time.deltaTime;
        }
    }
}
