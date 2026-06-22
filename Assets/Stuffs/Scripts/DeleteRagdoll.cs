using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DeleteRagdoll : MonoBehaviour
{
    public GameObject ragdollParent;

    public PhotonView photonView;

    public void Delete()
    {
        DeleteRagdollParent();
    }

    void DeleteRagdollParent()
    {
        PhotonNetwork.Destroy(ragdollParent);
    }
}
