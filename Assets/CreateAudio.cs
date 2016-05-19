using UnityEngine;
using System.Collections;

public class CreateAudio : MonoBehaviour {
    static GameObject bgAudio;
    void Awake()
    {
        if (bgAudio)
        { // if bgAudio already references some object...
            Destroy(gameObject); // suicide
        }
        else { // if bgAudio is null, this is the first TronBG object:
            bgAudio = gameObject; // assign this one
            AudioSource SoundSource = gameObject.AddComponent<AudioSource>();
            SoundSource.playOnAwake = true;
            //SoundSource.rolloffMode = 
           // RolloffMode.Logarithmic;
            SoundSource.loop = true;
        }
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
