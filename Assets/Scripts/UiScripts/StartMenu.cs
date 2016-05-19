using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    public Button StartText;
    public Button ExitText;

    // Use this for initialization
    void Start()
    {
        StartText = StartText.GetComponent<Button>();
        ExitText = ExitText.GetComponent<Button>();
    }

    public void StartMatch()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
