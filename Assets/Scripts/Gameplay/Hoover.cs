using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoover : MonoBehaviour
{
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

}
