using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {

    // public fields
    public bool isPaused = false;

    // private fields
    private InputManager input;
    private bool canNavigate = false;
    private int menuSize = 2;
    [SerializeField] private int menuState = 0;

    // texture buttons for menu
    public Texture2D shade;
    public Texture2D image_frame;

    public Texture2D[] button_resume = new Texture2D[3];
    public Texture2D[] button_restart = new Texture2D[3];
    public Texture2D[] button_mainmenu = new Texture2D[3];

    private bool currentlypaused = false;
    public bool goingToMainMenu = false;
    public bool goingToRestart = false;
    public float TimeSpeed = 1;

    SplatterSceneTransition splatterEffect;


    void Start() {

        // get scene changing splatter effect
        splatterEffect = GameObject.Find("TransitionManager").GetComponent<SplatterSceneTransition>();

        // instantiate input manager
        input = GameObject.Find("InputManager").GetComponent<InputManager>();

        // Pre-load textures and assign to buttons
        shade = Resources.Load("Menu/black_screen", typeof(Texture2D)) as Texture2D;
        image_frame = Resources.Load("Menu/menu_frame_orange", typeof(Texture2D)) as Texture2D;

        button_resume[0] = Resources.Load("Menu/button_resume00", typeof(Texture2D)) as Texture2D;
        button_resume[1] = Resources.Load("Menu/button_resume01", typeof(Texture2D)) as Texture2D;
        button_restart[0] = Resources.Load("Menu/button_restart00", typeof(Texture2D)) as Texture2D;
        button_restart[1] = Resources.Load("Menu/button_restart01", typeof(Texture2D)) as Texture2D;
        button_mainmenu[0] = Resources.Load("Menu/button_mainmenu00", typeof(Texture2D)) as Texture2D;
        button_mainmenu[1] = Resources.Load("Menu/button_mainmenu01", typeof(Texture2D)) as Texture2D;
    }

    // Update is called once per frame
    void Update() {

        if (isPaused) {
            Time.timeScale = 0f;

            //======= Navigate the menus via left control stick =======//
            if (input.leftStick(1, "Y") < -0.2 || input.leftStick(2, "Y") < -0.2 || input.leftStick(3, "Y") < -0.2 || input.leftStick(4, "Y") < -0.2) {
                if (canNavigate) {
                    menuState += 1;
                    if (menuState > menuSize)
                        menuState = 0;
                    canNavigate = false;
                }
            } else if (input.leftStick(1, "Y") > 0.2 || input.leftStick(2, "Y") > 0.2 || input.leftStick(3, "Y") > 0.2 || input.leftStick(4, "Y") > 0.2) {
                if (canNavigate) {
                    menuState -= 1;
                    if (menuState < 0)
                        menuState = menuSize;
                    canNavigate = false;
                }
            } else {
                canNavigate = true;
            }

            //========================================================//

            //======= Upon hitting "A", check the menu state and continue ======//
            if (input.buttonDown(1, "A") || input.buttonDown(2, "A") ||
                input.buttonDown(3, "A") || input.buttonDown(4, "A")) {

                switch (menuState) {
                    case 0:
                        Time.timeScale = 1;
                        currentlypaused = false;
                        TogglePause();
                        break;
                    case 1:
                        Time.timeScale = 1;
                        currentlypaused = false;
                        RestartMatch();
                        break;
                    case 2:
                        Time.timeScale = 1;
                        currentlypaused = false;
                        gotoMainMenu();
                        break;
                }

            }

            //===============================================================//

            //====== Upon hitting "B" or start again, exit pause menu ============//
            if (input.buttonDown(1, "B") || input.buttonDown(2, "B") ||
                input.buttonDown(3, "B") || input.buttonDown(4, "B") ||
                input.buttonDown(1, "Start") || input.buttonDown(2, "Start") ||
                input.buttonDown(3, "Start") || input.buttonDown(4, "Start")) {

                Time.timeScale = 1;
                currentlypaused = false;
                TogglePause();
            }


        }


        else if (input.buttonDown(1, "Start") || input.buttonDown(2, "Start") ||
            input.buttonDown(3, "Start") || input.buttonDown(4, "Start")) {

            TimeSpeed = Time.timeScale;
            TogglePause();
            menuState = 0;
        }

        if (splatterEffect.going_out == true) {
            Time.timeScale = 1;
        }

        if (splatterEffect.going_out == false && goingToMainMenu == true) {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }

        if (splatterEffect.going_out == false && goingToRestart == true) {
            Time.timeScale = 1;
            SceneManager.LoadScene(2);
        }

    }

    public void Resume(){
    }

    public void PauseGame() {
    }

    public void TogglePause() {
        isPaused = !isPaused;
    }

    public void OnGUI() {
        if (isPaused) {
            GUI.depth = 10;
            GUI.color = new Vector4(0,0,0,0.75f);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), shade);
            GUI.DrawTexture(new Rect(20, 20, Screen.width - 40, Screen.height - 40), image_frame);

            GUI.color = Color.white;

            GUI.DrawTexture(new Rect(80, 80, 190, 90), button_resume[(menuState == 0 ? 1 : 0)]);
            GUI.DrawTexture(new Rect(100, 220, 180, 80), button_restart[(menuState == 1 ? 1 : 0)]);
            GUI.DrawTexture(new Rect(100, 320, 180, 80), button_mainmenu[(menuState == 2 ? 1 : 0)]);
        }
    }

    public void RestartMatch(){
        ScoreManager.scoreP1 = 0;
        ScoreManager.scoreP2 = 0;
        splatterEffect.startGoingOut();
        goingToRestart = true;
    }

    public void gotoMainMenu(){
        ScoreManager.scoreP1 = 0;
        ScoreManager.scoreP2 = 0;
        splatterEffect.startGoingOut();
        goingToMainMenu = true;
    }
}
