using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Added_Results_Manager : MonoBehaviour {


    public RawImage BofP1;
    public RawImage BosP1;
    public RawImage hoardP1;
    public RawImage TravelP1;
    public RawImage BofP2;
    public RawImage BosP2;
    public RawImage hoardP2;
    public RawImage TravelP2;

    public static int TotalThrows= 0;
    public static int TotalPickup = 0;
    public static int TotalParry = 0;
    public static int TotalTraveled = 0;

    // Use this for initialization
    void Start() {
        BofP1 = BofP1.GetComponent<RawImage>();
        BofP2 = BofP2.GetComponent<RawImage>();
        BosP1 = BosP1.GetComponent<RawImage>();
        BosP2 = BosP2.GetComponent<RawImage>();
        hoardP1 = hoardP1.GetComponent<RawImage>();
        hoardP2 = hoardP2.GetComponent<RawImage>();
        TravelP1 = TravelP1.GetComponent<RawImage>();
        TravelP2 = TravelP2.GetComponent<RawImage>();


        TotalThrows = ProjectileMaker.BoFP1 + ProjectileMaker.BoFP2 + TotalThrows;
        TotalPickup = ProjectileMaker.HoardP1 + ProjectileMaker.HoardP2 + TotalPickup;
        TotalParry = Parry.BoSP1 + Parry.BoSP2 + TotalParry;
        TotalTraveled = PlayerMovement.player1_travel + PlayerMovement.player2_travel + TotalTraveled;

        print("Traveled " + TotalTraveled + "units");
        print("Total Parries are " + TotalParry);
        print("Total Throws are " + TotalThrows);
        print("Total Pickedup are " + TotalPickup);
    }


    // Update is called once per frame
    void Update() {

        if (ProjectileMaker.BoFP1 > ProjectileMaker.BoFP2) {
            BofP1.enabled = true;
            BofP2.enabled = false;
        }
        if (ProjectileMaker.BoFP1 < ProjectileMaker.BoFP2) {
            BofP1.enabled = false;
            BofP2.enabled = true;
         }
        if (ProjectileMaker.BoFP1 == ProjectileMaker.BoFP2) {
            BofP1.enabled = false;
            BofP2.enabled = false;
        }

        if (Parry.BoSP1 > Parry.BoSP2) {
            BosP1.enabled = true;
            BosP2.enabled = false;
        }
         if (Parry.BoSP1 < Parry.BoSP2) {
            BosP1.enabled = false;
            BosP2.enabled = true;
         }
        if (Parry.BoSP1 == Parry.BoSP2) {
            BosP1.enabled = false;
            BosP2.enabled = false;
        }

        if (PlayerMovement.player1_travel > PlayerMovement.player2_travel) {
            TravelP1.enabled = true;
            TravelP2.enabled = false;
        }
         if (PlayerMovement.player1_travel < PlayerMovement.player2_travel) {
            TravelP1.enabled = false;
            TravelP2.enabled = true;
         }
        if (PlayerMovement.player1_travel == PlayerMovement.player2_travel) {
            TravelP1.enabled = false;
            TravelP2.enabled = false;
        }

        if (ProjectileMaker.HoardP1 > ProjectileMaker.HoardP2) {
            hoardP1.enabled = true;
            hoardP2.enabled = false;
        }
        if (ProjectileMaker.HoardP1 < ProjectileMaker.HoardP2) {
            hoardP1.enabled = false;
            hoardP2.enabled = true;
        }
        if (ProjectileMaker.HoardP1 == ProjectileMaker.HoardP2) {
            hoardP1.enabled = false;
            hoardP2.enabled = false;
        }


    }
}
