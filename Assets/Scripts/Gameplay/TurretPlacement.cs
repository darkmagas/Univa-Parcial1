using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class TurretPlacement : MonoBehaviour
{

    [SerializeField] private GameObject turretPrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.Instance.TrySpendCurrency(10))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit, Mathf.Infinity, LayerMask.GetMask("Placement")))
                {

                    var hitTransform = hit.collider.transform;
                    EventDispatcher.Dispatch(new SpawnObject(turretPrefab, null, hitTransform.position, Quaternion.identity, null));
                    var positionVector = new Vector3(hitTransform.position.x, 0, hitTransform.position.z);

                }
            }
        }
    }


}
