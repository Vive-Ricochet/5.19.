using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnItems : MonoBehaviour {
    [SerializeField] public List<GameObject> GameObjs = new List<GameObject>();
    [SerializeField] public float SpawnTimer = 500;

    private bool timeRunning;
    private float currTimer;
    private bool canSpawn = true;


    // Use this for initialization
    void Start () {
        canSpawn = true;
        timeRunning = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (canSpawn == true)
        {
            int random = Random.Range(0, GameObjs.Count);
            GameObject item = (GameObject)Instantiate(GameObjs[random], transform.position, transform.rotation);
            //set the item's initial spawn point
            PickupProperties pickup = item.GetComponent<PickupProperties>();
            pickup.setSpawn(gameObject);
            

            canSpawn = false;
            currTimer = SpawnTimer;
        }
        if (timeRunning)
        {
            if (currTimer <= 0)
            {
                canSpawn = true;
                timeRunning = false;
                currTimer = SpawnTimer;
            }
            else {
                currTimer--;
            }
        }
	}

    public void startSpawnTimer()
    {
        timeRunning = true;
    }
}
