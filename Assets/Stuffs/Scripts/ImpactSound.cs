using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSound : MonoBehaviour
{
    public AudioSource impact;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 5f && collision.gameObject.tag != "Bubble")
            impact.volume = collision.relativeVelocity.magnitude / 50f;
            impact.Play();
    }
}
