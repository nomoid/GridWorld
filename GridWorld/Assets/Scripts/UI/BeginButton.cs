﻿using UnityEngine;
using System.Collections;

public class BeginButton : MonoBehaviour{

	// Use this for initialization
	void Start(){
	
	}
	
	// Update is called once per frame
	void Update(){
	
	}

	public void StartGame(){
		Application.LoadLevel("GameWorld");
	}
}
