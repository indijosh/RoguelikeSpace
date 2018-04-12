using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : ScriptableObject
{
    public string SSname;
    public int SSplanets;
    public List<string> ConnectedSystems;
    public int ConnectedSystemTotal;

    public string starType;
    public string starName;
    public string starColor;


    public List<ListPlanets> PlanetList;

    public SolarSystem(string newName)
    {
        SSname = newName + " System";
        SSplanets = Random.Range(0, 10);

        starType = GetStarType();
        starColor = GetStarColor(starType);
        starName = newName + " 0";
        ConnectedSystems = new List<string>();
        ConnectedSystemTotal = Random.Range(1, 5);

        PlanetList = new List<ListPlanets>();

        for (int i = 0; i < SSplanets; i++)
        {
            string planetType = GeneratePlanet();
            // hold off on giving it a name until we sort it later
            string planetName = "";
            float distance = Random.Range(1, 1000000);
            PlanetList.Add(new ListPlanets(planetType, planetName, distance, newName, i));
        }

        PlanetList = PlanetList.OrderBy(distance => distance.distanceFromStar).ToList();
        for (int i = 0; i < SSplanets; i++)
        {
            string planetName = newName + " " + (i + 1);
            PlanetList[i].name = planetName;
        }
    }
    private string GeneratePlanet()
    {
        string planetType;
        int planetTypeRange = Random.Range(1, 100);
        if (planetTypeRange >= 1 && planetTypeRange <= 20)
        {
            planetType = "Desert";
        }
        else if (planetTypeRange > 20 && planetTypeRange <= 40)
        {
            planetType = "Gas Giant";
        }
        else if (planetTypeRange > 40 && planetTypeRange <= 42)
        {
            planetType = "Dwarf";
        }
        else if (planetTypeRange > 42 && planetTypeRange <= 50)
        {
            planetType = "Magma";
        }
        else if (planetTypeRange > 50 && planetTypeRange <= 60)
        {
            planetType = "Ocean";
        }
        else if (planetTypeRange > 60 && planetTypeRange <= 62)
        {
            planetType = "Earth-like";
        }
        else if (planetTypeRange > 62 && planetTypeRange <= 82)
        {
            planetType = "Ice";
        }
        else
        {
            planetType = "Toxic";
        }
        return planetType;
    }

    private string GetStarColor(string starType)
    {
        string starColor;

        if (starType == "Class M")
        {
            starColor = "Orange Red";
        }
        else if (starType == "Class K")
        {
            starColor = "Light Orange";
        }
        else if (starType == "Class G")
        {
            starColor = "Yellow";
        }
        else if (starType == "Class F")
        {
            starColor = "Yellow White";
        }
        else if (starType == "Class A")
        {
            starColor = "White";
        }
        else if (starType == "Class B")
        {
            starColor = "Blue White";
        }
        else
        {
            starColor = "Blue";
        }
        return starColor;
    }

    private string GetStarType()
    {
        int typeNumber = Random.Range(1, 9926);
        string typeString;

        if (typeNumber >= 1 && typeNumber <= 7600)
        {
            typeString = "Class M";
        }
        else if (typeNumber > 7600 && typeNumber <= 8800)
        {
            typeString = "Class K";
        }
        else if (typeNumber > 8800 && typeNumber <= 9550)
        {
            typeString = "Class G";
        }
        else if (typeNumber > 9550 && typeNumber <= 9853)
        {
            typeString = "Class F";
        }
        else if (typeNumber > 9853 && typeNumber <= 9913)
        {
            typeString = "Class A";
        }
        else if (typeNumber > 9913 && typeNumber <= 9925)
        {
            typeString = "Class B";
        }
        else
            typeString = "Class O";

        return typeString;
    }
}
