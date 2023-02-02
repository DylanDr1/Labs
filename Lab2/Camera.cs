using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // store the distance between the main camer and player
    public Vector3 camOffset = new Vector3(0f, 1.2f, -2.6f);

    // hold the player's transform info: position, rotation, and scale
    private Transform target;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        this.transform.position = target.TransformPoint(camOffset);
        this.transform.LookAt(target);
    }
}
