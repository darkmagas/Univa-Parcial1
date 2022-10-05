using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyData : MonoBehaviour
{
    public int damage;

    public int EnemyLife;
    public Slider EnemyLifeBar;

    private void Update()
    {
        EnemyLifeBar.value = EnemyLife;

        if(Input.GetKeyDown(KeyCode.E))
        {
            EnemyLife -= damage;
        }
    }
}
