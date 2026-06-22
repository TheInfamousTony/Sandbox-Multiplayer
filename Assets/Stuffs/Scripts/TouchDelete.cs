using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDelete : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
