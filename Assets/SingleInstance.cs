using UnityEngine;
using System.Collections;

public class SingleInstance : MonoBehaviour {
    //private static SingleInstance instance;
    public GameObject[] objects = null;

    void Awake() {
       
        DontDestroyOnLoad(this.gameObject);
        //if(GameObject.Find("") == 1)
        print("SOMETHING ELSE");
       
    }
    // Use this for initialization
   
	
	// Update is called once per frame
	void Update () {
	
	}
}
