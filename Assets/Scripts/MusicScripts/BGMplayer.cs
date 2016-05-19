using UnityEngine;
using System.Collections;

public class BGMplayer : MonoBehaviour {

    public static BGMplayer i;

    void Awake() {

        if (!i) {
            i = this;
            DontDestroyOnLoad(gameObject);
            } else
                Destroy(gameObject);

        GetComponent<AudioSource>().Play();
    }

    public void killSound() {
        Destroy(this);
    }
}
