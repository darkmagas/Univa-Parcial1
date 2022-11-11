using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeath : MonoBehaviour


{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ParticleLifetime());
    }

    IEnumerator ParticleLifetime()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
    
}
