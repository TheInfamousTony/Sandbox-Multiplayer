using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    void Update()
    {
        float z = Mathf.PingPong(Time.time, 1f);
        Vector3 axis = new Vector3(1, 1, z);
        transform.Rotate(axis, 1f);
    }
}
