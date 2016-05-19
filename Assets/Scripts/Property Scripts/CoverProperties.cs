using UnityEngine;
using System.Collections;

public class CoverProperties : PickupProperties {

	// Use this for initialization
	void Start () {
		attackSet (0.5f);
		defenseSet (10.0f);
		weightSet (8.0f);
		duraSet (15.0f);
		AddProperty ("Blocks pierce");
		AddProperty ("Counter dmg");
		AddProperty ("Half dura dmg");
	}
}
