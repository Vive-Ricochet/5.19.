using UnityEngine;
using System.Collections;

public class PoleProperties : PickupProperties {

	// Use this for initialization
	void Start () {
		attackSet (15.0f);
		defenseSet (15.0f);
		weightSet (30.0f);
		duraSet (25.0f);
		AddProperty ("Power item");
		AddProperty ("Extra KB");
		AddProperty ("Insta break");
		AddProperty ("Pierce dmg");
	}
}
