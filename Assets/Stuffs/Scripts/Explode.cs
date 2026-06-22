using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Explode : MonoBehaviour
{
    public void Explosion(float radius, float force)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        StartCoroutine(ExplosionEffect());

        PhotonNetwork.Destroy(gameObject);
    }

    IEnumerator ExplosionEffect()
    {
        GameObject explosionEffect = PhotonNetwork.Instantiate("Explosion", transform.position, transform.rotation);
        yield return new WaitForSeconds(1f);
        PhotonNetwork.Destroy(explosionEffect);
    }
}