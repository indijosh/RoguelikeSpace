using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceGeneration : MonoBehaviour {
	string RaceSpecies;
	string RaceHomeWorld;
	string RaceDescription;

	public void GenerateRace(int NumberOfRaces)
	{
		for(int i = 0; i < NumberOfRaces; i++)
		{
			GetRaceSpecies();
		}
	}

	void GetRaceSpecies()
	{

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
