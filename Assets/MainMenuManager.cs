using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    // texture buttons for menu
    public Texture2D image_frame;
    public Texture2D image_blackScreen;

    public Texture2D[] button_versus = new Texture2D[3];
    public Texture2D[] button_exit = new Texture2D[3];
    public Texture2D[] button_controls = new Texture2D[3];
    public Texture2D[] button_credits = new Texture2D[3];
    public Texture2D[] button_data = new Texture2D[3];


    public int menuState = 0;

    private InputManager input;
    private bool canNavigate = true;
    private int menuSize = 4;

    private bool goingToVersus = false;
    private bool goingToTitle = false;
    private bool goingToData = false;
    private bool goingToCredits = false;
    private bool goingToControls = false;

    private GUIStyle style;
    private string textbox_text;


    SplatterSceneTransition splatterEffect;

	// Use this for initialization
	void Start () {

        // instantiate input manager
        input = GameObject.Find("InputManager").GetComponent<InputManager>();

        // get scene changing splatter effect
        splatterEffect = GameObject.Find("TransitionManager").GetComponent<SplatterSceneTransition>();

        image_frame = Resources.Load("Menu/menu_frame", typeof(Texture2D)) as Texture2D;
        image_blackScreen = Resources.Load("Menu/black_screen", typeof(Texture2D)) as Texture2D;
        button_versus[0] = Resources.Load("Menu/button_versus00", typeof(Texture2D)) as Texture2D;
        button_versus[1] = Resources.Load("Menu/button_versus01", typeof(Texture2D)) as Texture2D;
        button_exit[0] = Resources.Load("Menu/button_exit00", typeof(Texture2D)) as Texture2D;
        button_exit[1] = Resources.Load("Menu/button_exit01", typeof(Texture2D)) as Texture2D;
        button_data[0] = Resources.Load("Menu/button_data00", typeof(Texture2D)) as Texture2D;
        button_data[1] = Resources.Load("Menu/button_data01", typeof(Texture2D)) as Texture2D;
        button_controls[0] = Resources.Load("Menu/button_controls00", typeof(Texture2D)) as Texture2D;
        button_controls[1] = Resources.Load("Menu/button_controls01", typeof(Texture2D)) as Texture2D;
        button_credits[0] = Resources.Load("Menu/button_credits00", typeof(Texture2D)) as Texture2D;
        button_credits[1] = Resources.Load("Menu/button_credits01", typeof(Texture2D)) as Texture2D;

        style = new GUIStyle();
        style.fontSize = 30;
        style.normal.textColor = Color.white;

        textbox_text = "HEHAHFS";
    }

    void OnLevelWasLoaded() {
        goingToTitle = false;
        goingToVersus = false;
        goingToData = false;
        goingToCredits = false;
        goingToControls = false;
    }

	// Update is called once per frame
	void Update () {

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

        //======= Upon hitting "A", check the menu state and continue ======//
        if (input.buttonDown(1, "A") || input.buttonDown(2, "A") ||
            input.buttonDown(3, "A") || input.buttonDown(4, "A")) {

            switch (menuState) {
                case 0:
                    gotoVersus();
                    break;
                case 1:
                    gotoControls();
                    break;
                case 2:
                    gotoData();
                    break;
                case 3:
                    gotoCredits();
                    break;
                case 4:
                    gotoTitleScreen();
                    break;
            }

        }

        //====== If changing scene, wait untill the transition animation is over =======/
        if (goingToTitle) {
            if (splatterEffect.going_out == false) {
                SceneManager.LoadScene(0);
            }
        }

        if (goingToVersus) {
            if (splatterEffect.going_out == false) {
                SceneManager.LoadScene(2);
            }
        }

        if (goingToData) {
            if (splatterEffect.going_out == false) {
                SceneManager.LoadScene(4);
            }
        }

        if (goingToCredits) {
            if (splatterEffect.going_out == false) {
                SceneManager.LoadScene(5);
            }
        }

        if (goingToControls) {
            if (splatterEffect.going_out == false) {
                SceneManager.LoadScene(6);
            }
        }

        // textbox things
        switch (menuState) {
            case 0:
                textbox_text = "Start a two-player knockout match\nVictory goes to the first to score three points!";
                break;
            case 1:
                textbox_text = "See the control scheme";
                break;
            case 2:
                textbox_text = "View collected medals and other\nmiscellaneous information";
                break;
            case 3:
                textbox_text = "Vive Ricochet credits";
                break;
            case 4:
                textbox_text = "Return to the title screen";
                break;
        }

	}

    void OnGUI() {

        GUI.depth = -10;

        GUI.DrawTexture(new Rect(20, 20, Screen.width - 40, Screen.height - 40), image_frame);

        GUI.DrawTexture(new Rect(620, 80, 320, 150), button_versus[(menuState == 0 ? 1 : 0)]);
        GUI.DrawTexture(new Rect(500, 250, 320, 150), button_controls[(menuState == 1 ? 1 : 0)]);
        GUI.DrawTexture(new Rect(400, 420, 320, 150), button_data[(menuState == 2 ? 1 : 0)]);
        GUI.DrawTexture(new Rect(320, 590, 320, 150), button_credits[(menuState == 3 ? 1 : 0)]);
        GUI.DrawTexture(new Rect(300, 760, 320, 150), button_exit[(menuState == 4 ? 1 : 0)]);

        GUI.color = new Vector4(1, 1, 1, 0.5f);
        GUI.DrawTexture(new Rect(850, 700, 650, 170), image_blackScreen);
        GUI.color = new Vector4(1, 1, 1, 1);

        GUI.color = Color.white;
        GUI.Label(new Rect(870, 720, 600, 300), textbox_text, style);

    }

    void gotoVersus() {
        goingToVersus = true;
        splatterEffect.startGoingOut();
        //SceneManager.LoadScene(2);
    }

    void gotoTitleScreen() {
        goingToTitle = true;
        splatterEffect.startGoingOut();
        //SceneManager.LoadScene(0);
    }

    void gotoData() {
        goingToData = true;
        splatterEffect.startGoingOut();
    }

    void gotoCredits() {
        goingToCredits = true;
        splatterEffect.startGoingOut();
    }

    void gotoControls() {
        goingToControls = true;
        splatterEffect.startGoingOut();
    }
}
