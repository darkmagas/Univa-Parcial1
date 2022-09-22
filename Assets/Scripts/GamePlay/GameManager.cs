using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField][Range(0,6)] private float timeStep = 1;
    // Start is called before the first frame update
    
    // Update is called once per frame
   private void Update()
    {
        Time.timeScale = timeStep;
    }
}
