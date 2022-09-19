using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoDamage : MonoBehaviour
{
    public int damage = 1; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>() !=null)
            {
            var otherHealth = other.GetComponent<Health>();
            otherHealth.ReceiveDamage(10);
            }
    }

}
