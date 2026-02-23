using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowingPlayer : MonoBehaviour
{ 
    public Transform target;
    public Vector3 distance; // kamera ile küp arasýndaki mesafe
    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + distance;
    }
}
