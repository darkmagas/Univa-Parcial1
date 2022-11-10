using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private int _Score = 0;
    [SerializeField] private UnityEvent<int> _OnScoreChange = new ();

    private void Start()
    {
        GameManager.Instance.AddScoreManager(this);
    }


    public void ModifyScore(int Value)
    {
        _Score += Value;
        _OnScoreChange?.Invoke(_Score);
    }

}
