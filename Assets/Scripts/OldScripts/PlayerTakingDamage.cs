using UnityEngine;
using System.Collections;

public class PlayerTakingDamage : MonoBehaviour {

    // Fly myself backwards and twirl and shit
    public void FlyBackwards(Transform influencingTransform) {

        Vector3 thatRotation = Vector3.zero;
        Vector3 thisRotation = Vector3.zero;

        float thatYrotation = influencingTransform.eulerAngles.y;
        float thisYrotation = transform.eulerAngles.y;
        thatRotation.y = thatYrotation;
        thisRotation.y = thisYrotation;

        float diffRotation = thisRotation.y - thatRotation.y;
        diffRotation = Mathf.Abs(diffRotation);

        print(diffRotation);
        transform.eulerAngles = new Vector3(0, Mathf.Round(diffRotation / 90) * 90, 0);
    }
}
