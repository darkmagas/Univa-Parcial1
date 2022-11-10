using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ScoreManager : MonoBehaviour
{
   private int _score = 0;
   [SerializeField]private UnityEvent<int> _OnScoreChange = new();

   private void Start()
   {
      GameManager.Instance.AddScoreManager(this);
   }

   public void ModifyScore(int value)
   {
      _score += value;
      _OnScoreChange?.Invoke(_score);
   }

}
