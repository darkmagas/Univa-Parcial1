using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    private int health;
    public float speed;
    public LayerMask layerPlayer;
    public float cadencia = 1f;
    float cadAux = 0;

     void Update()
    {
        Debug.DrawRay(transform.position, Vector3.left * .5f);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.left, .5f,
            layerPlayer);
        if (hit.collider != null)
        {
            cadAux += Time.deltaTime;
            if (cadAux >=cadencia)
            {
                cadAux = 0;
            }
        }
        else
        {
            cadAux = 0;
            transform.position -= Vector3.right * speed * Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            health--;
            Destroy(col.gameObject);

            if (health <= 0)
                Destroy(gameObject);
        }
    }
}

  