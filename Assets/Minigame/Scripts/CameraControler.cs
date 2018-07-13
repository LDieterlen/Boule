using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

    public Transform player;
    private Vector3 offset;
    public static bool initCamera;
    private Quaternion startRotation;
    private float currentRotX;
    private float currentRotY;
    private float currentRotZ;
    private Quaternion initRotation;
    private Vector3 direction;
    private Vector3 initPosition;


    // Use this for initialization
    void Start()
    {
        initRotation = transform.rotation;
        initPosition = transform.position;
        offset = transform.position - player.transform.position;
        transform.position = player.transform.position;
        transform.position = player.position;
        transform.Rotate(0, 0, 0);
    }


    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }


    void FixedUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Rotation") * 2, Vector3.up) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);

        if (initCamera)
        {
            transform.position = initPosition;
            offset = new Vector3(0.0f, 1.2f, -1.7f);
            transform.rotation = initRotation;
            initCamera = false;

        }

    }

}
