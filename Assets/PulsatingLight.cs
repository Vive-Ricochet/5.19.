using UnityEngine;
using System.Collections;

public class PulsatingLight : MonoBehaviour {

    bool growing = true;
    public Light light;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        if(light.intensity > 2.0)
            growing = false;
        if(light.intensity < 1.0)
            growing = true;
        if (growing)
            light.intensity += 0.004f;
        else
            light.intensity -= 0.004f;
	}
}
