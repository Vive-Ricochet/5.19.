using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultTo : MonoBehaviour {
    public Button restartGame;
    public Button restartMatch;
    // Use this for initialization
    void Start () {
        restartGame = restartGame.GetComponent<Button>();
        restartMatch = restartMatch.GetComponent<Button>();
    }

    public void RestartMatch()
    {
        ScoreManager.scoreP1 = 0;
        ScoreManager.scoreP2 = 0;
        SceneManager.LoadScene(1);
    }

    public void RestartGame()
    {
        ScoreManager.scoreP1 = 0;
        ScoreManager.scoreP2 = 0;
        SceneManager.LoadScene(0);
    }
}
