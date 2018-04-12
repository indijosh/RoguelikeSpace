using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ListPlanets {
    public string type;
    public string name;
    public float distanceFromStar;
    public int numOfSatellites;
    public List<ListSatellite> SatelliteList;

    public ListPlanets(string planetType, string planetName, float distance, string SSname, int planetNumber)
    {
        type = planetType;
        name = planetName;
        distanceFromStar = distance;

        SatelliteList = new List<ListSatellite>();

        if(type == "Gas Giant")
        {
            numOfSatellites = Random.Range(0, 10);
        }
        else
        {
            numOfSatellites = Random.Range(0, 3);
        }

        for (int i = 0; i < numOfSatellites; i++)
        {
            string satelliteType = GenerateSatelliteType(planetType);
            // hold off on giving it a name for now. We'll asign one after we sort it by distance
            string satelliteName = "";
            float distanceFromPlanet = Random.Range(1, 1000);
            SatelliteList.Add(new ListSatellite(satelliteType, satelliteName, distanceFromPlanet));
        }

        SatelliteList = SatelliteList.OrderBy(dist => dist.distanceFromPlanet).ToList();

        for (int i = 0; i < numOfSatellites; i++)
        {
            // SSName#.#
            string satelliteName = SSname + " " + (planetNumber + 1) + "." + (i + 1);
        }
    }

    string GenerateSatelliteType(string planetType)
    {
        int SatelliteTypeRandom = Random.Range(0, 100);
        string satelliteType = "Rock";

        if(SatelliteTypeRandom > 95 && SatelliteTypeRandom <= 98)
        {
            satelliteType = "Ocean";
        }
        else if (SatelliteTypeRandom > 98 && SatelliteTypeRandom < 101 && planetType == "Gas Giant")
        {
            satelliteType = "Terran";
        }

        return satelliteType;
    }
}
