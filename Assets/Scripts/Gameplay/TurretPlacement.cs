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
            if(GameManager.Instance.TrySpendCurrency())
            { 
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out var hit, Mathf.Infinity, layerMask.GetMask(“Placement”)))
    {
                var hitTransform = hit.collider.transform;
                var positionVector = new Vector3(hitTransform.position.x, 0, hitTransform.position, z);
                EventDispatcher.Dispatch(new SpawnObject(turretPrefab, null, hitTransform.position, Quaternion.identity, null)));
            }
            }
        }
    }


  
}
