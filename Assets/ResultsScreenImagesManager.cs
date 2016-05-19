using UnityEngine;
using System.Collections;

public class ResultsScreenImagesManager : MonoBehaviour {

    public GameObject victor;
    public GameObject loser;

    GameObject redScore;
    GameObject blueScore;

    public int scoreP2;
    public int scoreP1;

    // Use this for initialization
    void Start() {

        victor = transform.Find("victor").gameObject;
        loser = transform.Find("loser").gameObject;
        redScore = transform.Find("red score").gameObject;
        blueScore = transform.Find("blue score").gameObject;

        scoreP2 = GetComponent<ScoreManager>().getScoreP2();
        scoreP1 = GetComponent<ScoreManager>().getScoreP1();

        if (scoreP1 > scoreP2) {
            victor.GetComponent<Renderer>().material.mainTexture = Resources.Load("Menu/image_redvictory", typeof(Texture2D)) as Texture2D;
            loser.GetComponent<Renderer>().material.mainTexture = Resources.Load("Menu/image_bluedefeat", typeof(Texture2D)) as Texture2D;
        }

        if (scoreP2 > scoreP1) {
            loser.GetComponent<Renderer>().material.mainTexture = Resources.Load("Menu/image_reddefeat", typeof(Texture2D)) as Texture2D;
            victor.GetComponent<Renderer>().material.mainTexture = Resources.Load("Menu/image_bluevictory", typeof(Texture2D)) as Texture2D;
        }

        redScore.GetComponent<Renderer>().material.mainTexture = Resources.Load("Text/Red/" + scoreP1, typeof(Texture2D)) as Texture2D;
        blueScore.GetComponent<Renderer>().material.mainTexture = Resources.Load("Text/Blue/" + scoreP2, typeof(Texture2D)) as Texture2D;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
