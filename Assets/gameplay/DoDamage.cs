using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
   public int damage = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Healt>() != null)
        {
         var otherHealth = other.GetComponent<Healt>();
            otherHealth.receiveDamage(damage);


        }
                
                }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
