﻿using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (TuneManager.finished) {
            SteamVR_LoadLevel.Begin("Scene/bamboo");
        }
	}
}
