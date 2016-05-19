using UnityEngine;
using System.Collections;

public class SphereProperties : PickupProperties {

	// Use this for initialization
	void Start () {
		attackSet (2.0f);
		defenseSet (4.0f);
		weightSet (8.0f);
		duraSet (16.0f);
        AddProperty("Spherical stuff");
        AddProperty("Round stuff");
        AddProperty("Bubbly stuff");
		AddProperty ("Rubbery");
		AddProperty ("Bouncy");

	}
	
}