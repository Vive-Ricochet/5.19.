using UnityEngine;
using System.Collections;

public class SpinSpawnAnimation : MonoBehaviour {

    public bool finished = false;
    public float x_scale = 0.4f;
    public float z_scale = 0.8f;
    private int timer = 80;
    public Texture2D image_whiteScreen;

	// Use this for initialization
	void Start () {

        image_whiteScreen = Resources.Load("Menu/white_screen", typeof(Texture2D)) as Texture2D;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(!finished && timer >= 0) {
            transform.Rotate(new Vector3(0f, 20f, 0f));
            transform.localScale= new Vector3(transform.localScale.x * 0.95f, 1f, transform.localScale.z * 0.95f);
            timer--;
        }else {
            transform.localEulerAngles = new Vector3(90, 180, 0);
            transform.localScale = new Vector3(x_scale, 1f, z_scale);
            finished = true;
            GameObject.Find("final score text").GetComponent<MeshRenderer>().enabled = true;
            GameObject.Find("red score").GetComponent<MeshRenderer>().enabled = true;
            GameObject.Find("blue score").GetComponent<MeshRenderer>().enabled = true;
            GameObject.Find("hyphen").GetComponent<MeshRenderer>().enabled = true;
            GameObject.Find("Results Screen Menu Manager").GetComponent<ResultsScreenMenuManager>().enabled = true;
        }  
	}

    void OnGUI() {
        if(!finished && timer <= 1)
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), image_whiteScreen);
    }
}
