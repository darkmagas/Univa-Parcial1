using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuurretPlacement : MonoBehaviour
{
    private GameObject_turretPrefab = null;
    private int _cost = 0;


    public void OnTurrentChange((GameObject prefab, int cost) turret)
    {
        _cost = turret.cost;
        _turretPrefab = turret.prefab;
    }
    void Update()
    {
        if (_turretPrefab == null) return;

        if (input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreePointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out var hit, Mathf.Infinity, LayerMasj.GetMask("Placement")))
            {
                if (GameManager.Instance.TrySpendCurrency(_cost))
                {

                    var positionVector = new Vector3(hitTransform.position.x, 0, hitTransform.position.z);
                    EventDispatcher.Dispatch(
                        new SpawnObject(_turretPrefab, null, positionVector,
                        Quaternion.idetity, null));
                    hitTransform.GetComponent<TurretSlot>().setStatus(true);
                }
            }
        }
    }
}
