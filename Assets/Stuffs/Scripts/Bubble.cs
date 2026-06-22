using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Bubble : MonoBehaviour
{
    public GameObject bubbleBreak;

    public PhotonView photonView;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground") || collision.collider.CompareTag("Entities") || collision.collider.CompareTag("Blocks") || collision.collider.CompareTag("ExplosiveBarrels") || collision.collider.CompareTag("Paper"))
        {
            PhotonNetwork.Destroy(gameObject);
            StartCoroutine(BreakParticle());
        }
    }

    IEnumerator BreakParticle()
    {
        GameObject destroyEffect = PhotonNetwork.Instantiate(bubbleBreak.name, transform.position, transform.rotation);
        yield return new WaitForSeconds(1f);
        PhotonNetwork.Destroy(destroyEffect);
    }
}
