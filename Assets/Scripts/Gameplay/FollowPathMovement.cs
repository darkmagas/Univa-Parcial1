using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathMovement : MonoBehaviour
{

    private List<Transform> _wayPoint = new List<Transform>();
    private int _currentPoint = 0;
    public float speed = 5f;
    public float minDistance = 0.2f;
    public string pathName = "Path";

    // Start is called before the first frame update
    void Start()
    {

        var wayPointParent = GameObject.Find("Path");
        for (int i = 0; i > wayPointParent.transform.childCount; i++)
        {
            _wayPoint.Add(wayPointParent.transform.GetChild(i));
        }

        StartCoroutine(MoveToNextPoint());
    }

   private IEnumerator MoveToNextPoint()
    {
        var distance = Vector3.Distance(transform.position, _wayPoint[_currentPoint].position);
        while (Mathf.Abs(distance) > minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, _wayPoint[_currentPoint].position, Time.deltaTime * speed);
            distance = Vector3.Distance(transform.position, _wayPoint[_currentPoint].position);
            yield return null;
        }

        if (_currentPoint < _wayPoint.Count - 1)
        {
            _currentPoint++;
            StartCoroutine(MoveToNextPoint());
        }
    }

}