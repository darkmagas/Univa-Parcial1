using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathMovementPrueba : MonoBehaviour
{
    [SerializeField] private List<Transform> _wayPoints = new List<Transform>();

    private int _currentWayPoint = 0;

    public string path = "";
    public float stoppingDistance = 0.2f;
    public float speed = 5f;

    private void OnEnable()
    {
        _wayPoints.Clear();
        _currentWayPoint = 0;

    }
    public void InitEnemy(string pathName)
    {
        var path = GameObject.Find("Path2");
        for (int i = 0; i < path.transform.childCount; i++)
        {
            _wayPoints.Add(path.transform.GetChild(i));
        }
        StartCoroutine(MoveToWayPoints());
    }

    IEnumerator MoveToWayPoints()
    {
        var distance = Vector3.Distance(transform.position,
            _wayPoints[_currentWayPoint].position);

        while (Mathf.Abs(distance) > 0.2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentWayPoint].position,
                speed * Time.deltaTime);

            yield return null;

            distance = Vector3.Distance(transform.position,
           _wayPoints[_currentWayPoint].position);
        }
        if (_currentWayPoint < _wayPoints.Count - 1)
        {
            _currentWayPoint++;
            StartCoroutine(MoveToWayPoints());
        }

    }


}