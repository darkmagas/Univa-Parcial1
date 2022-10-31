using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class TurretPlacement : MonoBehaviour
{
    private GameObject _turretPrefab;
    private int _cost = 0;

    public void OnTurretChange((GameObject prefab, int cost) turret)
    {
        _cost = turret.cost;
        _turretPrefab = turret.prefab;
    }

    void Update()
    {
        if (_turretPrefab == null) return;

        //if(Input.GetTouch(0).phase == TouchPhase.Began){} <-- pa toch
        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.Instance.TrySpendCurrency(_cost))
            {

                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit, Mathf.Infinity, LayerMask.GetMask("Placement")))
                {
                    var hitTransform = hit.collider.transform;
                    if (!hitTransform.GetComponent<TurretSlot>().IsOccupied)
                    {
                        if (GameManager.Instance.TrySpendCurrency(amount : 10))
                        { 

                        var positionVector = new Vector3(hitTransform.position.x, y: 0, hitTransform.position.z);
                        EventDispatcher.Dispatch(new SpawnObject(_turretPrefab, null, positionVector, Quaternion.identity, null));
                            hitTransform.GetComponent<TurretSlot>().SetStatus(true);

                        }
                    }
                }

            }
           
        }
    }

}
