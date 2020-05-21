using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoItem : MonoBehaviour
{
    private void Update()
    {
        if(transform.position.x <= -10.2889f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (AmmoText.ammo != 20)
        {
            if (col.gameObject.tag == "Player")
            {
                SoundManager.PlaySound("ammo");
                AmmoText.ammo += 20 - AmmoText.ammo;
                Destroy(gameObject);
            }
        }
    }
}
