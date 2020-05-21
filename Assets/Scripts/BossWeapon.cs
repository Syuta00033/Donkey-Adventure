using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public Transform shotPrefab;
    public Transform parentObject;

    private float currentTime = 0.0f;
    private float shotDelay = 0.4f;

    private bool schalter = false;
    int rand;

    public float bulletspeed = 400f;

    private void Start()
    {
        currentTime = shotDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (BossMovement.normalShoot && !Boss.healed)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= shotDelay)
            {
                schalter = false;
                CreateBullet(0f);
                currentTime = 0.0f;
            }
        }
        else if (BossMovement.rapidShoot && !Boss.healed)
        {
            currentTime += Time.deltaTime;

            if (!schalter)
            {
                rand = Random.Range(1, 4);
                schalter = true;
            }

            if (currentTime >= shotDelay - 0.2)
            {
                if (rand == 1)
                {
                    CreateBullet(-10f);
                    CreateBullet(-5f);
                    CreateBullet(0f);
                    CreateBullet(5f);
                    CreateBullet(10f);
                    currentTime = 0.0f;
                }
                else if (rand == 2)
                {
                    CreateBullet(-30f);
                    CreateBullet(-15f);
                    CreateBullet(0f);
                    CreateBullet(15f);
                    CreateBullet(30f);
                    currentTime = 0.0f;
                }
                else
                {
                    CreateBullet(40f);
                    CreateBullet(-35f);
                    CreateBullet(-30f);
                    CreateBullet(-25f);
                    CreateBullet(0f);
                    CreateBullet(25f);
                    CreateBullet(30f);
                    CreateBullet(35f);
                    CreateBullet(40f);
                    currentTime = 0.0f;
                }
            }
        }
    }

    public void CreateBullet(float angle)
    {
        Transform bullet = Instantiate(shotPrefab);
        bullet.transform.position = transform.position;
        bullet.SetParent(parentObject);

        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(Quaternion.AngleAxis(angle, Vector3.forward) * -transform.right * bulletspeed);
    }
}
