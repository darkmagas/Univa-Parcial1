using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class Turret_Placement : MonoBehaviour
{
    [SerializeField] private GameObject turretPrefab;
    // Start is called before the first frame update
 
    void Update()
    {
       if(Input.GetMouseButtonDown(0)) //para el touch if(Input.GetTouch(0).phase == Touchphase.Began)
        {
            if(GameManager.Instance.TrySpendCurrency(10))
            { 
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit, Mathf.Infinity, LayerMask.GetMask("Placement")))
                {
                    var hitTransform = hit.collider.transform;
                    var positionVector = new Vector3(hitTransform.position.x, 0, hitTransform.position.z);
                    EventDispatcher.Dispatch(new SpawnObject(turretPrefab, null, hitTransform.position, Quaternion.identity, null));
                }

            }
        }
    }
}
