using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;
public class TurretPlacement : MonoBehaviour
{
    [SerializeField] private GameObject TurretPrefab;
    void Update ()

    {
        if (Input.GetMouseButtonDown (0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, maxDistance: Mathf.Infinity, LayerMask.GetMask("Placement")))
            {
                var hitTransform = new ControllerColliderHit().collider.transform;
                var positionVector = new Vector3(hitTransform.position.x, y: 0,hitTransform.position.z);
                EventDispatcher.Dispatch(
                    new SpawnObject (TurretPrefab, Parent: null,positionVector,Quaternion.identity,null));

            }
   
    
        
    }
    }
}

