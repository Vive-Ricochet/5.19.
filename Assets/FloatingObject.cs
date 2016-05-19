using UnityEngine;
using System.Collections;

public class FloatingObject : MonoBehaviour {

    public float speed = 1;
    public float wavelength = 1;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {
        transform.position += new Vector3(0f, Mathf.Sin(Time.time * speed / 2f) * 0.0025f * wavelength, 0);
    }
}
