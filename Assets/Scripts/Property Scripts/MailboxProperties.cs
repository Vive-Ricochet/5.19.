using UnityEngine;
using System.Collections;

public class MailboxProperties : PickupProperties {

	// Use this for initialization
	void Start () {
		attackSet (3.0f);
		defenseSet (1.0f);
		weightSet (2.0f);
		duraSet (1.5f);
		AddProperty ("Proj on hit");
	}
}
