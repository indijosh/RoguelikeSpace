using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour {
    GameTime _GameTime;
    public Text TextTime;

    

    // Use this for initialization
    void Start () {
        GameObject GameTimeEmpty = GameObject.Find("GameTime_Empty");
        if (GameTimeEmpty)
        {
            _GameTime = GameTimeEmpty.GetComponent<GameTime>();
        }
    }

    public void UpdateGameTimeUI(string GameTimeString)
    {
        TextTime.text = GameTimeString.ToString();
    }
}
