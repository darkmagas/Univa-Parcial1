using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimationonEnemy : MonoBehaviour
{
  [SerializeField] private Animator animator;
    public void OnHealthChange (float hp)
    {
        _animator.SetTrigger(name: "Damage");
    }

    // Update is called once per frame
    public void OnDeath()
    {
        _animator.SetBool(name)
    }
}
