using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Rockets : MonoBehaviour
{
    public PhotonView photonView;
    public Explode explode;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Entities") || collision.collider.CompareTag("Blocks") || collision.collider.CompareTag("ExplosiveBarrels") || collision.collider.CompareTag("Paper"))
        {
            photonView.RPC("explodeFunc", RpcTarget.All);
            Destroy(gameObject);
        }
    }

    [PunRPC]
    void explodeFunc()
    {
        explode.Explosion(10f, 2000f);
    }
}
