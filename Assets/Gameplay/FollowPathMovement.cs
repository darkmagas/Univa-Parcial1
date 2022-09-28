using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathMovement : MonoBehaviour
{

    [SerializeField]private List<Transform> _wayPoints = new List<Transform>();

    private int _currentWaypoint = 0;
    public float stoppingDistance = 0.2f;
    public float speed = 5f;

    private void OnEnable()
    {
        
        _wayPoints.Clear();
        _currentWaypoint = 0;

    }

    public void InitEnemy(string pathName)
    {

        var path = GameObject.Find(pathName);
        for (int i = 0; i <path.transform.childCount; i++)
        {
            _wayPoints.Add(path.transform.GetChild(i));
        }

        StartCoroutine(MoveToWayPoints());

    }

    IEnumerator MoveToWayPoints()
    {

        var distance = Vector3.Distance(transform.position,
            _wayPoints[_currentWaypoint].position);

        while (Mathf.Abs (distance) > stoppingDistance)
        {
            transform.position =
                Vector3.MoveTowards(transform.position,
                _wayPoints[_currentWaypoint].position, speed * Time.deltaTime);

            distance = Vector3.Distance(transform.position,
            _wayPoints[_currentWaypoint].position);

            yield return null;
        } 

        if (_currentWaypoint < _wayPoints.Count - 1)
        {
            _currentWaypoint++;
            StartCoroutine(MoveToWayPoints());
        }

    }

}
