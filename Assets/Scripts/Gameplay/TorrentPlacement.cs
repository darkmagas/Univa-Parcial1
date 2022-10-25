using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class TorrentPlacement : MonoBehaviour
{
    [SerializeField] private GameObject turrentPrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if(GameManager.Instance.TrySpendCurrency(10)) //*para asegurarnos que tenga min 10 monedas para poner una torreta
            { 
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out var hit, Mathf.Infinity, LayerMask.GetMask("Placement")))
            {
                var hitTransform = hit.collider.transform;
                var positionVector = new Vector3(hitTransform.position.x, 0, hitTransform.position.z);
                EventDispatcher.Dispatch(
                    new SpawnObject(turrentPrefab, null, positionVector, Quaternion.identity, null));
            }
            }
        }
    }
}
