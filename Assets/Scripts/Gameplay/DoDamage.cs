using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>() != null)
        {
            other.GetComponent<Health>().ReceiveDamage(damage);
            

            //var otherHealth = other.GetComponent<Health>();
            //otherHealth.ReceiveDamage(damage);
        }
    }
}
