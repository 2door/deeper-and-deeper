// Camera scrolling: https://www.youtube.com/watch?v=H6q-Y5JAiDk&list=LL&index=3&t=638s&ab_channel=KeeGamedev
using System.Collections;
using System.Collections.Generic;
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

    // Update is called once per frame
    void FixedUpdate() {
        if(target.position.y < transform.position.y) {
            Vector3 targetPos = new Vector3(xPos, target.position.y - cameraOffset, zLayer);
            transform.position = Vector3.Lerp(transform.position, targetPos, 0.2f);
        }
    }
}
