using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int hp = 50;
    public static bool healed = false;

    private Rigidbody2D rig;
    public ParticleSystem particleHit;

    public Slider healthbar;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //HPBar
        healthbar.value = hp;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Shot shot = col.gameObject.GetComponent<Shot>();

        if (col.gameObject.tag == "Shot")
        {
            if (shot && !healed)
            {
                ParticleSystem explode = Instantiate(particleHit, rig.transform.position, Quaternion.identity);
                hp--;
                Destroy(col.gameObject);
                if (hp <= 0)
                {
                    SpriteRenderer r = GetComponent<SpriteRenderer>();
                    r.color = Color.white;
                    healed = true;
                    SoundManager.PlaySound("healed");
                    ScoreText.score += 100;
                }
                else
                {
                    SoundManager.PlaySound("hit");
                }
            }
        }
    }
}
