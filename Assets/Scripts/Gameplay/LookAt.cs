using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Camera cameraToFollow;
    void Start()
    {

    }

    private void Update()
    {
        transform.rotation=Quaternion.LookRotation( transform.position - cameraToFollow.transform.position);
    }
}
