using UnityEngine;
using System.Collections;

public class PlayerPickupManager : MonoBehaviour {

    // private variables
    // WOO BUTTONS
    private KeyCode pickupTriggerL = KeyCode.Mouse0; // pickup button LEFT ARM
    private KeyCode pickupTriggerR = KeyCode.Mouse1; // pickup button RIGHT ARM
    
    // pickup state related
    private bool canPickUpL = false;
    private bool canPickUpR = false;
    string leftArmPosition;
    string rightArmPosition;
    string leftArm  = "Left Arm Node";
    string rightArm = "Right Arm Node";

    // PickupStateProperties
    private PickupProperties pickupProperties;

    // on load scene, do this
    void Start() {
    
    }


    void FixedUpdate() {

        // on pickup on pickUpTrigger activating button
        if (Input.GetKeyDown(pickupTriggerL))
            canPickUpL = true;
        if (canPickUpL && Input.GetKeyUp(pickupTriggerL))
            canPickUpL = false;

        if (Input.GetKeyDown(pickupTriggerR))
            canPickUpR = true;
        if (canPickUpR && Input.GetKeyUp(pickupTriggerR))
            canPickUpR = false;

    }

    // check on collision with another collider
    /*** must be trigger enabled ***/
    void OnTriggerEnter(Collider other) {

        if (canPickUpL || canPickUpR) {

            // if other object is a "Pickup":
            if (other.gameObject.CompareTag("Pickup")) {

                GameObject otherObject = other.gameObject;

                // append item to a node representing 
                if(canPickUpL)
                    AppendItem(otherObject, leftArm);
                if (canPickUpR)
                    AppendItem(otherObject, rightArm);

                // obtain pickup's properties
                pickupProperties = otherObject.GetComponent<PickupProperties>();
                if (pickupProperties != null)
                    pickupProperties.PrintProperties(); // print'em

            }
        }

    }

    void AppendItem(GameObject otherObject, string nodeToAppendTo) {

        // disable pickup's rigid body to give it that ephemeral feel
        // also make it kinematic to disable effective forces
        otherObject.GetComponent<Rigidbody>().detectCollisions = false;
        otherObject.GetComponent<Rigidbody>().isKinematic = true;

        // append object to player node, make it a child of that node
        otherObject.transform.parent = this.transform.FindChild(nodeToAppendTo);
        otherObject.transform.position = this.transform.FindChild(nodeToAppendTo).position;

    }

}