using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clase2 : MonoBehaviour
{
    [SerializeField]private List<Transform> _WayPoints = new List<Transform>();
    public string path = "";
    public float stoppingDistance = 0.2f;
    public float speed = 5f;

    private int _currentWayPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        var path = GameObject.Find(this.path);
        for (int i = 0; i < path.transform.childCount; i++)
        {
            _WayPoints.Add(path.transform.GetChild(i));
        }

        StartCoroutine( MoveToWayPoints());
    }

    IEnumerator MoveToWayPoints()
    {
        var distance = Vector3.Distance(transform.position, _WayPoints[_currentWayPoint].position);
        while (Mathf.Abs(distance) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, _WayPoints[_currentWayPoint].position, speed * Time.deltaTime);
            distance = Vector3.Distance(transform.position, _WayPoints[_currentWayPoint].position);
            yield return null;
        }

        if (_currentWayPoint < _WayPoints.Count - 1)
        {
            _currentWayPoint++;
            StartCoroutine(routine: MoveToWayPoints());
        }
    }

}
