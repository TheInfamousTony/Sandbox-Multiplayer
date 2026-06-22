using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    public float radius = 2;
    public float force = 1;

    public void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 forceDirection = transform.position - nearbyObject.transform.position;

                rb.AddForce(forceDirection.normalized * force * Time.deltaTime, ForceMode.Force);
            }
        }
    }
}
