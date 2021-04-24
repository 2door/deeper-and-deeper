// Camera scrolling: https://www.youtube.com/watch?v=H6q-Y5JAiDk&list=LL&index=3&t=638s&ab_channel=KeeGamedev
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public Transform target;
    public float cameraOffset;

    private float zLayer;
    private float xPos;
    void Start() {
        zLayer = transform.position.z;
        xPos = transform.position.x;
    }

    void FixedUpdate() {
        float expectedY = target.position.y - cameraOffset;
        if(expectedY < transform.position.y) {
            Vector3 targetPos = new Vector3(xPos, expectedY, zLayer);
            transform.position = Vector3.Lerp(transform.position, targetPos, 0.2f);
        }
    }
}
