using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    // private fields editable by inspector
    [SerializeField]
    private Transform target;              // the target object for this camera
    [SerializeField]
    private Transform player1;
    [SerializeField]
    private Transform player2;
    [SerializeField]
    private float minDistance = 15;
    [SerializeField]
    private float distanceBias = 0.75f;    //How much the distance affects the zoom affect

    private float old_dis;
    private float distance;

    // private fields
    private float xDeg = 0.0f;
    private float yDeg = 0.0f;
    private float PauseDelay = 1f;
    private bool StillScreen = true;

    private int countdownToStart = 100;
    private bool alreadyCounted = false;
    public bool collided = false;
    public Texture2D image_knockout;

    private bool initialHit = false;

    private float XDist;
    private float YDist;
    private float ZDist;

    public Texture2D image_ready;
    public Texture2D image_vive;
    public Texture2D white_screen;


    void Start() {

        image_ready = Resources.Load("Text/image_ready", typeof(Texture2D)) as Texture2D;
        image_vive = Resources.Load("Text/image_vive", typeof(Texture2D)) as Texture2D;
        white_screen = Resources.Load("Menu/white_screen", typeof(Texture2D)) as Texture2D;

        old_dis = Vector3.Distance(player1.position, player2.position);
        collided = false;

        image_knockout = Resources.Load("Text/image_knockout", typeof(Texture2D)) as Texture2D;
        Time.timeScale = 1.0f;

        player1.GetComponent<PlayerMovement>().canMove = false;
        player2.GetComponent<PlayerMovement>().canMove = false;
    }

    void FixedUpdate() {
        if (countdownToStart > 0)
        {
            countdownToStart--;
        }
        else {
            //canMove fucked here
            if (alreadyCounted == false)
            {
                player1.GetComponent<PlayerMovement>().canMove = true;
                player2.GetComponent<PlayerMovement>().canMove = true;
                alreadyCounted = true;
            }
        }
    }

    void LateUpdate() {
        if (!target)
            return;
        if (initialHit) {
            Camera.main.fieldOfView = Camera.main.fieldOfView / 2f;
            initialHit = false;
        }
        if (!collided) {
            distance = Mathf.Lerp(old_dis, Vector3.Distance(player1.position, player2.position), Time.deltaTime * 2.0f);
            Camera.main.fieldOfView = distance * distanceBias + minDistance;
            old_dis = distance;
        } else {
            float CamZ = target.position.z + ZDist;
            float CamY = target.position.y + YDist;
            float CamX = target.position.x + XDist;
            Camera.main.transform.position = new Vector3(CamX, CamY, CamZ);
            //Camera.main.position = target.position + Distance * direction.normalized();
            PlayShake();
            float col_dis = Vector3.Distance(transform.position, target.position);
            Camera.main.fieldOfView -= col_dis / 500;
            if (Camera.main.fieldOfView <= 25) Camera.main.fieldOfView = 25;
            if (Time.timeScale < 7.5f) {
                if (Time.timeScale < .1f)
                    Time.timeScale *= 1.25f;
                else {
                    Time.timeScale += .005f;
                }
                //Time.fixedDeltaTime = 0.01F * Time.timeScale;
            }
        }
        // camera rotation
        Quaternion rotation = Quaternion.Euler(yDeg, xDeg, 0);


        // apply rotation
        transform.LookAt(target);


    }
    public void onCollision(Transform playerTarget) {
        collided = true;
        StillScreen = true;
        Time.timeScale = .0001f;
        target = playerTarget;
        initialHit = true;
        XDist = Random.Range(0f, 20f);
        YDist = Random.Range(10f, 35f);
        ZDist = Random.Range(0f, 20f);

    }

    void OnGUI() {

        GUI.depth = 100;

        if (countdownToStart < 100 && countdownToStart > 20) {
            GUI.DrawTexture(new Rect(Screen.width / 2 - 320, Screen.height / 2 - 160, 640, 260), image_ready);
        }

        if (countdownToStart < 20 && countdownToStart > 0) {
            GUI.DrawTexture(new Rect(Screen.width / 2 - 340, Screen.height / 2 - 160, 680, 260), image_vive);
            player1.GetComponent<PlayerMovement>().canMove = true;
            player2.GetComponent<PlayerMovement>().canMove = true;
        }

        if (countdownToStart == 20) {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), white_screen);
        }

        if(collided) {
            GUI.DrawTexture(new Rect(Screen.width/2 - 170, Screen.height/2 , 340, 100), image_knockout);
        }

    }

    public float duration = 0.5f;
    public float speed = 1.0f;
    public float magnitude = 0.3f;

    public bool test = false;

    // -------------------------------------------------------------------------
    public void PlayShake() {

        StopAllCoroutines();
        StartCoroutine("Shake");
    }

    // -------------------------------------------------------------------------

    // -------------------------------------------------------------------------
    IEnumerator Shake() {

        float elapsed = 0.0f;

        Vector3 originalCamPos = Camera.main.transform.position;
        float randomStart = Random.Range(-1000.0f, 1000.0f);

        while (elapsed < duration) {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;

            // We want to reduce the shake from full power to 0 starting half way through
            float damper = 1.0f - Mathf.Clamp(2.0f * percentComplete - 1.0f, 0.0f, 1.0f);

            // Calculate the noise parameter starting randomly and going as fast as speed allows
            float alpha = randomStart + speed * percentComplete;

            // map noise to [-1, 1]
            float x = Util.Noise.GetNoise(alpha, 0.0f, 0.0f) * 2.0f - 1.0f;
            float y = Util.Noise.GetNoise(0.0f, alpha, 0.0f) * 2.0f - 1.0f;

            x *= magnitude * damper;
            y *= magnitude * damper;

            float xpos = x + originalCamPos.x;
            float ypos = y + originalCamPos.y;
            Camera.main.transform.position = new Vector3(xpos, ypos, originalCamPos.z);

            yield return null;
        }

        Camera.main.transform.position = originalCamPos;
    }
}