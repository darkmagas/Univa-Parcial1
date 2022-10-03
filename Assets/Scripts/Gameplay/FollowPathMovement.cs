using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> _wayPoints = new List<Transform>();
    private int _currentWayPoint = 0;
    public string path = ""; /*esto ayuda a poder crear varios paths*/
    public float stoppingDistance = 0.2f;
    public float speed = 5f;

    

    private void OnEnable()  // on enebale sirve para que cuando se vuela a activar del pool se reseté 
    {
        _wayPoints.Clear();
        _currentWayPoint = 0;
    }

    //private int d; (solo yo tengo acceso) ameno que le pongas [SerializeField]
    //public int a; (Todo el mundo tiene acceso)
    //protected int b; (solo la descendencia tiene acceso)
    //internal int c; (sabe alch)

    // Start is called before the first frame update
    public void InitEnemy(string pathname)
    {
        var path = GameObject.Find(this.path); 
        for (int i = 0; i < path.transform.childCount; i++)
        {
            _wayPoints.Add(path.transform.GetChild(i));
        }

        StartCoroutine(MoveToWayPoints());
    }

    //corrutina = algo que se actualiza constantemente pero lo puedo denteer

    IEnumerator MoveToWayPoints()
    {
        var distance = Vector3.Distance(transform.position, _wayPoints[_currentWayPoint].position );
        //calcular distancia entre a y b
        while (Mathf.Abs(distance) > 0.2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentWayPoint].position,speed * Time.deltaTime); /*ordena que se desplce hacie el waypoint*/
            distance = Vector3.Distance(transform.position, _wayPoints[_currentWayPoint].position); /*Se vuelve a insertar esta linea para poder hacer el loop de buscar el waypoint*/
            yield return null; /*sirve para no trabar la compu*/
        }
        if (_currentWayPoint < _wayPoints.Count - 1)
        {
            _currentWayPoint++;
            StartCoroutine(MoveToWayPoints());
        }

    }
}