using UnityEngine;

public class Cloud : MonoBehaviour
{
    public static bool inCloud = false;

    private void Update()
    {
        if(transform.position.x <= -12.32238f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!inCloud)
            {
                WeaponScript.inCloud = true;
                PlayerControl.speed -= 3.0f;
                inCloud = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (inCloud)
            {
                WeaponScript.inCloud = false;
                PlayerControl.speed += 3.0f;
                inCloud = false;
            }
        }
    }
}
