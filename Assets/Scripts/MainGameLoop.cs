using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameLoop : MonoBehaviour {
    GameTime _gameTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _gameTime.GetGameTime();
	}
}
