﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkillButtonManager : MonoBehaviour {

	public int id;
	Image img;
	Text text;
	Skill skill;
	bool canPress;
	string tempText;
	bool init;

	public void Initialize(){
		img = GetComponent<Image> ();
		text = GetComponentInChildren<Text> ();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (skill == null) {
			SetCanPress(false);
			return;
		}
		EntityController control = skill.GetController ();
		if (control.combat.action != 0) {
			SetCanPress(false);
			return;
		}
		if (control.combat.mana < skill.manaCost) {
			SetCanPress(false);
			return;
		}
		SetCanPress (true);
	}

	public void SetCanPress(bool can){
		canPress = can;
		if (img == null) {
			Debug.Log("...");
			return;
		}
		if (!can) {
			img.color = new Color(0.8f, 0.8f, 0.8f);
		} else {
			img.color = new Color(1f, 1f, 1f);
		}
	}

	public void ButtonPressed(){
		if (canPress) {
			skill.GetController ().combat.ActivateSkill (skill);
		}
	}

	public void SetSkill(Skill skill){
		this.skill = skill;
			text.text = "( " + (id + 1) + " )\n" +
				skill.GetName () + "\n" +
					"Mana : " + skill.manaCost;
	}

	public void Reset(){
		text.text = "( " + (id+1) + " )\n\n";
	}
}