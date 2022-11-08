using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void OnHealthChange (float hp)
    {
        _animator.SetTrigger("Damage");

    }

    public void OnDeath()
    {
        _animator.SetBool("Death", true);
    }
}
