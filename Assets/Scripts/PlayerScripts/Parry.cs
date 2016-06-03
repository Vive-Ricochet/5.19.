using UnityEngine;
using System.Collections;

public class Parry : MonoBehaviour
{

    private InputManager input;
    private int player_num;

    public static int BoSP1;
    public static int BoSP2;
    public GameObject player;

    private int startFrame;
    private int parryProgress;
    private int parryWindow = 10;
    private int parryDurration = 30;
    private Collider parryBox;

    private bool parrying = false;
    public bool canParry = false;

    private Vector3 playerScreenPos;
    private Camera playerCamera;

    [SerializeField] private Texture parrySprite;
    private bool button_down = false;

    // Use this for initialization
    void Start() {

        input = GameObject.Find("InputManager").GetComponent<InputManager>();
        player_num = GetComponent<PlayerMovement>().player_num;

        foreach (BoxCollider box in GetComponents<BoxCollider>()) {
            if (box.isTrigger)
                parryBox = box;
        }

        playerCamera = GetComponent<PlayerMovement>().PlayerCamera;
    }

    // Update is called once per engine update (not frame refresh)
    void Update() {

        if (input.leftTrigger(player_num) >= 0.2f && !parrying && !button_down) {
            parrying = true;
            startFrame = Time.frameCount;
            //GetComponent<PlayerMovement>().canMove = false;
            button_down = true;
            GetComponent<ProjectileMaker>().cancelSpin();

        }

        if (parrying && Time.frameCount - startFrame < parryDurration) {
            if (Time.frameCount - startFrame < parryWindow) {
                canParry = true;
                playerScreenPos = playerCamera.WorldToScreenPoint(transform.position);
            } else {
                canParry = false;
            }
        } else if(parrying && Time.frameCount - startFrame >= parryDurration) {
            canParry = false;
            parrying = false;
            //GetComponent<PlayerMovement>().canMove = true;
        }

        if (input.leftTrigger(player_num) < 0.2f)
            button_down = false;

    }

    void OnGUI() {
        if (parrySprite && canParry) {
            GUI.DrawTexture(new Rect(playerScreenPos.x - 45, Screen.height - playerScreenPos.y - 60, 80, 80), parrySprite);
        }
    }


    void OnTriggerEnter(Collider other) {
        ProjectileProperties projectile = other.gameObject.GetComponent<ProjectileProperties>();
        if (projectile != null) {
            if (projectile.inMotion && canParry) {
                parry(other);
            }
        }
    }

    private void parry(Collider other) {
        if (player.name.Equals("human1")) {
            BoSP1 += 1;
        }
        if (player.name.Equals("human2")) {
            BoSP2 += 1;
        }
        GetComponent<ProjectileMaker>().appendItem(other);
    }
}
