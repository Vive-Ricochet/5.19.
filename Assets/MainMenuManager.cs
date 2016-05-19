using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    // texture buttons for menu
    public Texture2D image_frame;

    public Texture2D[] button_versus = new Texture2D[3];
    public Texture2D[] button_exit = new Texture2D[3];

    public int menuState = 0;

    private InputManager input;
    private bool canNavigate = true;
    private int menuSize = 1;

    private bool goingToVersus = false;
    private bool goingToTitle = false;

    SplatterSceneTransition splatterEffect;

	// Use this for initialization
	void Start () {

        // instantiate input manager
        input = GameObject.Find("InputManager").GetComponent<InputManager>();

        // get scene changing splatter effect
        splatterEffect = GameObject.Find("TransitionManager").GetComponent<SplatterSceneTransition>();

        image_frame = Resources.Load("Menu/menu_frame", typeof(Texture2D)) as Texture2D;
        button_versus[0] = Resources.Load("Menu/button_versus00", typeof(Texture2D)) as Texture2D;
        button_versus[1] = Resources.Load("Menu/button_versus01", typeof(Texture2D)) as Texture2D;
        button_exit[0] = Resources.Load("Menu/button_exit00", typeof(Texture2D)) as Texture2D;
        button_exit[1] = Resources.Load("Menu/button_exit01", typeof(Texture2D)) as Texture2D;

	}

    void OnLevelWasLoaded() {
        goingToTitle = false;
        goingToVersus = false;
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
	}

    void OnGUI() {

        GUI.depth = -10;

        GUI.DrawTexture(new Rect(20, 20, Screen.width - 40, Screen.height - 40), image_frame);

        GUI.DrawTexture(new Rect(Screen.width/4 - 100, Screen.height/4 - 20, 270, 140), button_versus[(menuState == 0 ? 1 : 0)]);
        GUI.DrawTexture(new Rect(Screen.width / 4 , Screen.height / 4 + 140, 260, 140), button_exit[(menuState == 1 ? 1 : 0)]);
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
}
