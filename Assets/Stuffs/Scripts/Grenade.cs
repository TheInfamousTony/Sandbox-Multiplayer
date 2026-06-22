using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Grenade : MonoBehaviour
{
    public PhotonView photonView;
    public Explode explode;
    public float wait;

    void Start()
    {
        StartCoroutine(WaitExplode());
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Entities") || collision.collider.CompareTag("ExplosiveBarrels"))
        {
            photonView.RPC("explodeFunc", RpcTarget.All);
            Destroy(gameObject);
        }
    }

    IEnumerator WaitExplode()
    {
        yield return new WaitForSeconds(wait);
        photonView.RPC("explodeFunc", RpcTarget.All);
        Destroy(gameObject);
    }

    [PunRPC]
    void explodeFunc()
    {
        explode.Explosion(10f, 2000f);
    }
}
