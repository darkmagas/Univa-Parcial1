using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathMovement : MonoBehaviour
{
    private List<Transform> _wayPoints = new List<Transform>();
    private int _currentWayPoint = 0;
    public float speed = 5f;
    public float minDistanse = 0.2f;
    //public string patName = "Path"; al reiniciar el siclo ya no se ejecutta el start. se cambia por los codigos de abajo.

    // Start is called before the first frame update
    //void Start()
    //{var waypointParent = GameObject.Find(patName);
    //for (int i = 0; i < waypointParent.transform.childCount; i++)
    //{_wayPoints.Add(waypointParent.transform.GetChild(i));

    private void OnEnable() //se agrega este
    {
        _wayPoints.Clear();
        _currentWayPoint = 0;
    }
    public void InitEnemy(string pathName) //el start se cambia por IntEnemy
    {
        var waypointParent = GameObject.Find(pathName);
        for (int i = 0; i < waypointParent.transform.childCount; i++)
        {
            _wayPoints.Add(waypointParent.transform.GetChild(i));
        }
        StartCoroutine(MoveToNextWayPoinyt());
    }
         private IEnumerator MoveToNextWayPoinyt()
    {
        var distance = Vector3.Distance(transform.position, _wayPoints[_currentWayPoint].position);
        while (Mathf.Abs(distance) > minDistanse)
        {
            transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentWayPoint].position, Time.deltaTime * speed);
            distance = Vector3.Distance(transform.position, _wayPoints[_currentWayPoint].position);
            yield return null;
        }

        if (_currentWayPoint < _wayPoints.Count - 1)
        {
            _currentWayPoint++;
            StartCoroutine(MoveToNextWayPoinyt());
        }
    }


}





   
