using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SplatterSceneTransition : MonoBehaviour {

    public List<Texture2D> splatter_sprite;
    public int sprite_index;
    public int delay_og;
    public int delay;

    public bool coming_in = false;
    public bool going_out = false;

    public InputManager inputManager;

	// Use this for initialization
	void Start () {

        inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();

        delay = 1;
        delay_og = delay;

        splatter_sprite = new List<Texture2D>();
        foreach(object o in Resources.LoadAll("Menu/Transition/orange", typeof(Texture2D))) {
            splatter_sprite.Add(o as Texture2D);
        }

        coming_in = true;
        sprite_index = splatter_sprite.Count - 1;
	}

    void OnLevelWasLoaded() {
        coming_in = true;
        sprite_index = splatter_sprite.Count - 1;
    }

	// Update is called once per frame
	void FixedUpdate () {

        // Animation transitioning in
       if (coming_in) {

           if (inputManager != null)
               inputManager.active = false;
           
            if (delay >= 0)
                delay--;
            else {
                sprite_index--;
                delay = delay_og;
            }

            if (sprite_index == -1) {
                if (inputManager != null)
                    inputManager.active = true;
                coming_in = false;
            }
        }

       // Animation transitioning out
       if (going_out) {

           if (inputManager != null)
               inputManager.active = false;

           if (delay >= 0)
               delay--;
           else {
               sprite_index++;
               delay = delay_og;
           }

           if (sprite_index >= splatter_sprite.Count - 1) {
                if (inputManager != null)
                    inputManager.active = true;
                going_out = false;
           }
       }
	}

    void OnGUI() {

        GUI.depth = -100;

        if(sprite_index >= 0)
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), splatter_sprite[sprite_index]);
    }

    public void startGoingOut() {
        going_out = true;
        sprite_index = 0;
    }

    public void startComingIn() {
        coming_in = true;
        sprite_index = splatter_sprite.Count - 1;
    }
}
