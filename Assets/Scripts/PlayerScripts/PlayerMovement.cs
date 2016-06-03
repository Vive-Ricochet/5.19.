using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    // private fields editable by inspector
    [SerializeField] private float speed = 20;  // player movement speed
    [SerializeField] private float jump = 5;   // player intitial jump velocity
    [SerializeField] private float rotationSpeed = 100; // player rotation speed
	[SerializeField] public Camera PlayerCamera;

    [SerializeField] InputManager input;
    [SerializeField] public int player_num = 1;

    public GameObject player;
    public static int player1_travel;
    public static int player2_travel;


    // private fields
    PlayerAccesor myStats;
    private bool grounded;
    private Rigidbody rb;

    public bool dashing;
    public bool canMove = true;
    private bool canDash = false; //to be used with stamina
    //private bool canDash = false;//to be used with stamina
	private bool charging;



    // public fields
    Animator animator;

    bool running = false;
    //float isMovingH = 0.0f;
    //float isMovingV = 0.0f;

    void Start() {

        input = GameObject.Find("InputManager").GetComponent<InputManager>();

        // initialize my accessor
        myStats = GetComponent<PlayerAccesor>();
        myStats.setDashing(false);
        myStats.setCharging(false);

        // rigid body used for in-engine physics 
        rb = GetComponent<Rigidbody>();
        //dashing = false;
		//charging = false;
        animator = GetComponent<Animator>();


		
        // gravity is intended to be used for this object
        rb.useGravity = true;
        Physics.gravity = new Vector3(0f, -60.0f, 0f);

    }

    void FixedUpdate() {

        //print(dashing);
   /*     if (Input.GetButtonDown(inScore))
        {
            if (inScore.Equals("Plus_1"))
                ScoreManager.scoreP1 += 1;
            else if (inScore.Equals("Plus_2"))
                ScoreManager.scoreP2 += 1;
        } */

        // get normalized camera forward direction. Ignor Y transformation
		Vector3 camDir = PlayerCamera.transform.forward;
        camDir.y = 0;
        camDir.Normalize();

        // get camera's righthand direction for move perpendicular to camera
        Vector3 camRight = new Vector3(camDir.z, 0f, -camDir.x);
        
        // the new velocity to be applied
        Vector3 newVel = Vector3.zero;

        // calculate movement transformations
        // (apply only if not dashing currently)
        //if (dashing==false && charging == false) {
        if ( canMove ) {

            if (player.name == "human1") {
                player1_travel += 1;
            }
            if (player.name == "human2") {
                player2_travel += 1;
            }

            // Get movement inputs
            if ( System.Math.Abs( input.leftStick(player_num, "X")) > 0  || System.Math.Abs(input.leftStick(player_num, "Y")) > 0) {
                running = true;
            }
            else { running = false; }
            //isMovingH = System.Math.Abs(Input.GetAxis(Horizontal));
            //isMovingV = System.Math.Abs(Input.GetAxis(Vertical));

            newVel += input.leftStick(player_num, "X") * camRight * speed;
			newVel += input.leftStick(player_num, "Y") * camDir * speed;

            animator.SetBool("Running", running);
            //if (isMovingH > 0) animator.SetFloat("IsMoving", isMovingH);
            //if (isMovingV > 0) animator.SetFloat("IsMoving", isMovingV);
            //if (isMovingH == 0 && isMovingV == 0) animator.SetFloat("IsMoving", isMovingH);


            // apply new velocity
            transform.position += (newVel * Time.fixedDeltaTime);

            // rotate rigid body to face direction they are moving
            if (newVel != Vector3.zero) {
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    Quaternion.LookRotation(newVel),
                    Time.deltaTime * rotationSpeed
                    );
            }

        }

    }

	// on 'entering' a collision: grounded = true
	void OnCollisionEnter(Collision collisionInfo){
        if(collisionInfo.gameObject.CompareTag("Floor"))
            grounded = true;
	}
	
    // on 'exiting' a collision: grounded = true
	void OnCollisionExit(Collision collisionInfo){
        if(collisionInfo.gameObject.CompareTag("Floor"))
		    grounded = false;
	}

   
    
    //Getters and setters
    public void setDashing(bool input) {
        dashing = input;
    }

    public bool isDashing() {
        return dashing;
    }
	
	public void setCharging(bool input){
		charging = input;
	}
	
	public bool isCharging(){
		return charging;
    }
    public float getSpeed() {
        return speed;
    }

    public float getRotationSpeed() {
        return rotationSpeed;
    }

    public Camera getPlayerCamera() {
        return PlayerCamera;
    }
	
}