using UnityEngine;
using System.Collections;

public class ProjectileProperties : MonoBehaviour {


    private float initialRadius = 1;
    private bool canPickUp;
    private SphereCollider collider;
    private Rigidbody rigidbody;
    private int itemCount = 0;
    public GameObject origin;
    public bool inMotion = false;
    public GameObject TrailEffect;

    // On scene load, do this
    public void Init(GameObject parent) {
        collider  = gameObject.AddComponent<SphereCollider>();
        rigidbody = gameObject.AddComponent<Rigidbody>();
        origin = parent;

        collider.isTrigger = true;
        collider.radius = initialRadius;
        rigidbody.isKinematic = true;
    }

    // On every chance to update, do this
    void Update() {
        
        if (inMotion) {
            if (rigidbody.velocity.magnitude <= 20f) {
                inMotion = false;

                //GetComponent<StillProjectile>().makePickupable(true);
                if (TrailEffect != null)
                {
                    TrailEffect.transform.parent = null;
                    Destroy(TrailEffect, .05f);
                }

                Transform[] all_transforms = gameObject.GetComponentsInChildren<Transform>();
                foreach (Transform child in all_transforms)
                {

                    if (child.parent == gameObject.transform)
                    {

                        child.parent = null;
                        child.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                        child.gameObject.GetComponent<Rigidbody>().detectCollisions = true;
                        child.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
                        child.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-20, 20), 20f, Random.Range(-20, 20));

                        child.gameObject.GetComponent<PickupProperties>().makePickupable(true);
                    }
                }
                Physics.IgnoreCollision(GetComponent<SphereCollider>(), GameObject.Find("human1").gameObject.GetComponent<BoxCollider>(), false);
                Physics.IgnoreCollision(GetComponent<SphereCollider>(), GameObject.Find("human2").gameObject.GetComponent<BoxCollider>(), false);
                //HERE I ADD THE STOP PARTICLE EFF

                
                Destroy(this);
            }
        }

        if (transform.parent != null) {
           // canPickUp = false;
        }
    }

    void OnTriggerEnter(Collider other) {
        
       // print("collision:" + other);
        //print("parent: " + origin);
        bool blah = false;

        if (other.gameObject != origin && inMotion) {
          //  print("desu");
            
            foreach (Collider box in origin.GetComponents<BoxCollider>()) {
                if (!blah) {
                    Physics.IgnoreCollision(GetComponent<SphereCollider>(), box, false);

                }
            }
        } else {
            //print("no desu");
        }
    }

    // Get this object's item count
    public int getItemCount() {
        return this.itemCount;
    }

    // Set this object's transformations
    public void setPosition(Vector3 t) {
        this.transform.position = t;
    }

	// Set the collision radius of this projectile
    public void setRadius(float f) {
        if (collider != null) {
            collider.radius = f;
        }
    }

    // Get prjectile radius
    public float getRadius() {
        if (collider != null) {
            return collider.radius;
        } else return 0f;
    }

    public void appendItem(GameObject otherObject) {

        otherObject.GetComponent<Rigidbody>().detectCollisions = false;
        otherObject.GetComponent<Rigidbody>().isKinematic = true;
        otherObject.GetComponent<PickupProperties>().makePickupable(false);

        otherObject.transform.parent = this.transform;
        otherObject.transform.position = this.transform.position;
        otherObject.transform.rotation = Random.rotation;        

        if (itemCount > 0) {
            
            // randomize about radius
            otherObject.transform.position += new Vector3(0, 0.75f * collider.radius, 0);
            otherObject.transform.RotateAround(this.transform.position, new Vector3 (Random.Range(0, 359), Random.Range(0, 359), Random.Range(0, 359)), Random.Range(0, 359));

        }
        
        setRadius(collider.radius + 0.1f);
        itemCount++;
    }
}
