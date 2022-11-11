using Magas.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretPlacement : MonoBehaviour
{
    private GameObject turretPrefab;
   private int _cost=0;


    public void OnTurretChange((GameObject prefab, int cost) turret)


    {

        _cost = turret.cost;

    
    
    
    
    
    }
    
    
    
    void update()
    
    
    
    {
        if (Input.GetMouseButton(0))
        { 
               var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, maxDistance: Mathf.Infinity, LayerMask.GetMask( layerNames: "Placement")))
            {
                Currency(amount;10)

                var hitTransform = hit.collider.transform;
                if (GameManager.Instance.TrySpendCurrency(amount; 2))
                    {

                    var positionVector = new Vector3(hitTransform.position position.z);
                    EventDispatcher.Dispatch(

                   
                    
                  signal: new SpawnObject(turretPrefab, Parent: null, hitTransform.positionVector, Quaternion.identity, OnSpawned: null));
                }
            
            }
        
        }
    }
}
