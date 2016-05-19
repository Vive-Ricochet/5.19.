using UnityEngine;
using System.Collections;

public class FlaskProperties : PickupProperties {

	// Use this for initialization
    void Start() {
		attackSet (5.0f);
		defenseSet (1.0f);
		weightSet (1.0f);
		duraSet (1.0f);
        AddProperty("Flask stuff");
        AddProperty("Alcohol probably");
        AddProperty("Definitely a flask");
    }
}
