using UnityEngine;
using System.Collections;

public class CameraTargetManager : MonoBehaviour
{
    [SerializeField]
    private Transform target1;
    [SerializeField]
    private Transform target2;

    private Vector3 old_pos;

    // Use this for initialization
    void Start()
    {

        float aX = (target1.position.x + target2.position.x) * 0.5f;
        float aY = (target1.position.y + target2.position.y) * 0.5f;
        float aZ = (target1.position.z + target2.position.z) * 0.5f;
        transform.position = new Vector3(aX, aY, aZ);
        old_pos = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
    }

    void FixedUpdate()
    {
        //get the average vector from both targets
        float aX = (target1.position.x + target2.position.x) * 0.5f;
        float aY = (target1.position.y + target2.position.y) * 0.5f;
        float aZ = (target1.position.z + target2.position.z) * 0.5f;

        Vector3 position = new Vector3(aX, aY, aZ);
        transform.position = Vector3.Lerp(old_pos, position, Time.deltaTime * 3.0f);
        old_pos = transform.position;
    }
}
