using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathMovement : MonoBehaviour
{

    [SerializeField] private List<Transform> _wayPoints = new List<Transform>();
    //public string name_path = "Path";

    public float stoppingDistance = 0.2f;
   
    public float speed = 5f;

    private int _currentWayPoint = 0;

    private Vector3 _originalPosition;





    private void OnEnable()
    {
        _originalPosition = transform.position;
        _wayPoints.Clear();
        _currentWayPoint = 0;
    }

    private void OnDisable()
    {
        transform.position = _originalPosition;
    }

    public void InitEnemy(string pathName)
    {
        var waypointParent = GameObject.Find(pathName);
        
        for (int i = 0; i < waypointParent.transform.childCount; i++)
        {
            _wayPoints.Add(item: waypointParent.transform.GetChild(i));
        }
        StartCoroutine(MoveToWayPoints());
    }

    private IEnumerator MoveToWayPoints()
    {
        var distance = Vector3.Distance(transform.position, _wayPoints[_currentWayPoint].position);

        while (Mathf.Abs(distance) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentWayPoint].position, speed * Time.deltaTime);

            distance = Vector3.Distance(transform.position, _wayPoints[_currentWayPoint].position);

            //Le dice a la maquina que espere un Frame para volver a ejecutar

            yield return null;
        }




        if (_currentWayPoint < _wayPoints.Count - 1)
        {
            _currentWayPoint++;
            StartCoroutine(MoveToWayPoints());

        }


    }


}
        




    
        
 




