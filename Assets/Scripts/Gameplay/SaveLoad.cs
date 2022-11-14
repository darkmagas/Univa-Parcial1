using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveLoad : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private int counter = 0;

    private void Start()
    {
        var a = SaveData.load<BasicSave>("data");

        counter = PlayerPrefs.GetInt("TimesOpened", 0);
        counter++;
        text.SetText($"Times Open :: {counter}");
        PlayerPrefs.SetInt("TimeOpened", counter);
        PlayerPrefs.SetFloat("PlayerX", transform.X);

    }
}
