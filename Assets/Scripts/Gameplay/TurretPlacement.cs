using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class TurretPlacement : MonoBehaviour
{
    [SerializeField] private GameObject turretPrefab;
    // Start is called before the first frame update
    void Update()
    {
        //if(Input.GetTouch(0).phase == TouchPhase.Began){} <-- pa toch
        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.Instance.TrySpendCurrency(10))
            {

                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit, Mathf.Infinity, LayerMask.GetMask("Placement")))
                {
                    var hitTransform = hit.collider.transform;
                    var positionVector = new Vector3(hitTransform.position.x, y: 0, hitTransform.position.z);
                    EventDispatcher.Dispatch(new SpawnObject(turretPrefab, null, positionVector, Quaternion.identity, null));
                }

            }
           
        }
    }

}
