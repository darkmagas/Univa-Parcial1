using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class TurretPlacement : MonoBehaviour
{

    [SerializeField] private GameObject turretPrefab;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out var hit, Mathf.Infinity,LayerMask.GetMask("Placement")))
            {
                var hitTrasform = hit.collider.transform;
                var positionVector = new Vector3(hitTrasform.position.x, 0, hitTrasform.position.z);
                EventDispatcher.Dispatch(
                    new SpawnObject(turretPrefab, null, positionVector, Quaternion.identity, null));
            }
        }
    }
}
