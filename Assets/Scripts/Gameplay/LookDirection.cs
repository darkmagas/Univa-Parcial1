using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDirection : MonoBehaviour
{
    private Vector3 _lastPosition = Vector3.zero;
    [Header ("Settings")] //para que se vea en unity. Al parecer no necesita punto y coma.
    [SerializeField]private float _rotationSpeed = 10.0f; //Entre corchetes se lo conocen como decoradores. este hace publico algo privado pero se modifica desde dentro.
    private void Awake()
    {
        _lastPosition = transform.position;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var direction = transform.position - _lastPosition;
        var targetDirecction = Vector3.RotateTowards(transform.forward, direction, 30, Time.deltaTime);

        //30 es maxRadiansDelta. Con diretion calculamos el lado hacia donde se mira, con forward que es la flecha azul (z) la tomamos y nos asegurams de que voltee hacia esa direccion.

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation (targetDirecction), Time.deltaTime*_rotationSpeed);

        //todo programa 3D rota los objeto en 4 direciones, esos son quaternion. eje extra invisible que rota junto con el objeto para evitar la alineacion de los ejes.
        //samos un quaternion.rotatetowars para tomar la informacion y rotarno, asi evitando un gimbacklook.

        _lastPosition = transform.position;
    }
}
