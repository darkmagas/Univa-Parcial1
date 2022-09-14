using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathMovement : MonoBehaviour
{

    [SerializeField] private List<Tranform> _wayPoints = new List<Tranform>();
    public string path = "",

    public float stoppingDistance = 0.2f;
    public float speed = 5f;

    //public int a ;

    //protected int b;

    private int _currentWayPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        var path :GameObject = GameObject.Find(this.path)

        for (int i = 0, i; i < path.tranform.childCount; i++)
        {
            _wayPoints.Add(item: path.tranform.GetChild(i));
        }
        StartCoroutine(routine: MovetoWayPoints());
    }

    IEnumerator MoveToWayPoints()
    {
        var distance:float = Vector3.Distance(a: tranform.position, b: _wayPoints[_currentWayPoint].position);

        while (Mathf.Abs(distance) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(current: tranform.position, target: _wayPoints[_currentWayPoint].position, maxDistanceDelta: speed * Time.deltaTime);

            distance: float = Vector3.Distance(a: tranform.position, b: _wayPoints[_currentWayPoint].position);

            //Le dice a la maquina que espere un Frame para volver a ejecutar

            yield return null;
        }
        if (_currentWayPoint < _waypoints.Count - 1)
        {
            _currentWayPoint++;
            StartCoroutine(routine: MoveToWayPoints());

        }
        // Update is called once per frame



    }
    void Update()
    {
        
    }



}
