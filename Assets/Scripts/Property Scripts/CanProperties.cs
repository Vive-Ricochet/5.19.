using UnityEngine;
using System.Collections;

public class CanProperties : PickupProperties {

	// Use this for initialization
	void Start () {
		attackSet (3.0f);
		defenseSet (6.0f);
		weightSet (5.0f);
		duraSet (4.0f);
		soundSet (Resources.Load ("Sounds/metal_small") as AudioClip);
		AddProperty ("Dents");
		AddProperty ("Proj on break");
	}
}
