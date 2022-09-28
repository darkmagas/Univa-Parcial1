using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathMovement : MonoBehaviour
{

    [SerializeField]private List<Transform> _wayPoints = new List<Transform>();
    
    public float stoppingDistance = 0.2f;
    public float speed = 5f;

    // Start is called before the first frame update
    private int _currentWayPoint = 0;

    private void OnEnable()
    {
        _wayPoints.Clear();
        _currentWayPoint = 0;
    }

    public void InitEnemy(string pathName)
    {
        var path = GameObject.Find(pathName);
        for (int i = 0; i < path.transform.childCount; i++)
        {
            _wayPoints.Add(item: path.transform.GetChild(i));
        }
        StartCoroutine(routine: MoveToWayPoints());
    }

    IEnumerator MoveToWayPoints()
    {
        var distance = Vector3.Distance(transform.position, _wayPoints[_currentWayPoint].position);
        while (Mathf.Abs (distance) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentWayPoint].position, speed* Time.deltaTime);
            distance = Vector3.Distance(transform.position, _wayPoints[_currentWayPoint].position);
            yield return null;

            
        }
       
        if (_currentWayPoint < _wayPoints.Count - 1)
        {
            _currentWayPoint++;
            StartCoroutine(routine: MoveToWayPoints());
        }
    }

   
}
