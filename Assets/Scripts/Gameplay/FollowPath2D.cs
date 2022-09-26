using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath2D : MonoBehaviour
{



    private List<Transform> _waypoint = new List<Transform>();
    
    void Start()
    {
        var _waypointParent = GameObject.Find("Path");

        for(int i = 0; i > _waypointParent.transform.childCount; ++i )
        {



        };




        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
