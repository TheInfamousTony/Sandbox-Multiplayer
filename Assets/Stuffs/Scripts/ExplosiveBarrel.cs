using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ExplosiveBarrel : MonoBehaviour
{
    public PhotonView photonView;
    public Explode explode;

    public void ExplosiveBarrelFunction()
    {
        photonView.RPC("explodeFunc", RpcTarget.All);
        Destroy(gameObject);
    }

    [PunRPC]
    void explodeFunc()
    {
        explode.Explosion(10f, 2000f);
    }
}
