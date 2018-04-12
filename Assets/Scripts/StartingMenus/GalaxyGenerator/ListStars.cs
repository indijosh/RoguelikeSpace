using UnityEngine;
using System.Collections;

public class ListStars{
    public string type;
    public string name;
    public string color;

    public ListStars(string starType, string starName, string starColor)
    {
        type = starType;
        name = starName;
        color = starColor;
    }
}