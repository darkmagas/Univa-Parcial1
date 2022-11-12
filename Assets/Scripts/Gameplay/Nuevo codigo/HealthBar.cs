using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float health;
    public Text healthText;

     void Update()
    {
        healthText.text = "Health : " + health.ToString();
        if (health <=0)
        {
            dead();
        }
    }



    public void takeDamage(int amount)
    {
        health -= amount;
    }

    void dead()
    {
        Instantiate(gameObject, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
