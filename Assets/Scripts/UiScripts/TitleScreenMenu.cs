using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScreenMenu : MonoBehaviour {

    // public fields
    public bool isPaused = false;

    // private fields
    private InputManager input;
    private int menuSize = 0;
    [SerializeField] private int menuState = 0;

    // texture buttons for menu
    public Texture2D image_title;
    public Texture2D image_pressstart;

    public bool goingOut = false;

    SplatterSceneTransition splatterEffect;

    void Start() {
        // instantiate input manager
        input = GameObject.Find("InputManager").GetComponent<InputManager>();

        // get scene changing splatter effect
        splatterEffect = GameObject.Find("TransitionManager").GetComponent<SplatterSceneTransition>();


        // Pre-load textures and assign to buttons
        image_title = Resources.Load("Menu/ViveRicochetTitle", typeof(Texture2D)) as Texture2D;
        image_pressstart = Resources.Load("Menu/PressStart", typeof(Texture2D)) as Texture2D;

    }

    // Update is called once per frame
    void Update() {

        if (input.buttonDown(1, "Start") || input.buttonDown(2, "Start") ||
            input.buttonDown(3, "Start") || input.buttonDown(4, "Start") || 
            input.buttonDown(1, "A") || input.buttonDown(2, "A") ||
            input.buttonDown(3, "A") || input.buttonDown(4, "A")) {

                splatterEffect.startGoingOut();
                goingOut = true;
        }

        if (splatterEffect.going_out == false && goingOut == true)
            SceneManager.LoadScene(1);
    }


    public void OnGUI() {

        GUI.DrawTexture(new Rect(Screen.width / 2 - Screen.width * 3 / 8, Screen.height / 2 - Screen.height * 3 / 8, Screen.width * 3 / 4, Screen.height * 1 / 4), image_title);
        GUI.DrawTexture(new Rect(Screen.width / 2 - 100, Screen.height - 250, 240, 30), image_pressstart);
    }
}
