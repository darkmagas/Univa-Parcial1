using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bueno : MonoBehaviour
 {
    public int health;
    void Dano ()
    {
        health--;
        if (health <= 0)
            Destroy(gameObject);

    }
}