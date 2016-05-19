using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawning : MonoBehaviour {
    bool drop;
	int timer = 600;
    [SerializeField] public List<GameObject> GameObjs = new List<GameObject>();


	// Use this for initialization
	void Start () {
        drop = true;
	}

    //Vector3 position = new Vector3( transform.position.x + Random.Range(-10.0F, 10.0F), 0, Transform.position.z + Random.Range(-10.0F, 10.0F));

    // Update is called once per frame
    void Update () {
		if (drop == true && timer == 0) {
			foreach (GameObject Thing in GameObjs) {
				Vector3 randomDir = new Vector3 (Random.Range (-20.0f, 20.0f), 0, Random.Range (-20.0f, 20.0f));
				Instantiate (Thing, transform.position + randomDir, transform.rotation);
				timer = 600;
			}
		} else if (timer != 0) {
			timer -= 1;
		}
	}
}
