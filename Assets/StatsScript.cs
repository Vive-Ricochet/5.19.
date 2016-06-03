using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsScript : MonoBehaviour {

    public Text Thrown;
    public Text PickedUp;
    public Text Parry;
    public Text Traveled;

    // Use this for initialization
    void Start() {
        Thrown = Thrown.GetComponent<Text>();
        PickedUp = PickedUp.GetComponent<Text>();
        Parry = Parry.GetComponent<Text>();
        Traveled = Traveled.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() {
        Thrown.text = "Total Throws = " + PlayerPrefs.GetInt("total_thrown");
        PickedUp.text = "Total Picked Up Items = " + PlayerPrefs.GetInt("total_pickedUp");
        Parry.text = "Total Catches = " + PlayerPrefs.GetInt("total_caught");
        Traveled.text = "Total Traveled = " + PlayerPrefs.GetInt("total_distance") + " units";
    }
}

