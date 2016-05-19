using UnityEngine;
using System.Collections;

public class PlayerStatsManager : MonoBehaviour {

    // public fields
    public string leftArmPosition;
    public string rightArmPosition;

	// private fields
    private float health;
    private float stamina;

    // buttons
    private KeyCode toggleArmTriggerL = KeyCode.Q;
    private KeyCode toggleArmTriggerR = KeyCode.E;
    private KeyCode buttonLeftArmN  = KeyCode.Alpha1;
    private KeyCode buttonLeftArmE  = KeyCode.Alpha2;
    private KeyCode buttonLeftArmS  = KeyCode.Alpha3;
    private KeyCode buttonLeftArmW  = KeyCode.Alpha4;
    private KeyCode buttonRightArmN = KeyCode.Alpha5;
    private KeyCode buttonRightArmE = KeyCode.Alpha6;
    private KeyCode buttonRightArmS = KeyCode.Alpha7;
    private KeyCode buttonRightArmW = KeyCode.Alpha8;

    // node game objects' coordinates
    Transform leftArmNode;
    Transform rightArmNode;

    // player game object coordinates
    Transform player;

    void Start() {

        leftArmPosition  = "North Up";
        rightArmPosition = "North Up";

        leftArmNode  = transform.FindChild("Left Arm Node");
        rightArmNode = transform.FindChild("Right Arm Node");

        player = gameObject.transform;

    }

    void Update() {

        if(Input.anyKeyDown) {

            // toggle players arm "Up" or "Down" on toggle button press
            if (Input.GetKeyDown(toggleArmTriggerL))
               TogglePlayerLeftArm();
            if (Input.GetKeyDown(toggleArmTriggerR))
             TogglePlayerRightArm();

            // check for moving arms to positions
            if (Input.GetKeyDown(buttonLeftArmN))
                moveLeftArmN();
            if (Input.GetKeyDown(buttonLeftArmE))
                moveLeftArmE();
            if (Input.GetKeyDown(buttonLeftArmS))
                moveLeftArmS();
            if (Input.GetKeyDown(buttonLeftArmW))
                moveLeftArmW();

            if (Input.GetKeyDown(buttonRightArmN))
                moveRightArmN();
            if (Input.GetKeyDown(buttonRightArmE))
                moveRightArmE();
            if (Input.GetKeyDown(buttonRightArmS))
                moveRightArmS();
            if (Input.GetKeyDown(buttonRightArmW))
                moveRightArmW();
        }

    }

    /****** MOVING PLAYER'S ARMS AND SHIT *******/
    // To move arms around the player
    void moveLeftArmN() {
        float old_y = leftArmNode.localPosition.y;
        leftArmPosition = leftArmPosition.Replace("East", "North")
                                         .Replace("South", "North")
                                         .Replace("West", "North");
        leftArmNode.localPosition = new Vector3(-0.3f, old_y, 1.0f);
    }

    void moveLeftArmE() {
        float old_y = leftArmNode.localPosition.y;
        leftArmPosition = leftArmPosition.Replace("North", "East")
                                         .Replace("South", "East")
                                         .Replace("West", "East");
        leftArmNode.localPosition = new Vector3(1.0f, old_y, 0.3f);
    }

    void moveLeftArmS() {
        float old_y = leftArmNode.localPosition.y;
        leftArmPosition = leftArmPosition.Replace("East", "South")
                                         .Replace("North", "South")
                                         .Replace("West", "South");
        leftArmNode.localPosition = new Vector3(-0.3f, old_y, -1.0f);
    }

    void moveLeftArmW() {
        float old_y = leftArmNode.localPosition.y;
        leftArmPosition = leftArmPosition.Replace("East", "West")
                                         .Replace("South", "West")
                                         .Replace("North", "West");
        leftArmNode.localPosition = new Vector3(-1.0f, old_y, -0.3f);
    }

    void moveRightArmN() {
        float old_y = rightArmNode.localPosition.y;
        rightArmPosition = rightArmPosition.Replace("East", "North")
                                           .Replace("South", "North")
                                           .Replace("West", "North");
        rightArmNode.localPosition = new Vector3(0.3f, old_y, 1.0f);
    }

    void moveRightArmE() {
        float old_y = rightArmNode.localPosition.y;
        rightArmPosition = rightArmPosition.Replace("North", "East")
                                           .Replace("South", "East")
                                           .Replace("West", "East");
        rightArmNode.localPosition = new Vector3(1.0f, old_y, -0.3f);
    }

    void moveRightArmS() {
        float old_y = rightArmNode.localPosition.y;
        rightArmPosition = rightArmPosition.Replace("East", "South")
                                           .Replace("North", "South")
                                           .Replace("West", "South");
        rightArmNode.localPosition = new Vector3(0.3f, old_y, -1.0f);
    }

    void moveRightArmW() {
        float old_y = rightArmNode.localPosition.y;
        rightArmPosition = rightArmPosition.Replace("East", "West")
                                           .Replace("South", "West")
                                           .Replace("North", "West");
        rightArmNode.localPosition = new Vector3(-1.0f, old_y, 0.3f);
    }

    // To move arms "up" and "down"
    void TogglePlayerLeftArm() {
                
        float old_x = leftArmNode.localPosition.x;
        float old_z = leftArmNode.localPosition.z;

        // first, update the player state
        if (leftArmPosition.Contains("Up")) {
            leftArmPosition = leftArmPosition.Replace("Up", "Down");
            leftArmNode.localPosition = new Vector3(old_x, -0.33f, old_z);
        } else {
            leftArmPosition = leftArmPosition.Replace("Down", "Up");
            leftArmNode.localPosition = new Vector3(old_x, 1.0f, old_z);

        }

    }

    void TogglePlayerRightArm() {

        float old_x = rightArmNode.localPosition.x;
        float old_z = rightArmNode.localPosition.z;

        // first, update the player state
        if (rightArmPosition.Contains("Up")) {
            rightArmPosition = rightArmPosition.Replace("Up", "Down");
            rightArmNode.localPosition = new Vector3(old_x, -0.33f, old_z);
        } else {
            rightArmPosition = rightArmPosition.Replace("Down", "Up");
            rightArmNode.localPosition = new Vector3(old_x, 1.0f, old_z);

        }
    }
}
