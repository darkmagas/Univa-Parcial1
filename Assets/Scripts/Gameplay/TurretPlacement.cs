using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class TurretPlacement : MonoBehaviour
{
    [SerializeField] private GameObject turretPrefab;

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // si se quiere cambiar a touch es  if(Input.GetTouch(0).phase == TouchPhase.Began)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, LayerMask.GetMask("Placement")))
            {   
                var hitTransform = hit.collider.transform;
                if (!hitTransform.GetComponent<TurretSlot>().IsOcupied)
                {


                    if (GameManager.Instance.TrySpendCurrency(10))
                    {


                        var positionVector = new Vector3(hitTransform.position.x, 0, hitTransform.position.z);
                        EventDispatcher.Dispatch(new SpawnObject(turretPrefab, null, positionVector, Quaternion.identity, null));
                        hitTransform.GetComponent<TurretSlot>().SetStatus(true);
                    }
                }
            }
        }
    }

}
