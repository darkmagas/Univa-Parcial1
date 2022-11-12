using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int vida;
    public GameObject barravida;
    
    
    void Update()
    {
        barravida.GetComponent<Slider>().value = vida;

        if (vida <= 0) 
        {
            Destroy(this.gameObject);
        }
    }
}
