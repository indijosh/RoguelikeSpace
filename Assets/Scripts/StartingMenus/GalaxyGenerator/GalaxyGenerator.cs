using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class GalaxyGenerator : MonoBehaviour
{
    public int numOfStarsInSystem;
    public int numOfBodiesInSystem;

    public int numOfSolarSystems;

    List<SolarSystem> ListSolarSystems;

    private string[] StarNames;

    NewGameScreen NewGameScreen;

    //Blue https://en.wikipedia.org/wiki/Stellar_classification

    private void Start()
    {
        NewGameScreen = GameObject.Find("Canvas-SelectionItems").GetComponent<NewGameScreen>();
    
    }
    public void GenerateGalaxy()
    {
        NewGameScreen.HideSelectionShowProgress();
        NewGameScreen.ProgressText = "Creating Solar Systems...";
        NewGameScreen.UpdateProgressText();
        CreateSolarSystems();
        NewGameScreen.ProgressText = "Creating Solar System Links...";
        NewGameScreen.UpdateProgressText();
        CreateLinksBetweenSystems();
        NewGameScreen.ProgressText = "Printing to Console... \n" + numOfSolarSystems + " Systems Created";
        NewGameScreen.UpdateProgressText();
        PrintDetails();
    }

    public void CreateSolarSystems()
    {
        if(NewGameScreen.GalaxySize == 0)
        {
            numOfSolarSystems = Random.Range(100, 150);
        }
        else if (NewGameScreen.GalaxySize == 1)
        {
            numOfSolarSystems = Random.Range(125, 175);
        }
        else {
            numOfSolarSystems = Random.Range(175, 225);
        }
        // create list for solar systems
        ListSolarSystems = new List<SolarSystem>();

        // pull star names from file
        StarNames = File.ReadAllLines("starnames.txt");

        // shuffle starnames
        for (int t = 0; t < StarNames.Length; t++)
        {
            string tmp = StarNames[t];
            int r = Random.Range(t, StarNames.Length);
            StarNames[t] = StarNames[r];
            StarNames[r] = tmp;
        }
        for (int i = 0; i < numOfSolarSystems; i++)
        {
            ListSolarSystems.Add(new SolarSystem(StarNames[i]));
        }
    }

    private void CreateLinksBetweenSystems()
    {
        // iterate solar systems
        for (int d = 0; d < numOfSolarSystems - 1; d++)
        {
            // if current connected solar system count is less than the desired connection count
            while (ListSolarSystems[d].ConnectedSystems.Count < ListSolarSystems[d].ConnectedSystemTotal)
            {
                // pick a random system
                int connectToSystemNumber = Random.Range(0, numOfSolarSystems - 1);

                // check if a connection already exists between this system and desired system
                if (!ListSolarSystems[d].ConnectedSystems.Contains(ListSolarSystems[connectToSystemNumber].name))
                {
                    // if the other system needs a connection
                    if (ListSolarSystems[connectToSystemNumber].ConnectedSystems.Count < ListSolarSystems[connectToSystemNumber].ConnectedSystemTotal)
                    {
                        ListSolarSystems[d].ConnectedSystems.Add(ListSolarSystems[connectToSystemNumber].SSname);
                        ListSolarSystems[connectToSystemNumber].ConnectedSystems.Add(ListSolarSystems[d].SSname);
                    }
                }
            }
        }
    }

    private void PrintDetails()
    {
        for (int i = 0; i < numOfSolarSystems; i++)
        {
            Debug.Log(ListSolarSystems[i].SSname.ToUpper());
            for (int a = 0; a < ListSolarSystems[i].ConnectedSystems.Count; a++)
            {
                Debug.Log("-" + "CONNECTIONS: " + ListSolarSystems[i].ConnectedSystems[a] + " ");
            }

            Debug.Log("-" + "NAME: " + ListSolarSystems[i].starName + " TYPE: " + ListSolarSystems[i].starType + " COLOR: " + ListSolarSystems[i].starColor);

            for (int j = 0; j < ListSolarSystems[i].SSplanets; j++)
            {
                Debug.Log("--" + "NAME: " + ListSolarSystems[i].PlanetList[j].name + " TYPE: " + ListSolarSystems[i].PlanetList[j].type + " DISTANCE: " + ListSolarSystems[i].PlanetList[j].distanceFromStar + "m km");

                for (int k = 0; k < ListSolarSystems[i].PlanetList[j].numOfSatellites; k++)
                {
                    Debug.Log("---" + "NAME: " + ListSolarSystems[i].PlanetList[j].SatelliteList[k].name + " TYPE: " + ListSolarSystems[i].PlanetList[j].SatelliteList[k].type + " DISTANCE: " + ListSolarSystems[i].PlanetList[j].SatelliteList[k].distanceFromPlanet + "k km");
                }
            }
        }
    }
}
