using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathMovement : MonoBehaviour
{

   // [SerializeField] private List<Transform> _wayPoints = new List<Transform>();
   // public string Path = "Path";

   // public float stoppingDistance = 0.2f;
   
   // public float speed = 5f;

    //private int _currentWayPoint = 0;

    

    // Start is called before the first frame update
    public void Start()
    {
       // var path = GameObject.Find(this.Path);

       // for (int i = 0; i < path.transform.childCount; i++)
       // {
       //     _wayPoints.Add(item: path.transform.GetChild(i));
       // }
       // StartCoroutine(MovetoWaypoint());
    }

      //private IEnumerator MoveToWayPoints()
    //{
       // var distance = Vector3.Distance(a: transform.position, b: _wayPoints[_currentWayPoint].position);

        //while (Mathf.Abs(distance) > stoppingDistance)
       // {
        //    transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentWayPoint].position, maxDistanceDelta: speed * Time.deltaTime);

         //   distance = Vector3.Distance(a: transform.position, b: _wayPoints[_currentWayPoint].position);

            //Le dice a la maquina que espere un Frame para volver a ejecutar

           // yield return null;
       // }
        

        
        //if (_currentWayPoint < _wayPoints.Count - 1)
        //{
         //   _currentWayPoint++;
          //  StartCoroutine(MoveToWaypoint());

       // }
        



    }
    
        
 




