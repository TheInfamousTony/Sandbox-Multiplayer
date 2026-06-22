using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Grabbing : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject grabbableCrosshair;

    public LayerMask whatIsDraggable;
    public Transform gunTip, player;
    public Rigidbody gunTipRb;
    public new Transform camera;
    public float maxDistance = 100f;
    SpringJoint joint;

    public PhotonView photonView;

    RaycastHit hit;

    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if (Input.GetMouseButtonDown(2))
        {
            StartDrag();
        }
        else if(Input.GetMouseButtonUp(2))
        {
            StopDrag();
        }

        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsDraggable))
        {
            crosshair.SetActive(false);
            grabbableCrosshair.SetActive(true);
        }
        else
        {
            crosshair.SetActive(true);
            grabbableCrosshair.SetActive(false);
        }
    }

    void StartDrag()
    {
        if(Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsDraggable))
        {
            joint = hit.transform.gameObject.AddComponent<SpringJoint>();
            joint.connectedBody = gunTipRb;

            joint.maxDistance = 1f;
            joint.minDistance = 1f;

            joint.spring = 1000000000f;
            joint.damper = 0.2f;
            joint.massScale = 4.5f;
        }
    }

    void StopDrag()
    {
        Destroy(joint);
    }
}
