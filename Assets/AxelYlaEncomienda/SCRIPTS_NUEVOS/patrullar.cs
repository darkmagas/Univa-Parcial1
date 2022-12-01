using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrullar : MonoBehaviour
{
    [SerializeField] private float speedMovement;

    [SerializeField] private Transform[] pointMovement;

    [SerializeField] private float MinDistance;

    private int numeroaleatorio;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        numeroaleatorio = Random.Range(0, pointMovement.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Girar();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointMovement[numeroaleatorio].position, speedMovement * Time.deltaTime);

        if(Vector2.Distance(transform.position,pointMovement[numeroaleatorio].position)< MinDistance)
        {
            numeroaleatorio = Random.Range(0, pointMovement.Length);
            Girar();
        }

    }

    private void Girar()
    {
        if (transform.position.x < pointMovement[numeroaleatorio].position.x)
        {
            spriteRenderer.flipX = true;
        }
              else {
            spriteRenderer.flipX = false;


        }
    }
}
