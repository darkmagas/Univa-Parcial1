using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathMovement : MonoBehaviour

{
    private List<Transform> _WayPoints = new List<Transform>();
    private int _currentWayPoint = 0;
    public float speed = 5f;
    public float mindDistance =  0.2f;
    private Vector3 _originalPosition;
    private bool _isDeath = false;

    private void OnEnable()
    {
        _isDeath = false;
        _originalPosition = transform.position;
        _WayPoints.Clear();
        _currentWayPoint = 0;
        GameManager.Instance.AddEnemy(1);
    }

    private void OnDisable()
    {
        transform.position = _originalPosition;
        GameManager.Instance.AddEnemy(-1);
    }

    public void OnDeath()
    {
        _isDeath = true;
        StopCoroutine(MoveTollexWaypoint());
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
        while (Mathf.Abs(distance) > mindDistance && !_isDeath)

        {
            transform.position = Vector3.MoveTowards( transform.position, _WayPoints[_currentWayPoint].position, Time.deltaTime * speed);
            distance = Vector3.Distance(a: transform.position, b: _WayPoints[_currentWayPoint].position);
            yield return null;
          
        
        }

        if(_currentWayPoint< _WayPoints.Count-1 && !_isDeath)
        {
            _currentWayPoint++;

            StartCoroutine(MoveTollexWaypoint());

        }

    }
    
       
    }

