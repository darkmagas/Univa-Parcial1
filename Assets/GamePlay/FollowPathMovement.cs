using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathMovement : MonoBehaviour
{
    private List<Transform> _waypoints = new List<Transform>();
    private int _currentWayPoint = 0;

    public float speed = 5f;
    public float mainDistance = 0.2f;
    public string pathMain = "Path"; 

    // Start is called before the first frame update
    void Start()
    {


        var waypointParent = GameObject.Find(pathMain);
        for (int i = 0; i < waypointParent.transform.childCount; i++)

        {
            _waypoints.Add(waypointParent.transform.GetChild(i));
        }

        StartCoroutine(MoveToNextWaypoint());

    }

    private IEnumerator MoveToNextWaypoint()


    {

        var distance = Vector3.Distance(transform.position,
          _waypoints[_currentWayPoint].position);

        while (Mathf.Abs(distance) > mainDistance)
           



        {
            transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWayPoint].position, Time.deltaTime * mainDistance);

            distance = Vector3.Distance(transform.position,
          _waypoints[_currentWayPoint].position);

            yield return null;
        }
        if (_currentWayPoint < _waypoints.Count - 1) ;
        {
            _currentWayPoint++;

            StartCoroutine(MoveToNextWaypoint());
        }


    }

}
