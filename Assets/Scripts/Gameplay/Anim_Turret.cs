using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Turret : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void AttackMode ()
    {
        _animator.SetBool("DoAttack", true);
    }
}
