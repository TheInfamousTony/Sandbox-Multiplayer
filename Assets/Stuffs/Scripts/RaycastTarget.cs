using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTarget : MonoBehaviour
{
    public Transform target;

    RaycastHit hit;
    float dist;

    void Update()
    {
        Physics.Raycast(transform.position, -transform.up, out hit);
        dist = Vector3.Distance(hit.point, target.position);

        if (dist >= 1f)
        {
            target.position = hit.point;
        }
    }
}
