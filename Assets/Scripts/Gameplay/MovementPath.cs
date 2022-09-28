using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPath : MonoBehaviour
{
    [SerializeField] private List<Transform> _Waypoint = new List<Transform>();
    private int _currentWaypoint;
    public string path = "";
    public float stoppingDistance = 0.2f;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        var path = GameObject.Find("Path");
        for (int i = 0; i < path.transform.childCount; i++)
        {
            _Waypoint.Add(item: path.transform.GetChild(i));
        }
        StartCoroutine(routine: MoveToWaypoint());
    }

    // Update is called once per frame
    IEnumerator MoveToWaypoint()
    {
        var distance = Vector3.Distance(transform.position,
            _Waypoint[_currentWaypoint].position);
        while (Mathf.Abs(distance) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                _Waypoint[_currentWaypoint].position, Time.deltaTime * speed);
            distance = Vector3.Distance(transform.position,
            _Waypoint[_currentWaypoint].position);
            yield return null;
        }
        if (_currentWaypoint < _Waypoint.Count - 1)
        {
            _currentWaypoint++;
            StartCoroutine(routine: MoveToWaypoint());
        }
    }
}
