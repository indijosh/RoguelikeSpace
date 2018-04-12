using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartScreen : MonoBehaviour {
	public GameObject GameStartMenuCanvas;
	public GameObject NewGameCanvas;

	void Start()
	{
		if (!GameStartMenuCanvas)
		{
			GameStartMenuCanvas = GameObject.Find("Canvas-GameStartMenu");
		}
		if (!NewGameCanvas)
		{
			NewGameCanvas = GameObject.Find("Canvas-NewGame");
		}
	}

	public void LoadNewGameCanvas()
	{
		GameStartMenuCanvas.SetActive(false);
		NewGameCanvas.SetActive(true);
	}
}
