using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY_AXEL : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;

    public bool MoveToA = false;
    public bool MoveToB = false;
    public float speed;

    private Rigidbody2D MyRb;

    // Start is called before the first frame update
    void Start()
    {
        MyRb = GetComponent<Rigidbody2D>();
        MoveToB = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MoveToA == true)
        {
            MyRb.transform.position = Vector2.MoveTowards(transform.position, puntoA.position, speed * Time.deltaTime);

            if (transform.position == puntoA.position)
            {
                MoveToA = false;
                MoveToB = true;

            }


        }

        if (MoveToB == true)
        {
            MyRb.transform.position = Vector2.MoveTowards(transform.position, puntoA.position, speed * Time.deltaTime);

            if (transform.position == puntoB.position)
            {
                MoveToA = true;
                MoveToB = false;

            }


        }
    }
}
