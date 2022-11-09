using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class TurretPlacement : MonoBehaviour
{
     private GameObject _turretPrefab = null;
     private int _cost = 0;  
    // Start is called before the first frame update
 
    public void OnTurretChange((GameObject prefab, int cost) turret)
    {
        _cost = turret.cost;
        _turretPrefab = turret.prefab;
    }

    void Update()
    {
       if (_turretPrefab == null) return;
       if(Input.GetMouseButtonDown(0)) //para el touch if(Input.GetTouch(0).phase == Touchphase.Began)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out var hit, Mathf.Infinity, LayerMask.GetMask("Placement")))
            {
                var hitTransform = hit.collider.transform; 
                if (!hitTransform.GetComponent<TurretSlot>().IsOcupied)
                {
                    var positionVector = new Vector3(hitTransform.position.x,0, hitTransform.position.z);
                    EventDispatcher.Dispatch(new SpawnObject(_turretPrefab,null, positionVector,Quaternion.identity,null));
                    hitTransform.GetComponent<TurretSlot>().SetStatus(true);
                }
                

            }
        }
    }
}
