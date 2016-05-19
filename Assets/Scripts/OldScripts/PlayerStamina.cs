using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStamina : MonoBehaviour {
	public int startingStamina = 100;
	public int currentStamina;
	public Slider StaminaSlider;
	public AudioClip tiredClip;
	public AudioClip fatigueClip;

	int dashAttack = 60;
	int timer  = 40;
	int mod = 0;

    PlayerDash playerDash;
    Animator anim;
	AudioSource playerAudio;
	bool isTired;
	//bool fatigue = false;
	//bool canDash = true;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		currentStamina = startingStamina;
		playerAudio = GetComponent <AudioSource> ();
        playerDash  = GetComponent<PlayerDash>();

    }

	// Update is called once per frame
	void FixedUpdate () {
		mod++;

        //print(currentStamina);

		if (currentStamina < startingStamina && mod % 4 == 0) {
			ApplyFatigue(-1);
		}
		if (currentStamina < startingStamina && !GetComponent<PlayerAccesor>().isCharging() && !GetComponent<PlayerAccesor>().isDashing()){
                //ApplyFatigue(-1);
		}
		/*if (currentStamina < dashAttack) {
			// fatigue = true;
			// resetFatigue ();
		} else if (currentStamina >= dashAttack  && playerDash.IsDashing) {
			ApplyFatigue (dashAttack);
		}
        */
		//reset flag
	}

	public void ApplyFatigue(int amount){
		//fatigue = true;
		currentStamina -= amount;
		StaminaSlider.value = currentStamina;

		//draining sound
		//playerAudio.clip = fatigueClip;
		//playerAudio.Play();
		if(currentStamina <= 0 && !isTired){
			//kill player
			Tired();
		}
	}

	void resetFatigue(){
		if (playerDash.IsDashing == false || currentStamina < 100){
				timer -= 1;
				if (timer == 0) { currentStamina += 1; }
				if (currentStamina >= dashAttack){
				//	fatigue = false;
				//	canDash = true;
			}
		}
	}

	void Tired(){
		isTired = true;
		anim.SetTrigger ("Tired");
		playerAudio.clip = tiredClip;
		playerAudio.Play ();
	}
}
