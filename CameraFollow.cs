using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform PlayerTransform;

    private Vector3 cameraOffset;

    [Range(0.01f,1.0f)]
    public float smooth = 0.5f; 


    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerTransform = player.transform;
        cameraOffset = transform.position - PlayerTransform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = PlayerTransform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smooth); 

    }
}
