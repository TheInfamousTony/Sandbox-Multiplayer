using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerCamera : MonoBehaviour
{
    public float senX = 400f;
    public float senY = 400f;

    [HideInInspector]
    public bool isSprinting;

    public float sprintFOV;
    public float normalFOV;

    public Transform player;
    public Transform orientation;
    public Transform crouchPosition;
    public Transform normalPosition;
    public Transform emotePosition;
    public Camera cam;

    public PhotonView photonView;

    float xRot;
    [HideInInspector]
    public float initSenX;
    [HideInInspector]
    public float initSenY;
    [HideInInspector]
    public bool stopLook;
    [HideInInspector]
    public bool isCrouching;
    [HideInInspector]
    public bool emoting;

    void Start()
    {
        initSenX = senX;
        initSenY = senY;

        isCrouching = false;
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }

        if (!stopLook)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senY;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);

        if(stopLook)
        {
            senX = 0;
            senY = 0;
        }
        else
        {
            senX = initSenX;
            senY = initSenY;
        }

        if (isSprinting)
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, sprintFOV, 10f * Time.deltaTime);
        else
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, normalFOV, 10f * Time.deltaTime);

        if (isCrouching)
            transform.position = Vector3.Lerp(transform.position, crouchPosition.position, 10f * Time.deltaTime);
        else if (emoting)
        {
            transform.position = Vector3.Lerp(transform.position, emotePosition.position, 10f * Time.deltaTime);
        }
        else
            transform.position = Vector3.Lerp(transform.position, normalPosition.position, 10f * Time.deltaTime);

    }
}
