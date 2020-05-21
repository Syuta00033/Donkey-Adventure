using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
    public Animator anim;

    public void ShakeCam()
    {
        anim.SetTrigger("Shake");
    }
}
