using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLegRoot : MonoBehaviour
{
    public Transform LegRootPos;

    void Update()
    {
        transform.position = LegRootPos.position;
    }
}
