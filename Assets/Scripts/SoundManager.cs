using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip shoot, hit, ammo, healed;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        shoot = Resources.Load<AudioClip>("ShootSound");
        hit = Resources.Load<AudioClip>("HitSound");
        ammo = Resources.Load<AudioClip>("AmmoPickup");
        healed = Resources.Load<AudioClip>("HealedSound");
        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "shoot":
                audioSrc.PlayOneShot(shoot);
                break;
            case "hit":
                audioSrc.PlayOneShot(hit);
                break;
            case "ammo":
                audioSrc.PlayOneShot(ammo);
                break;
            case "healed":
                audioSrc.PlayOneShot(healed);
                break;
        }
    }
}
