using UnityEngine;
using System.Collections;

public abstract class PickupProperties : MonoBehaviour {

    // this object's various values
    private float durability_value;
    private float attack_mod;
    private float defense_mod;
    private float weight_value;
	private AudioClip sound;
    private bool pickupable = true;

	// create a private list of properties for this object...
    private ArrayList properties = new ArrayList();
    private GameObject Spawn;

    // on load scene
    void Start() {
        // ...
    }

    /////// GETTING VALUES /////////
    public float attackModifier() {
        return attack_mod;
    }

    public float defenseModifier() {
        return defense_mod;
    }

    public float weight() {
        return weight_value;
    }

    public float durability() {
        return durability_value;

    }

    public bool isPickupable() {
        return pickupable;
    }
    /////////////////////////////

    // properties' accessor
    public ArrayList GetProperties() {
        return properties;
    }

    // add a property too this object
    public void AddProperty(string name) {
        properties.Add(name);
    }

    public void setSpawn(GameObject spawnpoint)
    {
        Spawn = spawnpoint;
    }

    public GameObject getSpawner()
    {
        return Spawn;
    }

    // print properties to console
    public void PrintProperties() {
        foreach (string element in properties) {
            print(element);
        }
    }

	//Setters//
	public void attackSet(float atk){
		attack_mod = atk;
	}

	public void defenseSet(float def){
		defense_mod = def;
	}

	public void weightSet(float weight){
		weight_value = weight;
	}

	public void duraSet(float durability){
		durability_value = durability;
	}

    public void makePickupable(bool b) {
        pickupable = b;
    }

	public void soundSet(AudioClip s){
		sound = s;
	}

	public void useDurability() {
		durability_value--;
	}
}