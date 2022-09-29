using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathMovement : MonoBehaviour

{
    private List<Transform> _WayPoints = new List<Transform>();
    private int _currentWayPoint = 0;
    public float speed = 5f;
    public float mindDistance =  0.2f;

    private void OnEnable()
    {
        _WayPoints.Clear();
        _currentWayPoint = 0;
    }

   
    public void InitEnemy(string pathName) 
    {
        var waypointParent = GameObject.Find(pathName);
        for (int i = 0; i < waypointParent.transform.childCount; i++)
        {
            _WayPoints.Add(item: waypointParent.transform.GetChild(i));

        }

        StartCoroutine(MoveTollexWaypoint());
    
    }
    private IEnumerator MoveTollexWaypoint()

    {

        var distance = Vector3.Distance(a: transform.position, b: _WayPoints[_currentWayPoint].position);
        while (Mathf.Abs(distance) > mindDistance)

        {
            transform.position = Vector3.MoveTowards( transform.position, _WayPoints[_currentWayPoint].position, Time.deltaTime * speed);
            distance = Vector3.Distance(a: transform.position, b: _WayPoints[_currentWayPoint].position);
            yield return null;
          
        
        }

        if(_currentWayPoint< _WayPoints.Count-1)
        {
            _currentWayPoint++;

            StartCoroutine(MoveTollexWaypoint());

        }

    }
    
       
    }

