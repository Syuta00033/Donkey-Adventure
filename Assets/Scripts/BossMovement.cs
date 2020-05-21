using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private Rigidbody2D rig;
    private float speed = 5.0f;
    private bool entryDone = false;
    private bool changeDirection = false;

    private float currentTime = 0.0f;

    //For BossWeaponScript
    public static bool normalShoot = false;
    public static bool rapidShoot = false;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = Vector2.left * speed;
    }

    void FixedUpdate()
    {
        //Stop Entry
        if (!entryDone)
        {
            if (transform.position.x <= 6.76f)
            {
                rig.velocity = Vector2.zero;
                entryDone = true;
            }
        }

        if (entryDone && !Boss.healed)
        {
            currentTime += Time.fixedDeltaTime;
            Movement();
        } else if(entryDone && Boss.healed)
        {
            rig.velocity = Vector2.left * speed;
            if(transform.position.x <= -12.28f)
            {
                Destroy(gameObject);
            }
        }
    }

    void Movement()
    {
        normalShoot = true;
        if (changeDirection)
        {
            rig.velocity = Vector2.up * speed;
        }
        else
        {
            rig.velocity = Vector2.down * speed;
        }

        if (currentTime > 5.0f)
        {
            if (rig.transform.position.y >= -0.3f && rig.transform.position.y <= -0.1f)
            {
                normalShoot = false;
                rig.velocity = Vector2.zero;
                rapidShoot = true;
                if (currentTime > 10)
                {
                    rapidShoot = false;
                    currentTime = 0.0f;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Wall1")
        {
            changeDirection = false;
        }

        if (col.gameObject.name == "Wall2")
        {
            changeDirection = true;
        }
    }
}
