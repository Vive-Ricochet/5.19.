using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

public class InputManager : MonoBehaviour {

    public bool active = true;

    XboxController player01;
    XboxController player02;

	// Use this for initialization
	void Start () {
        active = true;
        player01 = XboxController.First;
        player02 = XboxController.Second;

	}
	
	// Update is called once per frame
	void Update () {

        if (active) {

            ///////// Assign player 01 /////////////
            if (Input.GetKey(KeyCode.Alpha1) && XCI.GetButton(XboxButton.Start, XboxController.First)) {
                print("Assigning XBOX CONTROLLER 01 to Player 01...");
                player01 = XboxController.First;
            }

            if (Input.GetKey(KeyCode.Alpha1) && XCI.GetButton(XboxButton.Start, XboxController.Second)) {
                print("Assigning XBOX CONTROLLER 02 to Player 01...");
                player01 = XboxController.Second;
            }

            if (Input.GetKey(KeyCode.Alpha1) && XCI.GetButton(XboxButton.Start, XboxController.Third)) {
                print("Assigning XBOX CONTROLLER 03 to Player 01...");
                player01 = XboxController.Third;
            }

            if (Input.GetKey(KeyCode.Alpha1) && XCI.GetButton(XboxButton.Start, XboxController.Fourth)) {
                print("Assigning XBOX CONTROLLER 04 to Player 01...");
                player01 = XboxController.Fourth;
            }

            /////////// Assign player 02 /////////////
            if (Input.GetKey(KeyCode.Alpha2) && XCI.GetButton(XboxButton.Start, XboxController.First)) {
                print("Assigning XBOX CONTROLLER 01 to Player 02...");
                player02 = XboxController.First;
            }

            if (Input.GetKey(KeyCode.Alpha2) && XCI.GetButton(XboxButton.Start, XboxController.Second)) {
                print("Assigning XBOX CONTROLLER 02 to Player 02...");
                player02 = XboxController.Second;
            }

            if (Input.GetKey(KeyCode.Alpha2) && XCI.GetButton(XboxButton.Start, XboxController.Third)) {
                print("Assigning XBOX CONTROLLER 03 to Player 02...");
                player02 = XboxController.Third;
            }

            if (Input.GetKey(KeyCode.Alpha2) && XCI.GetButton(XboxButton.Start, XboxController.Fourth)) {
                print("Assigning XBOX CONTROLLER 04 to Player 02...");
                player02 = XboxController.Fourth;
            }

        }
        
    }

    public bool buttonDown(int player_num, string button) {

        if (active) {

            XboxController player;
            if (player_num == 1)
                player = player01;
            else if (player_num == 2)
                player = player02;
            else
                return false;

            switch (button) {
                case "A":
                    return XCI.GetButtonDown(XboxButton.A, player);
                case "B":
                    return XCI.GetButtonDown(XboxButton.B, player);
                case "X":
                    return XCI.GetButtonDown(XboxButton.X, player);
                case "Y":
                    return XCI.GetButtonDown(XboxButton.Y, player);
                case "RB":
                    return XCI.GetButtonDown(XboxButton.RightBumper, player);
                case "LB":
                    return XCI.GetButtonDown(XboxButton.LeftBumper, player);
                case "Start":
                    return XCI.GetButtonDown(XboxButton.Start, player);
                case "Back":
                    return XCI.GetButtonDown(XboxButton.Back, player);
                case "R3":
                    return XCI.GetButtonDown(XboxButton.RightStick, player);
                case "L3":
                    return XCI.GetButtonDown(XboxButton.LeftStick, player);
                case "N":
                    return XCI.GetButtonDown(XboxButton.DPadUp, player);
                case "E":
                    return XCI.GetButtonDown(XboxButton.DPadRight, player);
                case "S":
                    return XCI.GetButtonDown(XboxButton.DPadDown, player);
                case "W":
                    return XCI.GetButtonDown(XboxButton.DPadLeft, player);
                default:
                    return false;
            }
        }

        return false;
    }

