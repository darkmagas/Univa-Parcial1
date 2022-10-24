using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turrentplacement : MonoBehaviour
{
    [SerializeField] priate GameObject turrentPrefab;
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physic.Raycast(ray,out var hit, Mathf.Infinity),
            LayerMask.GetMask( "Placement")))

        {
                var
            }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
