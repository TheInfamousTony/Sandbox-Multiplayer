using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChangeColorBlock : MonoBehaviour
{
    public PhotonView photonView;
    public void ChangeBlockColor(float r, float g, float b, bool glowornot)
    {
        photonView.RPC("changeColor", RpcTarget.All, r, g, b, glowornot);
    }

    [PunRPC]
    void changeColor(float r, float g, float b, bool glowornot)
    {
        Color color = new Color(r, g, b);
        if (!glowornot)
            gameObject.GetComponent<Renderer>().material.color = color;
        else
            gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
    }
}
