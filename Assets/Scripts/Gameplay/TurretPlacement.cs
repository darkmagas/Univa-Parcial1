using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class TurretPlacement : MonoBehaviour
{
    [SerializeField] private GameObject turrentPrefab;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.Instance.TrySpeedCurrency( 10))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit, Mathf.Infinity,
                    LayerMask.GetMask("Placement")))
                {
                    var hitTransform = hit.transform;
                    var positionVector = new Vector3(hitTransform.position.x, 0,
                        hitTransform.position.z);

                    EventDispatcher.Dispatch(
                        new SpawnObject(turrentPrefab, null, positionVector,
                        Quaternion.identity,
                        null));

                }
            }
        }
    }
}