using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp = 2;
    private bool healed = false;

    //Destroy Bounds
    public float leftBounds = -20.0f;
    public float downBounds = -20.0f;

    //Kugelfisch Mechanic
    public float growTime = 1.0f;
    public bool Kugelfisch = false;
    private float currentTime = 0.0f;
    private Rigidbody2D rig;
    public Animator anim;

    //Particles
    public ParticleSystem particles;

    //Cam Shake
    private CamShake shake;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CamShake>();

        if (Kugelfisch)
        {
            hp = 3;
        }
    }

    void Update()
    {
   

        if (Kugelfisch)
        {
            currentTime += Time.deltaTime;
            grow();
            anim.SetInteger("HP", Mathf.Abs(hp));
            anim.SetBool("healed", healed);
        }

        if(transform.position.x <= leftBounds || transform.position.y <= downBounds)
        {
            Destroy(gameObject);

            if (!healed)
            {
                RipScript.ripFish++;
                shake.ShakeCam();
            }
        }
    }

    void grow()
    {
        if (!healed)
        {
            if (currentTime >= growTime)
            {
                rig.transform.localScale += new Vector3(0.04f, 0.04f, 0.04f);
                hp++;
                rig.gravityScale += 0.5f;
                currentTime = 0.0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    { 
        Shot shot = col.gameObject.GetComponent<Shot>();
        if (gameObject.tag == "Enemy" && !Kugelfisch)
        {
            if (shot && !healed)
            {
                ParticleSystem explode = Instantiate(particles, rig.transform.position, Quaternion.identity);
                hp--;
                Destroy(col.gameObject);
                if (hp <= 0)
                {
                    SpriteRenderer r = GetComponent<SpriteRenderer>();
                    r.color = Color.white;
                    healed = true;
                    SoundManager.PlaySound("healed");
                    ScoreText.score += 1;
                  
                }
                else
                {
                    SoundManager.PlaySound("hit");
                   
                }
            }
        }

        if (Kugelfisch)
        {
           // GameObject explode = Instantiate(particles, rig.transform.position, Quaternion.identity);
          //  explode.GetComponent<ParticleSystem>().Play();

            if (shot && !healed)
            {
                ParticleSystem explode = Instantiate(particles, rig.transform.position, Quaternion.identity);
                hp = hp-2;
                transform.localScale -= new Vector3(0.04f, 0.04f, 0.04f);
                rig.gravityScale += 0.5f;
                Destroy(col.gameObject);

                if (hp <= 0)
                {
              
                    SoundManager.PlaySound("healed");
                    healed = true;
                    ScoreText.score += 1;
                    rig.gravityScale = 0f;
                }
                else
                {
                    SoundManager.PlaySound("hit");
                }
            }
        }
    }

   
}

