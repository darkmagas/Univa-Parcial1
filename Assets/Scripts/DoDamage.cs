using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{
    public int damage = 1;
    private void OnTriggerEnter(Collider other)

    {
        if (other.GetComponent<Healt>())
        {
            var otherHealt=other.GetComponent<Healt>()
            otherHealt.ReceiveDamage(10);
        }
    }
}
