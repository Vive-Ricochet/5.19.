using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int scoreP1;
    public static int scoreP2;
    public static int endScore = 3;
    public static bool continueRound = true;

    private int round;
    public CollisionManager p1Hit;
    public CollisionManager p2Hit;

    public bool goingToVictory = false;
    public bool goingToRestart = false;

    // texture buttons for menu
    public Texture2D image_redUI;
    public Texture2D image_blueUI;

    public Texture2D[] image_redScore = new Texture2D[10];
    public Texture2D[] image_blueScore = new Texture2D[10];

    SplatterSceneTransition splatterEffect;

    void Start() {

        // get scene changing splatter effect
        splatterEffect = GameObject.Find("TransitionManager").GetComponent<SplatterSceneTransition>();

        image_redUI = Resources.Load("Menu/redUI", typeof(Texture2D)) as Texture2D;
        image_blueUI = Resources.Load("Menu/blueUI", typeof(Texture2D)) as Texture2D;

        int i = 0;
        foreach (object o in Resources.LoadAll("Text/Red", typeof(Texture2D))) {
            image_redScore[i] = o as Texture2D;
            i++;
        }

        i = 0;
        foreach (object o in Resources.LoadAll("Text/Blue", typeof(Texture2D))) {
            image_blueScore[i] = o as Texture2D;
            i++;
        }
    }
    
    // Update is called once per frame
    void Update() {

        if (splatterEffect.going_out == false && goingToVictory == true)
            SceneManager.LoadScene(3);

        if (splatterEffect.going_out == false && goingToRestart == true)
            SceneManager.LoadScene(2);


        if (p1Hit != null && p2Hit != null && goingToVictory == false && goingToRestart == false) {

            if (p1Hit.hit) { 
                scoreP2 += 1; print("Player 2 Scored:" + scoreP2);
                splatterEffect.startGoingOut();

                if (scoreP2 < endScore) {
                    goingToRestart = true;
                } else {
                    Destroy(GameObject.Find("BGMplayer"));
                    goingToVictory = true;
                }
                    
            }

            if (p2Hit.hit) {
                scoreP1 += 1; print("Player 1 Scored:" + scoreP1);
                splatterEffect.startGoingOut();

                if (scoreP1 < endScore) {
                    goingToRestart = true;
                } else {
                    Destroy(GameObject.Find("BGMplayer"));
                    goingToVictory = true;
                }
            }
        }
    }

    void OnGUI() {

        if (p1Hit != null && p2Hit != null) {
            GUI.DrawTexture(new Rect(Screen.width - 130, 0, 100, 100), image_redUI);
            GUI.DrawTexture(new Rect(10, Screen.height - 100, 100, 100), image_blueUI);

            GUI.DrawTexture(new Rect(Screen.width - 60, 20, 30, 50), image_redScore[scoreP1]);
            GUI.DrawTexture(new Rect(90, Screen.height - 80, 30, 50), image_blueScore[scoreP2]);
        }
    }

    public int getScoreP1() {
        return scoreP1;
    }

    public int getScoreP2() {
        return scoreP2;
    }
}
