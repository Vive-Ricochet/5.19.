using UnityEngine;
using System.Collections;

public class ConeProperties : PickupProperties {

	// Use this for initialization
	void Start () {
		attackSet (5.0f);
		defenseSet (2.5f);
		weightSet (2.0f);
		duraSet (2.0f);
		AddProperty ("Kinda pointy");
		AddProperty ("Plastic");
		AddProperty ("Pierces soft");
	}
}
