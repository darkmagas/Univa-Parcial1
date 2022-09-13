using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathMovement : MonoBehaviour
{
private List<Transform> _wayPoints = new List<Transform();
private int _currentWayPoint = 0;
public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        var_waypointparent = GameObject.Find("Path")
        for(int i = 0; i <waypointParent.transform.Childcount; i++)
        {
        _wayPoints.add(item.waypointParent.transform.GetChild(i));)
        }
    }

    // Update is called once per frame
    Private IEnumerator MoveNextWaypoint()
    {
    
    }
}
