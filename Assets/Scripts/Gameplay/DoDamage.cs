using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : MonoBehaviour
{

   [SerializeField]private int _damage = 10;
   private void OnTriggerEnter(Collider other)
   {
      if (other.GetComponent<Health>() != null)
      {
         other.GetComponent<Health>().ReceiveDamage(_damage);
      }
   }
}
