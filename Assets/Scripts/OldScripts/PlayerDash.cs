using UnityEngine;
using System.Collections;

public class PlayerDash : MonoBehaviour {

    // Private fields editable by inspector
    [SerializeField] private int dashDuration = 40;
    [SerializeField] private string DashButton;

    // Private fields
    private PlayerAccesor myStats;
    private int dashRecovery = 0;
    private Vector3 dashDir;
    private float speed;
    private float rotationSpeed;
    private PlayerMovement PM;
    private Camera PlayerCamera;

    Animator animate;
    public float IsCharging = 0.0f;
    public bool IsDashing = false;

    // Use this for initialization
    void Start() {
        animate = GetComponent<Animator>();

        // Get my accessor
        myStats = GetComponent<PlayerAccesor>();
        // Get Player movement
        PM = GetComponent<PlayerMovement>();

        // Get values from player movement
        speed = PM.getSpeed();
        rotationSpeed = PM.getRotationSpeed();
        PlayerCamera = PM.getPlayerCamera();
    }

    // Update is called once per frame
    void FixedUpdate() {

        //camera setting: get the direction camera is facing. 
        Vector3 camDir = PlayerCamera.transform.forward;
        camDir.y = 0;
        camDir.Normalize();
        
        Vector3 newVel = Vector3.zero;
        
        if (PM) {

			if (Input.GetAxis(DashButton) == 1 && GetComponent<PlayerStamina>().currentStamina > 50) {
                myStats.setCharging(true);
                IsCharging = Input.GetAxis(DashButton);
                animate.SetFloat("IsCharging", IsCharging);
            }

			if (Input.GetAxis(DashButton) != 1 && myStats.isCharging() && GetComponent<PlayerStamina>().currentStamina > 50) {

                newVel = Vector3.zero;
                dashDir = camDir;
                myStats.setCharging(false);
                myStats.setDashing(true);


                IsDashing = true;
                animate.SetBool("IsDashing", IsDashing);

				GetComponent<PlayerStamina>().ApplyFatigue(50);
            }
        }

        if (myStats.isCharging() == true) {
            transform.rotation = Quaternion.LookRotation(camDir);
        }

        //if (PM.isDashing()) {
        if (myStats.isDashing()) {

            
            dashRecovery++;
            newVel += dashDir * (speed * 3f);
            transform.position += (newVel * Time.fixedDeltaTime);

            //transform camera
            if (newVel != Vector3.zero) {
                transform.rotation = Quaternion.LookRotation(dashDir);
            }

            //check if dash is over
            if (dashRecovery >= dashDuration) {

                myStats.setDashing(false);
                dashRecovery = 0;
                IsDashing = false;
                animate.SetBool("IsDashing", IsDashing);
				IsCharging = 0.0f;
                animate.SetFloat("IsCharging", IsCharging);

            }
        }
    }

    // check on collision with another collider
    /*** must be trigger enabled ***/
    void OnTriggerEnter(Collider other) {

        // only if this object is dashing...
        if (myStats.isDashing()) {


            // if other object is a "Pickup":
            GameObject otherObject = other.gameObject;
            
            if (otherObject.CompareTag("Player")) {

                myStats.setColliding(true);
            }
        }
    }

    void OnTriggerExit(Collider other) {
         
        // upon exiting a collision with another player
        if (other.gameObject.CompareTag("Player")) {
            myStats.setColliding(false);
        }
    }
		
    public void ResetDash() {

		dashRecovery = 0;
		IsDashing = false;
		IsCharging = 0.0f;
		animate.SetFloat ("IsCharging", IsCharging);
		animate.SetBool ("IsDashing", IsDashing);
    }

}