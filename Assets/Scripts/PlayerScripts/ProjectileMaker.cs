using UnityEngine;
using System.Collections;

public class  ProjectileMaker : MonoBehaviour {

    [SerializeField] private GameObject otherPlayer;
    private InputManager input;
    private int player_num;

    public static int BoFP1;
    public static int BoFP2;
    public static int HoardP1;
    public static int HoardP2;

    public GameObject currentProjectile = null;
    public GameObject player;

    private float gravity = 50;
    private bool canPickUp = false;
    private bool isThrowing = false;
    private float throwSpeed = 100;
    private float throwSpeedMax = 150;
    //private int throwTimer = 200;
    private float rotationSpeed = 0.5f;
    private float rotationSpeedMax = 50;
    Animator animator;
    bool throwing = false;
    public bool canSpin = true;
    public GameObject ThrowEff;
    
    private ParticleSystem ThrowEffect;


    private string projectileName = "Projectile Object";

	// Use this for initialization
	void Start () {

        input = GameObject.Find("InputManager").GetComponent<InputManager>();
        player_num = GetComponent<PlayerMovement>().player_num;

        Physics.gravity = Vector3.down * gravity;
        animator = GetComponent<Animator>();


}

// Update is called once per frame
void Update () {

        canPickUp = input.button(player_num, "X");

        if (canSpin && input.rightTrigger(player_num) >= 0.2) {
            spinBall();
        }

        if (!canSpin && input.rightTrigger(player_num) >= 0.2) {
            canSpin = true;
        }

        if (isThrowing && input.rightTrigger(player_num) < 0.2f) {
            throwBall();
        }

	}
    
    // How to build a new projectile
    public GameObject buildNewProjectile() {

        // Create a game object with the necessary values and scripts
        GameObject projectile = new GameObject(projectileName);
        projectile.AddComponent<ProjectileProperties>();
        projectile.GetComponent<ProjectileProperties>().Init(gameObject);
    
        // This part is for the projectile's properties as a pickup after laying still
        projectile.AddComponent<StillProjectile>();
        projectile.tag = "Pickup";

        // Set initial values (transforms, radius, etc.) of the ProjectileProperties
        projectile.transform.parent = this.transform;
        projectile.transform.rotation = this.transform.rotation;
        projectile.GetComponent<ProjectileProperties>().setPosition(this.transform.position + new Vector3(0, 2, 0));


        foreach (Collider blah in this.GetComponents<Collider>()) {
            Physics.IgnoreCollision(blah, projectile.GetComponent<Collider>());
        }
        
        return projectile;
    }

    /****** APPENDING ITEMS TO PLAYER'S NODES *******/
    // On colliding with pickup item
    /*** must be trigger enabled ***/
    void OnTriggerEnter(Collider other) {

            if (other.gameObject.CompareTag("Pickup") && other.gameObject.GetComponent<PickupProperties>().isPickupable()) {
                appendItem(other);
                GameObject spawnLocation = (GameObject) other.gameObject.GetComponent<PickupProperties>().getSpawner();
                spawnLocation.GetComponent<SpawnItems>().startSpawnTimer();
            }
        
    }

    // Append an item to the current projectile
    public void appendItem(Collider other) {
        if (player.name.Equals("human1"))
            HoardP1 += 1;
        if (player.name.Equals("human2")) {
            HoardP2 += 1;
        }

        if (currentProjectile == null) {
            currentProjectile = buildNewProjectile();
        }

        GameObject otherObject = other.gameObject;
        Transform thisTransform = currentProjectile.transform;
        ProjectileProperties thisProjectile = currentProjectile.GetComponent<ProjectileProperties>();

        currentProjectile.GetComponent<ProjectileProperties>().appendItem(otherObject);

        float amount = currentProjectile.GetComponent<ProjectileProperties>().getRadius() + GetComponent<BoxCollider>().size.y / 2;
        currentProjectile.transform.localPosition = new Vector3(0f, amount, 0f); 
    }

    // Spin a ball for some reason
    void spinBall() {
        isThrowing = true;
        if (currentProjectile != null) {
            //throwTimer -= 1;
            currentProjectile.transform.Rotate(Vector3.right * rotationSpeed);
            if (rotationSpeed < rotationSpeedMax) 
                rotationSpeed += 0.25f;
            if (throwSpeed < throwSpeedMax)
                throwSpeed = throwSpeed * 1.01f;
            //if (throwTimer <= 0) {
            //    throwTimer = 200;
            //    throwBall();
            //}
        }
    }

