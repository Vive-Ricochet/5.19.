using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour {

    Text textP1;
    Text textP2;
    


    void Start()
    {

        textP1 = GameObject.Find("p1Score").GetComponent<Text>();
        textP2 = GameObject.Find("p2Score").GetComponent<Text>();
        textP1.text = "Score " + ScoreManager.scoreP1;
        textP2.text = "Score " + ScoreManager.scoreP2;
         
    }

    



}
