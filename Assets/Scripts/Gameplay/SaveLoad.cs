using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MagasLib.SaveSystem;

public class SaveLoad : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private int counter = 0;
    private BasicSave _save;
    private void Start()
    {
        var a = SaveData.Load<BasicSave>("data");
        if(a==null)
        {
            text.SetText("NO SAVE DATA");
            _save = new BasicSave
            {
                x = transform.position.x,y = transform.position.y,z = transform.position.z,
                level = 1, mapName = "School Parkinglot"
            };
            SaveData.Save(_save, "data");
        }
        else
        {
            _save = a.Value;
            text.SetText($"SaveData::{_save.x}{_save.y}"+$"{ _save.z} LevelCurrencyManager::{ _save.level} Map{ _save.mapName}");
        }
        //counter = PlayerPrefs.GetInt("TimesOpened", 0);
        // counter++;
        //text.SetText($"Times Open::{counter}");
        //PlayerPrefs.SetInt("TimesOpened", counter);
        //PlayerPrefs.SetFloat("PlayerX", transform.x);
    }
}