    // Throw a ball
 /*   void throwBall() {
        rotationSpeed = 1;
        isThrowing = false;
        throwing = false;
        if (currentProjectile != null) {
            throwing = true;
            animator.SetBool("Throwing", throwing);

            // getting initial projectile references
            Vector3 projectilePosition = currentProjectile.transform.position;
            projectilePosition.y -= -currentProjectile.GetComponent<ProjectileProperties>().getRadius();
            Vector3 heading = otherPlayer.transform.position - currentProjectile.transform.position; // the vector between this player and target

            // projectile property calculations
            float distance = new Vector2(heading.x, heading.z).magnitude; // the horizontal distance between this player and target
            float deltaHeight = currentProjectile.transform.position.y - otherPlayer.transform.position.y - 10f; // projectile's relative transform height
            float upwardsMagnitude = ((-deltaHeight * throwSpeed) / distance) - ((gravity * distance) / (2 * throwSpeed)); // projectile "y" velocity component

            // reset projectile's inherited values
            currentProjectile.transform.parent = null;
            currentProjectile.GetComponent<Rigidbody>().isKinematic = false;
            currentProjectile.GetComponent<Rigidbody>().detectCollisions = true;
            currentProjectile.GetComponent<SphereCollider>().isTrigger = false;

            // apply new velocity
            Vector3 newVelocity = new Vector3(heading.x, 0f, heading.z).normalized * throwSpeed + new Vector3(0, -upwardsMagnitude, 0);
            currentProjectile.GetComponent<Rigidbody>().velocity = newVelocity;
            currentProjectile.GetComponent<ProjectileProperties>().inMotion = true;
            currentProjectile = null;


        }
        throwSpeed = 25;
    }
  */

    void throwBall() {
        rotationSpeed = 1;
        isThrowing = false;
        throwing = false;
        if (currentProjectile != null) {
            throwing = true;
            animator.SetBool("Throwing", throwing);
            if (player.name.Equals("human1")) {
                BoFP1 += 1;
            }
            if (player.name.Equals("human2")) {
                BoFP2 += 1;
            }

            // getting initial projectile references
            Vector3 projectilePosition = currentProjectile.transform.position;
            projectilePosition.y -= -currentProjectile.GetComponent<ProjectileProperties>().getRadius();
            Vector3 heading = otherPlayer.transform.position - currentProjectile.transform.position + new Vector3(0, 0, 0); // the vector between this player and target

            // projectile property calculations
            float distance = new Vector2(heading.x, heading.z).magnitude; // the horizontal distance between this player and target
            float deltaHeight = currentProjectile.transform.position.y - otherPlayer.transform.position.y - 10f; // projectile's relative transform height
            float upwardsMagnitude = ((-deltaHeight * throwSpeed) / distance) - ((gravity * distance) / (2 * throwSpeed)); // projectile "y" velocity component

            // reset projectile's inherited values
            currentProjectile.transform.parent = null;
            currentProjectile.GetComponent<Rigidbody>().isKinematic = false;
            currentProjectile.GetComponent<Rigidbody>().detectCollisions = true;
            currentProjectile.GetComponent<SphereCollider>().isTrigger = false;

            // apply new velocity
            Vector3 newVelocity = heading.normalized * throwSpeed;
            currentProjectile.GetComponent<Rigidbody>().velocity = newVelocity;
            currentProjectile.GetComponent<ProjectileProperties>().inMotion = true;


            GameObject Effect = Instantiate(ThrowEff);
            Effect.transform.position = currentProjectile.transform.position;
            Effect.transform.parent = currentProjectile.transform;
            if (player_num == 2)
            {

                Effect.GetComponent<ParticleSystem>().startColor = Color.blue;
            }
            else {
                Effect.GetComponent<ParticleSystem>().startColor = Color.red;
            }

            currentProjectile.GetComponent<ProjectileProperties>().TrailEffect = Effect;


currentProjectile = null;

        }
        throwSpeed = 100;
    }

    public void cancelSpin() {

        canSpin = false;
        rotationSpeed = 1;
        throwSpeed = 25;
        isThrowing = false;
        throwing = false;
    }
}
