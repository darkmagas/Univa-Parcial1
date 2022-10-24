using Magas.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretPlacement : MonoBehaviour
{
    [SerializeField] private GameObject turretPrefab;
   

    void Update()
    {
        if (Input.GetMouseButton(0))
        { 
               var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, maxDistance: Mathf.Infinity, LayerMask.GetMask( layerNames: "Placement")))
            { 
            
                   var hitTransform = hit.collider.transform;
                EventDispatcher.Dispatch(signal: new SpawnObject(turretPrefab, Parent: null, hitTransform.positionVector, Quaternion.identity, OnSpawned:null));
            
            
            }
        
        }
    }
}
