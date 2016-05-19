using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] GameObject spawnPoint;

	public float startingHealth = 100;
	public float currentHealth;
	public Slider healthSlider;
    private PlayerAccesor thisPlayer;
	public AudioClip deathClip;
	public AudioClip damagedClip;

	//float damage = System.Math.Floor(

	Animator anim;
	AudioSource playerAudio;
	bool isDead;
	bool damaged;

	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		currentHealth = startingHealth;
		playerAudio = GetComponent <AudioSource> ();
        thisPlayer = GetComponent<PlayerAccesor>();

	}
	
	// Update is called once per frame
	void Update () {
		if (damaged) {
			
		} else {
			//reset effects
		}

		//reset flag
		damaged = false;
	}

	public void TakeDamage(float amount){
		damaged = true;
		currentHealth -= amount;
		healthSlider.value = currentHealth;

		//hurt sound
		playerAudio.clip = damagedClip;
		playerAudio.Play();

		if(currentHealth <= 0 && !isDead){
			//kill player
			Death();
		}
	}

    public float GetCurrentHealth() {
        return currentHealth;
    }

	void Death(){
        currentHealth = startingHealth;
        thisPlayer.transform.position = spawnPoint.transform.position;
		isDead = true;
		anim.SetTrigger ("Die");
		playerAudio.clip = deathClip;
		playerAudio.Play ();
	}
}
