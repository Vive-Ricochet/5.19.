using UnityEngine;
using System.Collections;

public class CollisionManager : MonoBehaviour {

    public bool hit = false;
    int timer;
    public GameObject HitEffect;

    void FixedUpdate()
    {
        timer -= 1;
        if (timer == 0) {
            hit = true;
        }
    }	
    
    // Check if player has been hit by a moving projectile
    void OnCollisionEnter(Collision other) {

        // The agent is a projectile
        if (other.gameObject.GetComponent<ProjectileProperties>() != null)
        {
            if (other.gameObject.GetComponent<ProjectileProperties>().inMotion && !GetComponent<Parry>().canParry)
            {

                other.gameObject.GetComponent<ProjectileProperties>().inMotion = false;
                Vector3 obj_velocity = other.gameObject.GetComponent<Rigidbody>().velocity;

                // Affect the player
                hitPlayer(obj_velocity);


                // Split up the incoming object and scatter
                Transform[] all_transforms = other.gameObject.GetComponentsInChildren<Transform>();
                foreach (Transform child in all_transforms)
                {

                    if (child.parent == other.gameObject.transform)
                    {

                        child.parent = null;
                        child.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                        child.gameObject.GetComponent<Rigidbody>().detectCollisions = true;
                        child.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-60, 60), Random.Range(-60, 60), Random.Range(-60, 60));
                        child.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-20, 20), 40f, Random.Range(-20, 20));

                        child.gameObject.GetComponent<PickupProperties>().makePickupable(true);
                    }
                }
            }
        }
    }

    // The player has been it
    public void hitPlayer(Vector3 obj_velocity) {
        timer = 120;

        obj_velocity = obj_velocity.normalized;
        obj_velocity *= 0.5f;
        obj_velocity.y = 50f;

        GetComponent<PlayerMovement>().canMove = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<Rigidbody>().velocity = obj_velocity;
        GetComponent<Rigidbody>().angularVelocity = new Vector3(50f, 0f, 50f);

        float delay = 0.07f;
        float start_time = Time.realtimeSinceStartup;
        //Time.timeScale = 0.0f;

        //while (Time.realtimeSinceStartup - start_time < delay) {
        //  GetComponent<PlayerMovement>().canMove = false;
        //}

        GetComponent<PlayerMovement>().canMove = false;
        GetComponent<Parry>().enabled = false;
        //Time.timeScale = 1.0f;

        //hit = true;
        print("Player hit!");
        GetComponent<AudioSource>().Play();

        CameraController CC = GameObject.Find("P1Cam").GetComponent<CameraController>();
        CC.onCollision(gameObject.transform);

        Vector3 particalPosition = transform.position;
        particalPosition.y += 5;

        Instantiate(HitEffect, particalPosition, transform.rotation);

    }
}
