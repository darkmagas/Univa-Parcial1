using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathMovement : MonoBehaviour
{
    private List<Transform> _wayPoints = new List<Transform>();
    private int _currentWayPoint = 0;
    public float speed = 5f;
    public float minDistanse = 0.2f;
    private Vector3 _originalPosition;
    private bool _isDeath = false; //*x2
    //public string patName = "Path"; al reiniciar el siclo ya no se ejecutta el start. se cambia por los codigos de abajo.

    // Start is called before the first frame update
    //void Start()
    //{var waypointParent = GameObject.Find(patName);
    //for (int i = 0; i < waypointParent.transform.childCount; i++)
    //{_wayPoints.Add(waypointParent.transform.GetChild(i));

    private void OnEnable() //se agrega este
    {
        _isDeath = false; //*x2
        _originalPosition = transform.position;
        _wayPoints.Clear();
        _currentWayPoint = 0;
        GameManager.Instance.AddEnemy(1); //*
    }
    private void OnDisable()
    {
        transform.position = _originalPosition;
        GameManager.Instance.AddEnemy(-1); //*
    }

    public void OnDeath() //*x2 se agrega para detener la corrutina y que el cuerpo no se mueva muerto
    {
        _isDeath = true;
        StopCoroutine(MoveToNextWayPoinyt());
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
        while (Mathf.Abs(distance) > minDistanse && !_isDeath)
        {
            transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentWayPoint].position, Time.deltaTime * speed);
            distance = Vector3.Distance(transform.position, _wayPoints[_currentWayPoint].position);
            yield return null;
        }

        if (_currentWayPoint < _wayPoints.Count - 1 && !_isDeath)
        {
            _currentWayPoint++;
            StartCoroutine(MoveToNextWayPoinyt());
        }
    }


}





   
