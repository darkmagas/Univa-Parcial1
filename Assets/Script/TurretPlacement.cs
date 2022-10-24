using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class TurretPlacement : MonoBehaviour
{
    [SerializeField] private GameObject turretPrefab;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out var hit, maxDistance:Mathf.Infinity,LayerMask.GetMask("Placement")))
            {
                var hitTransform = hit.collider.transform;
                EventDispatcher.Dispatch(signal: new SpawnObject(turretPrefab, GetComponentInParent: null, hitTransform.position, Quaternion.identity, OnSpawned: null));
            }
        }
    }
}
