using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSlot : MonoBehaviour
{
    private bool _isOccupied = false;

    public bool IsOccupied => _isOccupied;
    public Color _hoverColor;
    private Renderer rend;
    private Color startColor;

    public void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = _hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public void SetStatus(bool status)
    {
        _isOccupied = status;
    }
}
