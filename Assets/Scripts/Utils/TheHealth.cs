using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheHealth : MonoBehaviour
{
    private Image Bar;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    PlayerController_Script Player;

    private void Start ()
    {
        Bar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerController_Script>();


    }
    private void Update()
    {
        CurrentHealth = Player.Health;
        Bar.fillamount = CurrentHealth / MaxHealth;
    }
    
}
