using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1)
        {
            Destroy(gameObject);
        } else {

        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
