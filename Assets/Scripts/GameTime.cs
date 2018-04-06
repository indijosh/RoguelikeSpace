using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour {
	UpdateUI _UpdateUI;

	public string GameTimeString;
    public int month;
    public int day;
    public int year;
    public int hour;
    public int minute;
    public int second;

	// Use this for initialization
	void Start () {
		GameObject UIEmpty = GameObject.Find("UI_Empty");
		if (UIEmpty)
		{
			_UpdateUI = UIEmpty.GetComponent<UpdateUI>();
		}

		month = 01;
        day = 01;
        year = 2100;
        hour = 12;
        minute = 00;
        second = 00;

        UpdateGameTimeString();
		_UpdateUI.UpdateGameTimeUI(GameTimeString);
	}

	public string GetGameTime()
    {
        return GameTimeString;
    }

    public void AdvanceTime1Second()
    {
        second += 1;
        RunTimeConversion();
        UpdateGameTimeString();
		_UpdateUI.UpdateGameTimeUI(GameTimeString);
	}

    public void AdvanceTime1Minute()
    {
        minute += 1;
        RunTimeConversion();
        UpdateGameTimeString();
		_UpdateUI.UpdateGameTimeUI(GameTimeString);

	}

	public void AdvanceTime1Hour()
    {
        hour += 1;
        RunTimeConversion();
        UpdateGameTimeString();
		_UpdateUI.UpdateGameTimeUI(GameTimeString);

	}

	public void AdvanceTime1Day()
    {
        day += 1;
        RunTimeConversion();
        UpdateGameTimeString();
		_UpdateUI.UpdateGameTimeUI(GameTimeString);
	}

	public void AdvanceTime1Week()
    {
        day += 7;
        RunTimeConversion();
        UpdateGameTimeString();
		_UpdateUI.UpdateGameTimeUI(GameTimeString);
	}

	public void RunTimeConversion()
    {
        if(second >= 60)
        {
            minute += 1;
            second -= 60;
        }
        if (minute >= 60)
        {
            hour += 1;
            minute -= 60;
        }
        if (hour >= 24)
        {
            day += 1;
            hour -= 24;
        }
        if(day > 30)
        {
            month += 1;
            day -= 30;
        }
        if(month > 12)
        {
            year += 1;
            month -= 12;
        }
    }

    public void UpdateGameTimeString()
    {
        GameTimeString = month + "." + day + "." + year + " " + hour.ToString("D2") + minute.ToString("D2") + "." + second.ToString("D2");
    }
}