    public bool buttonUp(int player_num, string button) {

        if (active) {

            XboxController player;
            if (player_num == 1)
                player = player01;
            else if (player_num == 2)
                player = player02;
            else
                return false;

            switch (button) {
                case "A":
                    return XCI.GetButtonUp(XboxButton.A, player);
                case "B":
                    return XCI.GetButtonUp(XboxButton.B, player);
                case "X":
                    return XCI.GetButtonUp(XboxButton.X, player);
                case "Y":
                    return XCI.GetButtonUp(XboxButton.Y, player);
                case "RB":
                    return XCI.GetButtonUp(XboxButton.RightBumper, player);
                case "LB":
                    return XCI.GetButtonUp(XboxButton.LeftBumper, player);
                case "Start":
                    return XCI.GetButtonUp(XboxButton.Start, player);
                case "Back":
                    return XCI.GetButtonUp(XboxButton.Back, player);
                case "R3":
                    return XCI.GetButtonUp(XboxButton.RightStick, player);
                case "L3":
                    return XCI.GetButtonUp(XboxButton.LeftStick, player);
                case "N":
                    return XCI.GetButtonUp(XboxButton.DPadUp, player);
                case "E":
                    return XCI.GetButtonUp(XboxButton.DPadRight, player);
                case "S":
                    return XCI.GetButtonUp(XboxButton.DPadDown, player);
                case "W":
                    return XCI.GetButtonUp(XboxButton.DPadLeft, player);
                default:
                    return false;
            }
        }

        return false;
    }

    public bool button(int player_num, string button) {

        if (active) {

            XboxController player;
            if (player_num == 1)
                player = player01;
            else if (player_num == 2)
                player = player02;
            else
                return false;

            switch (button) {
                case "A":
                    return XCI.GetButton(XboxButton.A, player);
                case "B":
                    return XCI.GetButton(XboxButton.B, player);
                case "X":
                    return XCI.GetButton(XboxButton.X, player);
                case "Y":
                    return XCI.GetButton(XboxButton.Y, player);
                case "RB":
                    return XCI.GetButton(XboxButton.RightBumper, player);
                case "LB":
                    return XCI.GetButton(XboxButton.LeftBumper, player);
                case "Start":
                    return XCI.GetButton(XboxButton.Start, player);
                case "Back":
                    return XCI.GetButton(XboxButton.Back, player);
                case "R3":
                    return XCI.GetButton(XboxButton.RightStick, player);
                case "L3":
                    return XCI.GetButton(XboxButton.LeftStick, player);
                case "N":
                    return XCI.GetButton(XboxButton.DPadUp, player);
                case "E":
                    return XCI.GetButton(XboxButton.DPadRight, player);
                case "S":
                    return XCI.GetButton(XboxButton.DPadDown, player);
                case "W":
                    return XCI.GetButton(XboxButton.DPadLeft, player);
                default:
                    return false;
            }
        }

        return false;
    }

    public float leftStick(int player_num, string x_or_y) {

        if (active) {

            XboxController player;
            if (player_num == 1)
                player = player01;
            else if (player_num == 2)
                player = player02;
            else
                return 0f;

            XboxAxis axis;
            if (x_or_y == "X")
                axis = XboxAxis.LeftStickX;
            else if (x_or_y == "Y")
                axis = XboxAxis.LeftStickY;
            else
                return 0f;

            return XCI.GetAxisRaw(axis, player);
        }

        return 0;
    }

    public float rightStick(int player_num, string x_or_y) {

        if (active) {

            XboxController player;
            if (player_num == 1)
                player = player01;
            else if (player_num == 2)
                player = player02;
            else
                return 0f;

            XboxAxis axis;
            if (x_or_y == "X")
                axis = XboxAxis.RightStickX;
            else if (x_or_y == "Y")
                axis = XboxAxis.RightStickY;
            else
                return 0f;

            return XCI.GetAxisRaw(axis, player);
        }

        return 0;
    }

    public float leftTrigger(int player_num) {

        if (active) {

            XboxController player;
            if (player_num == 1)
                player = player01;
            else if (player_num == 2)
                player = player02;
            else
                return 0f;

            return XCI.GetAxis(XboxAxis.LeftTrigger, player);
        }

        return 0;
    }

    public float rightTrigger(int player_num) {

        if (active) {

            XboxController player;
            if (player_num == 1)
                player = player01;
            else if (player_num == 2)
                player = player02;
            else
                return 0f;

            return XCI.GetAxis(XboxAxis.RightTrigger, player);
        }

        return 0;
    }


}
