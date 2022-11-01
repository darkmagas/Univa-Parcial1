using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Magas.Utilities;

public class TorrentPlacement : MonoBehaviour
{
    private GameObject _turrentPrefab = null; //*le quitamos el[SerializeFied, lo hicimos null y agregamos el int]
    private int _cost = 0;

    public void OnTurretChange((GameObject prefab, int cost) turret) //ayuda a guardar en un objeto con dos variables, dos tipos de informacion
    {
        _cost = turret.cost;
        _turrentPrefab = turret.prefab;
    }

    void Update()
    {
        if (_turrentPrefab == null) return;
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, LayerMask.GetMask("Placement")))
            {
                var hitTransform = hit.collider.transform;
                if (!hitTransform.GetComponent<TorretSlot>().IsOccupied)
                {

                    if (GameManager.Instance.TrySpendCurrency(_cost)) //*para asegurarnos que tenga min 10 monedas para poner una torreta
                    {

                        var positionVector = new Vector3(hitTransform.position.x, 0, hitTransform.position.z);
                        EventDispatcher.Dispatch(
                            new SpawnObject(_turrentPrefab, null, positionVector, Quaternion.identity, null));
                        hitTransform.GetComponent<TorretSlot>().SetStatus(true);
                    }
                }
            }
        }
    }
}
