using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListSatellite
{
    public string type;
    public string name;
    public float distanceFromPlanet;

    public ListSatellite(string satelliteType, string satelliteName, float distance)
    {
        type = satelliteType;
        name = satelliteName;
        distanceFromPlanet = distance;
    }
}
