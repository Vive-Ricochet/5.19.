using UnityEngine;
using System.Collections;

public class BGMController : MonoBehaviour {

    GameObject BGMplayer;
    GameObject[] musicObject;

    void Awake()
    {
        DontDestroyOnLoad(BGMplayer);
        //BGMplayer = null;

    }

	// Use this for initialization
	void Start () {

            BGMplayer = new GameObject("BGMplayer");
            BGMplayer.AddComponent<AudioSource>();
            BGMplayer.GetComponent<AudioSource>().clip = GetComponent<AudioSource>().clip;
            BGMplayer.GetComponent<AudioSource>().playOnAwake = false;
            BGMplayer.GetComponent<AudioSource>().Play();
            BGMplayer.GetComponent<AudioSource>().loop = true;

            BGMplayer.tag = "GameMusic";

        musicObject = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObject.Length == 1)
        {
            BGMplayer.GetComponent<AudioSource>().Play();
        } else {
            for (int i = 1; i < musicObject.Length; i++)
            {
                Destroy(musicObject[i]);
            }

        }


    }

    // Update is called once per frame
    void Update () {
	
	}
}
