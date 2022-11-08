using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class TurretPlacement: MonoBehaviour
{
     private GameObject _turretPrefab = null;
    private int _coast = 0;


public void OnTurrentChange ((GameObject prefab, int coast) turret)
    {
        _coast = turret.coast;
        _turretPrefab = turret.prefab;
    }


    void Update()
    {
        if (_turretPrefab == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked");
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit, Mathf.Infinity, LayerMask.GetMask("Placement")))
                {
                    var hitTransform = hit.collider.transform;
                    if (!hitTransform.GetComponent<TurretSlot>().IsOccupied)
                    {
                        if (GameManager.Instance.TrySpendCurrency(_coast))
                        {
                            var positionVector = new Vector3(hitTransform.position.x, 0, hitTransform.position.z);
                            EventDispatcher.Dispatch(
                                new SpawnObject(_turretPrefab, null, positionVector, Quaternion.identity, null));
                            hitTransform.GetComponent<TurretSlot>().SetStatus(true);
                        }
                    }
                    
                }
            
        }
    }
}
