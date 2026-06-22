using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float jumpForce;
    public AudioSource trampolineSound;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Entities") || collision.collider.CompareTag("Blocks") || collision.collider.CompareTag("ExplosiveBarrels"))
        {
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();
            trampolineSound.Play();
            rb.AddForce(jumpForce * collision.collider.gameObject.transform.up, ForceMode.Impulse);
        }
    }
}
