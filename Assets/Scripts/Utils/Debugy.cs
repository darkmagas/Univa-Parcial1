using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugy : MonoBehaviour
{
    private void Awake()
    {
       Debug.Log("Awake");
      
    }

    // Start is called before the first frame update
    private void Start()
    {
       Debug.Log("Start");
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log("Update");
    }

    private void LateUpdate()
    {
       Debug.Log("LateUpdate");
    }
}
