using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilAnim : MonoBehaviour
{
    public Animator anim;

    public IEnumerator Recoil()
    {
        anim.SetBool("Fire", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Fire", false);
    }
}
