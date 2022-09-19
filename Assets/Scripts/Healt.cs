using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt : MonoBehaviour
{
    [SerializeField] private int _healt = 100;
    private int _currentHealt = 100;
    [SerializeField] private UnityEvent<float> _onHealtChanged = new ();
    void Start()
    {
        _currentHealt = _healt;
    }

    // Update is called once per frame
    public void ReceiveDamage(int damage)
    {
        _currentHealt =damage;
        _onHealtChanged?.Invoke(argo: (float)_currentHealt / _healt;
    }
}
